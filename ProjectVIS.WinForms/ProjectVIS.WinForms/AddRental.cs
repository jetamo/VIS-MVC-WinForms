using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DomainLayer.ActiveRecord;
using DomainLayer;

namespace ProjectVIS.WinForms
{
    public partial class AddRental : Form
    {
        List<BookActiveRecord> books;
        List<CustomerActiveRecord> customers;
        List<BookActiveRecord> booksToRent;

        Form1 f1;

        public AddRental(Form1 _f1)
        {
            InitializeComponent();

            f1 = _f1;

            booksToRent = new List<BookActiveRecord>();
            books = BookActiveRecord.Find();
            customers = CustomerActiveRecord.Find();

            for(int i = 0; i < books.Count; i++)
            {
                if(books[i].Available == 0)
                {
                    books.RemoveAt(i);
                }
            }

            cb_kniha.DataSource = books;
            cb_zakaznik.DataSource = customers;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RentalActiveRecord rental = new RentalActiveRecord(Var.knihovnik, (CustomerActiveRecord)cb_zakaznik.SelectedItem, DateTime.Now, null, false);
            rental.Save();
            foreach(BookActiveRecord b in booksToRent)
            {
                BookInRentalActiveRecord tmp = new BookInRentalActiveRecord(b, rental);
                tmp.Save();
                b.Available -= 1;
                b.Save();
            }
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            booksToRent.Add((BookActiveRecord)cb_kniha.SelectedItem);
            list_knihy.Items.Add(cb_kniha.SelectedItem);
            books.Remove((BookActiveRecord)cb_kniha.SelectedItem);
            cb_kniha.DataSource = null;
            cb_kniha.Items.Clear();
            cb_kniha.DataSource = books;
        }

        private void cb_kniha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
