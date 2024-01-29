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
    public partial class Librarian : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mylibrary;Uid=root;Pwd=bos");
        public Librarian()
        {
            InitializeComponent();
        }
        void VeriListele()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM librarian", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView.DataSource = dt;
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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            VeriListele();
        }

        private void Librarian_Load(object sender, EventArgs e)
        {
            VeriListele();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string librarianID = textBoxLibrarianID.Text;
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddress.Text;
            string phoneNo = textBoxPhoneNo.Text;
            string password = textBoxPassword.Text;

            try
            {
                conn.Open();

                string query = "INSERT INTO librarian (librarianID, name, surname, email, address, phone_no, password) VALUES (@librarianID, @name, @surname, @email, @address, @phoneNo, @password)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@librarianID", librarianID);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phoneNo", phoneNo);
                cmd.Parameters.AddWithValue("@password", password);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kütüphaneci başarıyla kaydedildi.");
                    ClearForm();

                }
                else
                {
                    MessageBox.Show("Kütüphaneci kaydedilirken bir hata oluştu.");
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

        private void ClearForm()
        {
            textBoxLibrarianID.Text = "";
            textBoxName.Text = "";
            textBoxSurname.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            textBoxPhoneNo.Text = "";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string librarianID = textBoxLibrarianID.Text;
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddress.Text;
            string phoneNo = textBoxPhoneNo.Text;
            string password = textBoxPassword.Text;

            try
            {
                conn.Open();
                string query = "UPDATE librarian SET name = @name, surname = @surname, email = @email, address = @address, phone_no = @phoneNo, password = @password WHERE librarianID = @librarianID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phoneNo", phoneNo);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@librarianID", librarianID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Üye bilgileri başarıyla güncellendi.");
                    ClearForm();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string librarianID = textBoxLibrarianID.Text; // Silinecek üye ID'si

            try
            {
                conn.Open();

                string query = "DELETE FROM librarian WHERE librarianID = @librarianID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@librarianID", librarianID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Librarian başarıyla silindi.");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Librarian silinirken bir hata oluştu.");
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

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxLibrarianID.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            textBoxName.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            textBoxSurname.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            textBoxEmail.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            textBoxAddress.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            textBoxPhoneNo.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            textBoxPassword.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();

        }
    }
}
