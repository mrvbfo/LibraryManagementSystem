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

namespace LibraryManagementSystem
{
    public partial class BookIssue : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mylibrary;Uid=root;Pwd=bos");
        public BookIssue()
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

        void VeriListele()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM borrow", conn);
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
        private void BookIssue_Load(object sender, EventArgs e)
        {
            VeriListele();
            FillBooksComboBox();
            FillMemberComboBox();
        }


        private void ButtonGeri_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }

       

        private void FillBooksComboBox()
        {
            try
            {
                conn.Open();
                string query = "SELECT bookID, title FROM books where book_status=1";
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
            FillBooksComboBox();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonIssue_Click(object sender, EventArgs e)
        {
            string borrowID = textBox1.Text;
            int selectedBookID = Convert.ToInt32(comboBox3.SelectedValue);
            int selectedMemberID = Convert.ToInt32(comboBox2.SelectedValue);
            int delay_fine = 0;
            DateTime issue_date = dateTimePicker1.Value;
            DateTime due_date = dateTimePicker2.Value;
            DateTime? return_date = null;

            try
            {
                conn.Open();

                // Ödünç verilen kitabın kontrolü
                string checkBookStatusQuery = "SELECT book_status FROM books WHERE bookID = @bookID";
                MySqlCommand checkBookStatusCmd = new MySqlCommand(checkBookStatusQuery, conn);
                checkBookStatusCmd.Parameters.AddWithValue("@bookID", selectedBookID);
                object bookStatusResult = checkBookStatusCmd.ExecuteScalar();

                if (bookStatusResult != null && Convert.ToInt32(bookStatusResult) == 2)
                {
                    MessageBox.Show("Bu kitap zaten ödünç verilmiş, tekrar ödünç verilemez.");
                }
                else
                {
                    // Borcu olan üyenin kontrolü
                    string checkBorrowQuery = "SELECT delay_fine FROM borrow WHERE memberID = @memberID AND delay_fine > 0";
                    MySqlCommand checkBorrowCmd = new MySqlCommand(checkBorrowQuery, conn);
                    checkBorrowCmd.Parameters.AddWithValue("@memberID", selectedMemberID);
                    object delayFineResult = checkBorrowCmd.ExecuteScalar();

                    if (delayFineResult != null && Convert.ToInt32(delayFineResult) > 0)
                    {
                        MessageBox.Show("Bu üyenin borcu bulunmaktadır. Kitap ödünç verilemez.");
                    }
                    else
                    {
                        string query = "INSERT INTO borrow (borrowID, delay_fine, due_date, issue_date, return_date, bookID, memberID) VALUES (@borrowID, @delay_fine, @due_date, @issue_date, @return_date, @bookID, @memberID)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@borrowID", borrowID);
                        cmd.Parameters.AddWithValue("@delay_fine", delay_fine);
                        cmd.Parameters.AddWithValue("@due_date", due_date);
                        cmd.Parameters.AddWithValue("@issue_date", issue_date);
                        cmd.Parameters.AddWithValue("@return_date", return_date);
                        cmd.Parameters.AddWithValue("@bookID", selectedBookID);
                        cmd.Parameters.AddWithValue("@memberID", selectedMemberID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kitap başarıyla ödünç verildi.");
                            string updateQuery = "UPDATE books SET book_status = 2 WHERE bookID = @bookID";
                            MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                            updateCmd.Parameters.AddWithValue("@bookID", selectedBookID);
                            int updatedRows = updateCmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Üye kaydedilirken bir hata oluştu.");
                        }
                    }
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
        }
    }
}
