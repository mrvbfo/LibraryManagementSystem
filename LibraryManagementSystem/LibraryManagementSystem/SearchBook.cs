using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem
{
    public partial class SearchBook : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mylibrary;Uid=root;Pwd=bos");
        public SearchBook()
        {
            InitializeComponent();
        }

        private void SearchBook_Load(object sender, EventArgs e)
        {
            VeriListele();
            FillPublishersComboBox();
            FillAuthorsComboBox();
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

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchBooksByTitle(string title)
        {
            try
            {
                conn.Open();
                string query = "SELECT bookID, book_status, title, category_name, authorID,publisherID,librarianID FROM books WHERE title LIKE @title";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", "%" + title + "%");
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Aradığınız kitap bulunamadı.");
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

       
        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            string title = textBoxName.Text;
            SearchBooksByTitle(title);
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

        private void SearchBooksByPublisher(int publisherID)
        {
            try
            {
                conn.Open();
                string query = "SELECT bookID, book_status, title, category_name, authorID,publisherID,librarianID FROM books WHERE publisherID LIKE @publisherID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@publisherID", publisherID);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Aradığınız kitap bulunamadı.");
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

        private void SearchBooksByAuthor(int authorID)
        {
            try
            {
                conn.Open();
                string query = "SELECT bookID, book_status, title, category_name, authorID,publisherID,librarianID FROM books WHERE authorID LIKE @authorID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@authorID", authorID);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Aradığınız kitap bulunamadı.");
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

        private void buttonPublisherSearch_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                int publisherID = Convert.ToInt32(comboBox2.SelectedValue);
                SearchBooksByPublisher(publisherID);
            }
        }

        private void buttonAuthorSearch_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue != null)
            {
                int authorID = Convert.ToInt32(comboBox3.SelectedValue);
                SearchBooksByAuthor(authorID);
            }
        }
    }
}
