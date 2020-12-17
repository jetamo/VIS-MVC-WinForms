
namespace ProjectVIS.WinForms
{
    partial class AddRental
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
            this.cb_kniha = new System.Windows.Forms.ComboBox();
            this.cb_zakaznik = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.list_knihy = new System.Windows.Forms.ListBox();
            this.group_kniha = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.group_kniha.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_kniha
            // 
            this.cb_kniha.FormattingEnabled = true;
            this.cb_kniha.Location = new System.Drawing.Point(8, 22);
            this.cb_kniha.Name = "cb_kniha";
            this.cb_kniha.Size = new System.Drawing.Size(149, 23);
            this.cb_kniha.TabIndex = 0;
            this.cb_kniha.SelectedIndexChanged += new System.EventHandler(this.cb_kniha_SelectedIndexChanged);
            // 
            // cb_zakaznik
            // 
            this.cb_zakaznik.FormattingEnabled = true;
            this.cb_zakaznik.Location = new System.Drawing.Point(242, 51);
            this.cb_zakaznik.Name = "cb_zakaznik";
            this.cb_zakaznik.Size = new System.Drawing.Size(121, 23);
            this.cb_zakaznik.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Přídat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(257, 361);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 42);
            this.button2.TabIndex = 3;
            this.button2.Text = "Vypůjčit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // list_knihy
            // 
            this.list_knihy.FormattingEnabled = true;
            this.list_knihy.ItemHeight = 15;
            this.list_knihy.Location = new System.Drawing.Point(30, 189);
            this.list_knihy.Name = "list_knihy";
            this.list_knihy.Size = new System.Drawing.Size(179, 214);
            this.list_knihy.TabIndex = 4;
            // 
            // group_kniha
            // 
            this.group_kniha.Controls.Add(this.button1);
            this.group_kniha.Controls.Add(this.cb_kniha);
            this.group_kniha.Location = new System.Drawing.Point(12, 29);
            this.group_kniha.Name = "group_kniha";
            this.group_kniha.Size = new System.Drawing.Size(187, 114);
            this.group_kniha.TabIndex = 5;
            this.group_kniha.TabStop = false;
            this.group_kniha.Text = "Kniha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Zákazník";
            // 
            // AddRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 419);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.group_kniha);
            this.Controls.Add(this.list_knihy);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cb_zakaznik);
            this.Name = "AddRental";
            this.Text = "AddRental";
            this.group_kniha.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_kniha;
        private System.Windows.Forms.ComboBox cb_zakaznik;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox list_knihy;
        private System.Windows.Forms.GroupBox group_kniha;
        private System.Windows.Forms.Label label1;
    }
}