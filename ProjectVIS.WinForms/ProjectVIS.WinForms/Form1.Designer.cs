namespace ProjectVIS.WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_addBook = new System.Windows.Forms.Button();
            this.b_odebratKnihu = new System.Windows.Forms.Button();
            this.b_upravitKnihu = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.b_returnBooks = new System.Windows.Forms.Button();
            this.b_sendEmails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_addBook
            // 
            this.b_addBook.Location = new System.Drawing.Point(25, 27);
            this.b_addBook.Name = "b_addBook";
            this.b_addBook.Size = new System.Drawing.Size(136, 52);
            this.b_addBook.TabIndex = 0;
            this.b_addBook.Text = "Přidat knihu";
            this.b_addBook.UseVisualStyleBackColor = true;
            this.b_addBook.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_odebratKnihu
            // 
            this.b_odebratKnihu.Location = new System.Drawing.Point(25, 121);
            this.b_odebratKnihu.Name = "b_odebratKnihu";
            this.b_odebratKnihu.Size = new System.Drawing.Size(136, 52);
            this.b_odebratKnihu.TabIndex = 1;
            this.b_odebratKnihu.Text = "Odebrat knihu";
            this.b_odebratKnihu.UseVisualStyleBackColor = true;
            // 
            // b_upravitKnihu
            // 
            this.b_upravitKnihu.Location = new System.Drawing.Point(25, 210);
            this.b_upravitKnihu.Name = "b_upravitKnihu";
            this.b_upravitKnihu.Size = new System.Drawing.Size(136, 52);
            this.b_upravitKnihu.TabIndex = 2;
            this.b_upravitKnihu.Text = "Upravit knihu";
            this.b_upravitKnihu.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(237, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 52);
            this.button3.TabIndex = 3;
            this.button3.Text = "Vytvořit výpůjčku";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // b_returnBooks
            // 
            this.b_returnBooks.Location = new System.Drawing.Point(237, 121);
            this.b_returnBooks.Name = "b_returnBooks";
            this.b_returnBooks.Size = new System.Drawing.Size(136, 52);
            this.b_returnBooks.TabIndex = 4;
            this.b_returnBooks.Text = "Vrátit knihy";
            this.b_returnBooks.UseVisualStyleBackColor = true;
            // 
            // b_sendEmails
            // 
            this.b_sendEmails.Location = new System.Drawing.Point(237, 210);
            this.b_sendEmails.Name = "b_sendEmails";
            this.b_sendEmails.Size = new System.Drawing.Size(136, 52);
            this.b_sendEmails.TabIndex = 5;
            this.b_sendEmails.Text = "Zaslat email uživatelům";
            this.b_sendEmails.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 287);
            this.Controls.Add(this.b_sendEmails);
            this.Controls.Add(this.b_returnBooks);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.b_upravitKnihu);
            this.Controls.Add(this.b_odebratKnihu);
            this.Controls.Add(this.b_addBook);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_addBook;
        private System.Windows.Forms.Button b_odebratKnihu;
        private System.Windows.Forms.Button b_upravitKnihu;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button b_returnBooks;
        private System.Windows.Forms.Button b_sendEmails;
    }
}

