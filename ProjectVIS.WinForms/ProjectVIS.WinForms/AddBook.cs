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
    public partial class AddBook : Form
    {
        Form1 f1;
        public AddBook(Form1 _f1)
        {
            InitializeComponent();
            List<AuthorActiveRecord> authors = AuthorActiveRecord.Find();

            f1 = _f1;

            cb_author.DataSource = authors;

        }

        private void b_add_Click(object sender, EventArgs e)
        {
            BookActiveRecord book = new BookActiveRecord((AuthorActiveRecord)cb_author.SelectedItem, tb_title.Text, tb_genre.Text);
            book.Save();
            f1.Show();
            this.Hide();
        }
    }
}
