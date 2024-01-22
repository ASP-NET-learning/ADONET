using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0122_MultiUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthwindEntities context = new NorthwindEntities();
        private void fill_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Products.ToList();
        }

        private void upadte_Click(object sender, EventArgs e)
        {
            NorthwindEntities db = new NorthwindEntities();
            Product p = db.Products.Find(1);
            p.UnitsInStock -= 30;
            db.SaveChanges();
        }
    }
}
