namespace LibraryManagementSystem
{
    partial class BookList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookList));
            this.ButtonGeri = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonIssuedBooks = new System.Windows.Forms.Button();
            this.buttonAllBooks = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAvailable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonGeri
            // 
            this.ButtonGeri.BackColor = System.Drawing.Color.Transparent;
            this.ButtonGeri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonGeri.BackgroundImage")));
            this.ButtonGeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonGeri.Location = new System.Drawing.Point(94, 582);
            this.ButtonGeri.Name = "ButtonGeri";
            this.ButtonGeri.Size = new System.Drawing.Size(57, 49);
            this.ButtonGeri.TabIndex = 22;
            this.ButtonGeri.UseVisualStyleBackColor = false;
            this.ButtonGeri.Click += new System.EventHandler(this.ButtonGeri_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(175, 582);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(54, 49);
            this.buttonExit.TabIndex = 23;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(111, 48);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(878, 358);
            this.dataGridView.TabIndex = 61;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Gray;
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonRefresh.Location = new System.Drawing.Point(698, 481);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(186, 42);
            this.buttonRefresh.TabIndex = 62;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonIssuedBooks
            // 
            this.buttonIssuedBooks.BackColor = System.Drawing.Color.Gray;
            this.buttonIssuedBooks.Location = new System.Drawing.Point(312, 481);
            this.buttonIssuedBooks.Name = "buttonIssuedBooks";
            this.buttonIssuedBooks.Size = new System.Drawing.Size(153, 42);
            this.buttonIssuedBooks.TabIndex = 64;
            this.buttonIssuedBooks.Text = "Issued Books";
            this.buttonIssuedBooks.UseVisualStyleBackColor = false;
            this.buttonIssuedBooks.Click += new System.EventHandler(this.buttonIssuedBooks_Click);
            // 
            // buttonAllBooks
            // 
            this.buttonAllBooks.BackColor = System.Drawing.Color.Gray;
            this.buttonAllBooks.Location = new System.Drawing.Point(126, 481);
            this.buttonAllBooks.Name = "buttonAllBooks";
            this.buttonAllBooks.Size = new System.Drawing.Size(153, 42);
            this.buttonAllBooks.TabIndex = 65;
            this.buttonAllBooks.Text = "All Books";
            this.buttonAllBooks.UseVisualStyleBackColor = false;
            this.buttonAllBooks.Click += new System.EventHandler(this.buttonAllBooks_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(81, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 413);
            this.panel1.TabIndex = 75;
            // 
            // buttonAvailable
            // 
            this.buttonAvailable.BackColor = System.Drawing.Color.Gray;
            this.buttonAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonAvailable.Location = new System.Drawing.Point(490, 481);
            this.buttonAvailable.Name = "buttonAvailable";
            this.buttonAvailable.Size = new System.Drawing.Size(190, 42);
            this.buttonAvailable.TabIndex = 76;
            this.buttonAvailable.Text = "Available Books";
            this.buttonAvailable.UseVisualStyleBackColor = false;
            this.buttonAvailable.Click += new System.EventHandler(this.buttonAvailable_Click);
            // 
            // BookList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 675);
            this.Controls.Add(this.buttonAvailable);
            this.Controls.Add(this.buttonAllBooks);
            this.Controls.Add(this.buttonIssuedBooks);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.ButtonGeri);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookList";
            this.Load += new System.EventHandler(this.BookList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonGeri;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonIssuedBooks;
        private System.Windows.Forms.Button buttonAllBooks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAvailable;
    }
}