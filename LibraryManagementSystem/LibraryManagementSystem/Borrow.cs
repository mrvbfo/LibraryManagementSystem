using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagementSystem
{
    public partial class Borrow : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mylibrary;Uid=root;Pwd=bos");
        public Borrow()
        {
            InitializeComponent();
        }

        private void Borrow_Load(object sender, EventArgs e)
        {
            BorclularListele();
        }

        void BorclularListele()
        {
            string query = "SELECT M.name, M.surname, B.issue_date,B.borrowID, B.return_date,B.due_date, B.delay_fine " +
                   "FROM member M " +
                   "INNER JOIN borrow B ON M.memberID = B.memberID " +
                   "WHERE B.delay_fine > 0";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Verileri DataGridView'e yükleme
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı başarısız oldu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cikmak istediginize emin misiniz?", "Sistem Uyarisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ButtonGeri_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BorclularListele();
        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cikmak istediginize emin misiniz?", "Sistem Uyarisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxBorrowID.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string query = "SELECT memberID, name, surname FROM member WHERE name = @name";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", dataGridView.CurrentRow.Cells[0].Value.ToString());

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string memberID = reader["memberID"].ToString();
                textBoxMemberID.Text = memberID;
            }
            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string memberID = textBoxMemberID.Text;
            string borrowID = textBoxBorrowID.Text;
            int delay_fine = 0;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "UPDATE borrow SET delay_fine = @delay_fine WHERE memberID = @memberID AND borrowID = @borrowID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@delay_fine", delay_fine);
                cmd.Parameters.AddWithValue("@memberID", memberID);
                cmd.Parameters.AddWithValue("@borrowID", borrowID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Borç bilgileri başarıyla güncellendi.");
                }
                else
                {
                    MessageBox.Show("Üye bilgileri güncellenirken bir hata oluştu.");
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            BorclularListele();
        }
    }
}
