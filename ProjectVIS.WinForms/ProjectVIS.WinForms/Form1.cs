using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer.ActiveRecord;

namespace ProjectVIS.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<BookActiveRecord> knihy = BookActiveRecord.Find();
            List<LibrarianActiveRecord> knihovnici = LibrarianActiveRecord.Find();
            List<CustomerActiveRecord> zakaznici = CustomerActiveRecord.Find();
            List<RentalActiveRecord> vypujcky = RentalActiveRecord.Find();
            List<BookInRentalActiveRecord> knihyVeVypujce = BookInRentalActiveRecord.Find();
            List<AuthorActiveRecord> autori = AuthorActiveRecord.Find();

            AddBook addBookForm = new AddBook(this);

            addBookForm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddRental addRentalForm = new AddRental(this);

            addRentalForm.Show();
            this.Hide();
        }

        private void b_sendEmails_Click(object sender, EventArgs e)
        {
            SendEmail sendEmailForm = new SendEmail(this);
            sendEmailForm.Show();
            this.Hide();
        }

        private void b_returnBooks_Click(object sender, EventArgs e)
        {
            ReturnRental returnRentalForm = new ReturnRental(this);
            returnRentalForm.Show();
            this.Hide();
        }
    }
}
