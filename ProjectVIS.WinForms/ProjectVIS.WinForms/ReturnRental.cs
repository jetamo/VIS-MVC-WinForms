using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DomainLayer.ActiveRecord;
namespace ProjectVIS.WinForms
{
    public partial class ReturnRental : Form
    {
        Form1 f1;
        List<RentalActiveRecord> rentals;
        public ReturnRental(Form1 _f1)
        {
            InitializeComponent();
            f1 = _f1;
            rentals = RentalActiveRecord.Find();
            for(int i = 0; i < rentals.Count; i++)
            {
                if (rentals[i].Vraceno == true)
                    rentals.RemoveAt(i);
            }
            cb_rentals.DataSource = rentals;
        }

        private void b_ukoncit_Click(object sender, EventArgs e)
        {
            RentalActiveRecord returned = (RentalActiveRecord)cb_rentals.SelectedItem;
            List<BookInRentalActiveRecord> booksInRental = BookInRentalActiveRecord.Find();
            for(int i = 0; i < booksInRental.Count; i++)
            {
                if(!(booksInRental[i].Rental.ID == returned.ID))
                {
                    booksInRental.RemoveAt(i);
                }
            }

            foreach(BookInRentalActiveRecord b in booksInRental)
            {
                b.Book.Available += 1;
                b.Book.Save();
            }
            returned.ReturnDate = DateTime.Now;
            returned.Vraceno = true;
            returned.Save();

            f1.Show();
            this.Hide();
        }
    }
}
