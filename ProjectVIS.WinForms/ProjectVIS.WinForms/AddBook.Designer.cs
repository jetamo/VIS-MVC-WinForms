
namespace ProjectVIS.WinForms
{
    partial class AddBook
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
            this.tb_genre = new System.Windows.Forms.TextBox();
            this.tb_title = new System.Windows.Forms.TextBox();
            this.cb_author = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.b_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_genre
            // 
            this.tb_genre.Location = new System.Drawing.Point(100, 102);
            this.tb_genre.Name = "tb_genre";
            this.tb_genre.Size = new System.Drawing.Size(198, 23);
            this.tb_genre.TabIndex = 0;
            // 
            // tb_title
            // 
            this.tb_title.Location = new System.Drawing.Point(100, 20);
            this.tb_title.Name = "tb_title";
            this.tb_title.Size = new System.Drawing.Size(198, 23);
            this.tb_title.TabIndex = 1;
            // 
            // cb_author
            // 
            this.cb_author.FormattingEnabled = true;
            this.cb_author.Location = new System.Drawing.Point(100, 62);
            this.cb_author.Name = "cb_author";
            this.cb_author.Size = new System.Drawing.Size(198, 23);
            this.cb_author.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Název";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Autor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Žánry";
            // 
            // b_add
            // 
            this.b_add.Location = new System.Drawing.Point(305, 160);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(141, 52);
            this.b_add.TabIndex = 6;
            this.b_add.Text = "Přidat knihu";
            this.b_add.UseVisualStyleBackColor = true;
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // AddBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 224);
            this.Controls.Add(this.b_add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_author);
            this.Controls.Add(this.tb_title);
            this.Controls.Add(this.tb_genre);
            this.Name = "AddBook";
            this.Text = "AddBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_genre;
        private System.Windows.Forms.TextBox tb_title;
        private System.Windows.Forms.ComboBox cb_author;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b_add;
    }
}