
namespace ProjectVIS.WinForms
{
    partial class ReturnRental
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
            this.cb_rentals = new System.Windows.Forms.ComboBox();
            this.b_ukoncit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_rentals
            // 
            this.cb_rentals.FormattingEnabled = true;
            this.cb_rentals.Location = new System.Drawing.Point(12, 12);
            this.cb_rentals.Name = "cb_rentals";
            this.cb_rentals.Size = new System.Drawing.Size(437, 23);
            this.cb_rentals.TabIndex = 0;
            // 
            // b_ukoncit
            // 
            this.b_ukoncit.Location = new System.Drawing.Point(349, 81);
            this.b_ukoncit.Name = "b_ukoncit";
            this.b_ukoncit.Size = new System.Drawing.Size(100, 47);
            this.b_ukoncit.TabIndex = 1;
            this.b_ukoncit.Text = "Vratit vypujcku";
            this.b_ukoncit.UseVisualStyleBackColor = true;
            this.b_ukoncit.Click += new System.EventHandler(this.b_ukoncit_Click);
            // 
            // ReturnRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 180);
            this.Controls.Add(this.b_ukoncit);
            this.Controls.Add(this.cb_rentals);
            this.Name = "ReturnRental";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_rentals;
        private System.Windows.Forms.Button b_ukoncit;
    }
}