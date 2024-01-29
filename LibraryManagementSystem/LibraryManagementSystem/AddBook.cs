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
    public partial class AddBook : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mylibrary;Uid=root;Pwd=bos");
        public AddBook()
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

        private void ButtonGeri_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }

        private void AddBook_Load(object sender, EventArgs e)
        {
            FillPublishersComboBox();
            FillLibrariansComboBox();
            FillAuthorsComboBox();
            VeriListele();
        }

        void VeriListele()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM books", conn);
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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            VeriListele();
        }

        private void FillLibrariansComboBox()
        {
            try
            {
                conn.Open();
                string query = "SELECT librarianID, name FROM librarian";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    comboBox1.DisplayMember = "name";
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

        private void FillPublishersComboBox()
        {
            try
            {
                conn.Open();
                string query = "SELECT publisherID, name FROM publisher";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    comboBox2.DisplayMember = "name";
                    comboBox2.ValueMember = "publisherID";
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

        private void FillAuthorsComboBox()
        {
            try
            {
                conn.Open();
                string query = "SELECT authorID, CONCAT(name, ' ', surname) AS fullName FROM author";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    comboBox3.DisplayMember = "fullName";
                    comboBox3.ValueMember = "authorID";
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string bookID = textBoxBooksID.Text;
            string bookstatus = textBoxBookStatus.Text;
            string title = textBoxTitle.Text;
            string category = textBoxCategory.Text;
            int selectedAuthorID = Convert.ToInt32(comboBox3.SelectedValue);
            int selectedPublisherID = Convert.ToInt32(comboBox2.SelectedValue);
            int selectedLibrarianID = Convert.ToInt32(comboBox1.SelectedValue);

            try
            {
                conn.Open();

                string query = "INSERT INTO books (bookID, book_status, title, category_name, authorID, publisherID, librarianID) VALUES (@bookID, @bookstatus, @title, @category_name, @authorID, @publisherID, @librarianID)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookID", bookID);
                cmd.Parameters.AddWithValue("@bookstatus", bookstatus);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@category_name", category);
                cmd.Parameters.AddWithValue("@authorID", selectedAuthorID);
                cmd.Parameters.AddWithValue("@publisherID", selectedPublisherID);
                cmd.Parameters.AddWithValue("@librarianID", selectedLibrarianID);

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
            textBoxBooksID.Text = "";
            textBoxBookStatus.Text = "";
            textBoxTitle.Text = "";
            textBoxCategory.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string bookID = textBoxBooksID.Text;
            string bookstatus = textBoxBookStatus.Text;
            string title = textBoxTitle.Text;
            string category = textBoxCategory.Text;
            int selectedAuthorID = Convert.ToInt32(comboBox3.SelectedValue);
            int selectedPublisherID = Convert.ToInt32(comboBox2.SelectedValue);
            int selectedLibrarianID = Convert.ToInt32(comboBox1.SelectedValue);

            try
            {
                conn.Open();
                string query = "UPDATE books SET book_status = @bookstatus, title = @title, category_name = @category_name, authorID = @authorID, publisherID = @publisherID, librarianID = @librarianID WHERE bookID = @bookID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookID", bookID);
                cmd.Parameters.AddWithValue("@bookstatus", bookstatus);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@category_name", category);
                cmd.Parameters.AddWithValue("@authorID", selectedAuthorID);
                cmd.Parameters.AddWithValue("@publisherID", selectedPublisherID);
                cmd.Parameters.AddWithValue("@librarianID", selectedLibrarianID);

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
            string bookID = textBoxBooksID.Text; // Silinecek üye ID'si

            try
            {
                conn.Open();

                string query = "DELETE FROM books WHERE bookID = @bookID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookID", bookID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kitap başarıyla silindi.");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Kitap silinirken bir hata oluştu.");
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

        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxBooksID.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            textBoxBookStatus.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            textBoxTitle.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            textBoxCategory.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();

            conn.Open();

            // AuthorID'ye karşılık gelen name ve surname'leri alın
            string query = "SELECT name, surname FROM author WHERE authorID = @authorID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@authorID", dataGridView.CurrentRow.Cells[4].Value.ToString());

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string name = reader["name"].ToString();
                string surname = reader["surname"].ToString();

                comboBox3.Text = name + " " + surname;
            }
            reader.Close();

            // PublisherID'ye karşılık gelen name'leri alın
            string query2 = "SELECT name FROM publisher WHERE publisherID = @publisherID";
            MySqlCommand cmd2 = new MySqlCommand(query2, conn);
            cmd2.Parameters.AddWithValue("@publisherID", dataGridView.CurrentRow.Cells[5].Value.ToString());

            MySqlDataReader reader2 = cmd2.ExecuteReader();

            if (reader2.Read())
            {
                string name = reader2["name"].ToString();

                comboBox2.Text = name;
            }
            reader2.Close();

            // LibrarianID'ye karşılık gelen name ve surname'leri alın
            string query3 = "SELECT name, surname FROM librarian WHERE librarianID = @librarianID";
            MySqlCommand cmd3 = new MySqlCommand(query3, conn);
            cmd3.Parameters.AddWithValue("@librarianID", dataGridView.CurrentRow.Cells[6].Value.ToString());

            MySqlDataReader reader3 = cmd3.ExecuteReader();

            if (reader3.Read())
            {
                string name = reader3["name"].ToString();
                string surname = reader3["surname"].ToString();

                comboBox1.Text = name + " " + surname;
            }
            reader3.Close();

            conn.Close();
        }

    }

}
