namespace LibraryManagementSystem
{
    partial class SearchBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBook));
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonNameSearch = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.ButtonGeri = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonPublisherSearch = new System.Windows.Forms.Button();
            this.buttonAuthorSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Candara Light", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxName.Location = new System.Drawing.Point(24, 169);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(244, 40);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.Text = "Name";
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Silver;
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonRefresh.Location = new System.Drawing.Point(257, 538);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(206, 35);
            this.buttonRefresh.TabIndex = 7;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonNameSearch
            // 
            this.buttonNameSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonNameSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNameSearch.BackgroundImage")));
            this.buttonNameSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonNameSearch.Location = new System.Drawing.Point(274, 170);
            this.buttonNameSearch.Name = "buttonNameSearch";
            this.buttonNameSearch.Size = new System.Drawing.Size(47, 40);
            this.buttonNameSearch.TabIndex = 17;
            this.buttonNameSearch.UseVisualStyleBackColor = false;
            this.buttonNameSearch.Click += new System.EventHandler(this.buttonSearchBook_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(78, 668);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(53, 41);
            this.buttonExit.TabIndex = 18;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // ButtonGeri
            // 
            this.ButtonGeri.BackColor = System.Drawing.Color.Transparent;
            this.ButtonGeri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonGeri.BackgroundImage")));
            this.ButtonGeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonGeri.Location = new System.Drawing.Point(22, 668);
            this.ButtonGeri.Name = "ButtonGeri";
            this.ButtonGeri.Size = new System.Drawing.Size(50, 41);
            this.ButtonGeri.TabIndex = 22;
            this.ButtonGeri.UseVisualStyleBackColor = false;
            this.ButtonGeri.Click += new System.EventHandler(this.ButtonGeri_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(17, 73);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(659, 444);
            this.dataGridView.TabIndex = 60;
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.ItemHeight = 21;
            this.comboBox3.Location = new System.Drawing.Point(24, 318);
            this.comboBox3.MaxDropDownItems = 5;
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(244, 29);
            this.comboBox3.TabIndex = 64;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(24, 250);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(244, 29);
            this.comboBox2.TabIndex = 65;
            // 
            // buttonPublisherSearch
            // 
            this.buttonPublisherSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonPublisherSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPublisherSearch.BackgroundImage")));
            this.buttonPublisherSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPublisherSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonPublisherSearch.Location = new System.Drawing.Point(274, 242);
            this.buttonPublisherSearch.Name = "buttonPublisherSearch";
            this.buttonPublisherSearch.Size = new System.Drawing.Size(47, 39);
            this.buttonPublisherSearch.TabIndex = 66;
            this.buttonPublisherSearch.UseVisualStyleBackColor = false;
            this.buttonPublisherSearch.Click += new System.EventHandler(this.buttonPublisherSearch_Click);
            // 
            // buttonAuthorSearch
            // 
            this.buttonAuthorSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonAuthorSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAuthorSearch.BackgroundImage")));
            this.buttonAuthorSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAuthorSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonAuthorSearch.Location = new System.Drawing.Point(274, 309);
            this.buttonAuthorSearch.Name = "buttonAuthorSearch";
            this.buttonAuthorSearch.Size = new System.Drawing.Size(47, 40);
            this.buttonAuthorSearch.TabIndex = 67;
            this.buttonAuthorSearch.UseVisualStyleBackColor = false;
            this.buttonAuthorSearch.Click += new System.EventHandler(this.buttonAuthorSearch_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Location = new System.Drawing.Point(410, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 600);
            this.panel1.TabIndex = 69;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.buttonPublisherSearch);
            this.panel2.Controls.Add(this.buttonNameSearch);
            this.panel2.Controls.Add(this.buttonAuthorSearch);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.textBoxName);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Location = new System.Drawing.Point(12, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 600);
            this.panel2.TabIndex = 70;
            // 
            // SearchBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 730);
            this.Controls.Add(this.ButtonGeri);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchBook";
            this.Load += new System.EventHandler(this.SearchBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonNameSearch;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button ButtonGeri;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonPublisherSearch;
        private System.Windows.Forms.Button buttonAuthorSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}