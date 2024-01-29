using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem
{
    public partial class Member : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mylibrary;Uid=root;Pwd=bos");
        public Member()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        void VeriListele()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM member", conn);
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

        private void Member_Load(object sender, EventArgs e)
        {
            VeriListele();
            FillLibrariansComboBox();   
        }

        private void ButtonGeri_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cikmak istediginize emin misiniz?", "Sistem Uyarisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FillLibrariansComboBox()
        {
            try
            {
                conn.Open();
                string query = "SELECT librarianID, CONCAT(name, ' ', surname) AS fullName FROM librarian";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    comboBox1.DisplayMember = "fullname";
                    comboBox1.ValueMember = "librarianID";
                    comboBox1.DataSource = dt;
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

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string memberID = textBoxMemberID.Text;
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddress.Text;
            string phoneNo = textBoxPhoneNo.Text;
            int selectedLibrarianID = Convert.ToInt32(comboBox1.SelectedValue);
            string selectedLibrarianName = comboBox1.Text;

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir kütüphaneci seçin.");
            }
          
            try
            { 
                conn.Open();

                string query = "INSERT INTO member (memberID, name, surname, email, address, phone_no, librarianID) VALUES (@memberID, @name, @surname, @email, @address, @phoneNo, @librarian)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@memberID", memberID);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phoneNo", phoneNo);
                cmd.Parameters.AddWithValue("@librarian", selectedLibrarianID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Üye başarıyla kaydedildi.");
                    ClearForm();

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

        private void ClearForm()
        {
            textBoxMemberID.Text = "";
            textBoxName.Text = "";
            textBoxSurname.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            textBoxPhoneNo.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            VeriListele();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string memberID = textBoxMemberID.Text;
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddress.Text;
            string phoneNo = textBoxPhoneNo.Text;
            int librarianID = Convert.ToInt32(comboBox1.SelectedValue);

            try
            {
                conn.Open();
                string query = "UPDATE member SET name = @name, surname = @surname, email = @email, address = @address, phone_no = @phoneNo, librarianID = @librarian WHERE memberID = @memberID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phoneNo", phoneNo);
                cmd.Parameters.AddWithValue("@librarian", librarianID);
                cmd.Parameters.AddWithValue("@memberID", memberID);

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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string memberID = textBoxMemberID.Text; // Silinecek üye ID'si

            try
            {
                conn.Open();

                string query = "DELETE FROM member WHERE memberID = @memberID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@memberID", memberID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Üye başarıyla silindi.");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Üye silinirken bir hata oluştu.");
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
            textBoxMemberID.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            textBoxName.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            textBoxSurname.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            textBoxEmail.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            textBoxAddress.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            textBoxPhoneNo.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            conn.Open();

            // Veritabanından sorgu yaparak librarianID'ye karşılık gelen LibrarianName ve Surname'leri alın
            string query = "SELECT name, surname FROM Librarian WHERE librarianID = @librarianID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@librarianID", dataGridView.CurrentRow.Cells[6].Value.ToString());

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string librarianName = reader["name"].ToString();
                string surname = reader["surname"].ToString();

                // Elde edilen LibrarianName ve Surname'i comboBox'a ekleyin
                comboBox1.Text = librarianName + " " + surname;
            }

            conn.Close();
        }
    }

}

