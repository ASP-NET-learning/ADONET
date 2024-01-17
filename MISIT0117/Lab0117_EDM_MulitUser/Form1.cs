using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0117_EDM_MulitUser
{
    public partial class Form1 : Form
    {
        NorthwindEntities context = new NorthwindEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NorthwindEntities context2 = new NorthwindEntities();
            List<Product> prodList = context2.Products.ToList();
            dataGridView1.DataSource = prodList;
            context2 = context2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }
    }
}
