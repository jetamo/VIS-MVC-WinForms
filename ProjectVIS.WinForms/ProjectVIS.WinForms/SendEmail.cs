using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DomainLayer;
using DomainLayer.ActiveRecord;

namespace ProjectVIS.WinForms
{
    public partial class SendEmail : Form
    {
        Form1 f1;

        List<CustomerActiveRecord> customers;
        List<RentalActiveRecord> rentals;
        public SendEmail(Form1 _f1)
        {
            InitializeComponent();
            f1 = _f1;
            customers = CustomerActiveRecord.Find();
            rentals = RentalActiveRecord.Find();

            for(int i = 0; i < customers.Count; i++)
            {
                bool remove = true;
                foreach (RentalActiveRecord rental in rentals)
                {
                    if (rental.ReturnDate == null && rental.Customer.ID == customers[i].ID)
                    {
                        remove = false;
                        break;
                    }
                }
                if (remove)
                {
                    customers.RemoveAt(i);
                }
            }
            if(customers.Count == 0)
            {
                MessageBox.Show("V databazi neexistuje zakaznik s aktivni vypujckou.");
                f1.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Nelze odeslat prazdnou zpravu.");
            }
            foreach(CustomerActiveRecord customer in customers)
            {
                if(!EmailSender.SendEmail(richTextBox1.Text, customer.Email))
                {
                    MessageBox.Show("Email se nepodarilo odeslat.");
                    return;
                }
            }
        }
    }
}
