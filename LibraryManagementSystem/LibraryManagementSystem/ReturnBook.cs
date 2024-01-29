using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem
{
    public partial class ReturnBook : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mylibrary;Uid=root;Pwd=bos");
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cikmak istediginize emin misiniz?", "Sistem Uyarisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            FillBooksComboBox();
            VeriListele();
            FillMemberComboBox();
        }

        private void FillBooksComboBox()
        {
            try
            {
                conn.Open();
                string query = "SELECT bookID, title FROM books where book_status=2";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    comboBox3.DisplayMember = "title";
                    comboBox3.ValueMember = "bookID";
                    comboBox3.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
        private void ButtonGeri_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }
        void VeriListele()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT borrow.borrowID, borrow.delay_fine, borrow.due_date, borrow.issue_date, borrow.return_date, borrow.bookID, borrow.memberID FROM borrow INNER JOIN books ON borrow.bookID = books.bookID WHERE books.book_status = 2 AND borrow.return_date IS NULL", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanından veri alınamadı: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        private void FillMemberComboBox()
        {
            try
            {
                conn.Open();
                string query = "SELECT memberID, CONCAT(name, ' ', surname) AS fullName FROM member";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    comboBox2.DisplayMember = "fullName";
                    comboBox2.ValueMember = "memberID";
                    comboBox2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            VeriListele();
        }


        private void buttonReturn_Click(object sender, EventArgs e)
        {
            string borrowID = textBox1.Text;
            int book_status = 1;
            int selectedBookID = Convert.ToInt32(comboBox3.SelectedValue);
            int selectedMemberID = Convert.ToInt32(comboBox2.SelectedValue);
            DateTime? return_date = dateTimePicker1.Value;
            try
            {
                conn.Open();
                string query = "UPDATE borrow SET return_date = @return_date, delay_fine = CASE WHEN @return_date > due_date THEN TIMESTAMPDIFF(DAY, due_date, @return_date) * 100 ELSE 0 END WHERE borrowID = @borrowID AND memberID = @memberID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@borrowID", borrowID);
                cmd.Parameters.AddWithValue("@return_date", return_date);
                cmd.Parameters.AddWithValue("@memberID", selectedMemberID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {

                    MessageBox.Show("İade başarılı bir şekilde gerçekleşti.");
                    string updateQuery = "UPDATE books SET book_status =@book_status WHERE bookID = @bookID";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@bookID", selectedBookID);
                    updateCmd.Parameters.AddWithValue("@book_status", book_status);
                    int updatedRows = updateCmd.ExecuteNonQuery(); 

                }
                else
                {
                    MessageBox.Show("Üye kaydedilirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }


        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            conn.Open();

            // Veritabanından sorgu yaparak bookID'ye karşılık gelen title'ları alın
            string query = "SELECT title FROM books WHERE bookID = @bookID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@bookID", dataGridView1.CurrentRow.Cells[5].Value.ToString());

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string title = reader["title"].ToString();

                // Elde edilen LibrarianName ve Surname'i comboBox'a ekleyin
                comboBox3.Text = title;
            }
            reader.Close();

            // MemberID'ye karşılık gelen name ve surname'leri alın
            string query2 = "SELECT name,surname FROM member WHERE memberID = @memberID";
            MySqlCommand cmd2 = new MySqlCommand(query2, conn);
            cmd2.Parameters.AddWithValue("@memberID", dataGridView1.CurrentRow.Cells[6].Value.ToString());

            MySqlDataReader reader2 = cmd2.ExecuteReader();

            if (reader2.Read())
            {
                string name = reader2["name"].ToString();
                string surname = reader2["surname"].ToString();

                comboBox2.Text = name + " " + surname;

            }
            reader2.Close();

            conn.Close();
        }
    }
}
