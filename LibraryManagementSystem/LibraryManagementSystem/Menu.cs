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
    public partial class Menu : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mylibrary;Uid=root;Pwd=bos");
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonMember_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member member = new Member();
            member.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM books where book_status=2";
                MySqlCommand command = new MySqlCommand(query, conn);
                int issuedCount = Convert.ToInt32(command.ExecuteScalar());
                button3.Text = $"{issuedCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM member";
                MySqlCommand command = new MySqlCommand(query, conn);
                int memberCount = Convert.ToInt32(command.ExecuteScalar());
                button1.Text = $"{memberCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM books";
                MySqlCommand command = new MySqlCommand(query, conn);
                int bookCount = Convert.ToInt32(command.ExecuteScalar());
                button2.Text = $"{bookCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddBook addBook = new AddBook();
            addBook.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cikmak istediginize emin misiniz?", "Sistem Uyarisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchBook searchBook = new SearchBook();
            searchBook.Show();
        }

        private void buttonLibrarian_Click(object sender, EventArgs e)
        {
            this.Hide();
            Librarian librarian = new Librarian();
            librarian.Show();

        }

        private void buttonIssueBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookIssue bookIssue = new BookIssue();
            bookIssue.Show();
        }

        private void buttonReturnBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReturnBook returnBook = new ReturnBook();
            returnBook.Show();
        }

        private void buttonBorrow_Click(object sender, EventArgs e)
        {
            this.Hide();
            Borrow borrow = new Borrow();
            borrow.Show();
        }

        private void buttonBookList_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookList bookList = new BookList();
            bookList.Show();
        }

        private void ButtonGeri_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            this.Close();
            giris.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }
    }
}
