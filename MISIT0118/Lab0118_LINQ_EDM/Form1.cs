using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0118_LINQ_EDM
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
            // LAZY LOAD
            var query = from p in context.Products select p;
            List<Product> productsList = query.ToList();
            dataGridView1.DataSource = productsList;  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = from p in context.Products
                        where p.ProductID <= 3
                        select p;
            List<Product> productsList = query.ToList();
            dataGridView1.DataSource = productsList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Product p = context.Products.Find(1);
            p.UnitsInStock = 111;
        }

        private void update_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

        private void update2_Click(object sender, EventArgs e)
        {
            var query = from p in context.Products
                        where p.ProductID == 1
                        select p;
            var objProjet = query.First();
            objProjet.UnitsInStock = 123;
            context.SaveChanges();
        }

        //練習補單程式
        private void test_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(textBox1.Text);
            int price = Convert.ToInt16(textBox2.Text);
            Product p = context.Products.Find(id);
            p.UnitPrice = price;
            context.SaveChanges();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var query = from p in context.Products
                        where p.ProductID <= 3
                        select p;
            List<Product> productsList = query.ToList();
            dataGridView1.DataSource = productsList;

            var total = query.Sum(o => o.UnitsInStock);
            var max_ = query.Max(o => o.UnitsInStock);
            var min_ = query.Min(o => o.UnitsInStock);
            var avg_ = query.Average(o => o.UnitsInStock);
            button7.Text = total.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
