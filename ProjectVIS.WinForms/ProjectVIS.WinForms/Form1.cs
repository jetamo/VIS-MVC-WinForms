using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer.TableModule;

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
            BookModule knihochlap = new BookModule();
            knihochlap.AddAuthor("Robert", "Jordan");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
