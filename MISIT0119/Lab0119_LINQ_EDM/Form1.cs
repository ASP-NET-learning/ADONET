using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0119_LINQ_EDM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        NorthwindEntities context = new NorthwindEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var query = from p in context.Products select p;
            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = from p in context.Products 
                        where p.UnitPrice >= 10
                        orderby p.CategoryID descending, p.UnitPrice ascending
                        select new
                        {
                            id = p.ProductID,
                            name = p.ProductName
                        };
            dataGridView1.DataSource = query.ToList();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var query = from p in context.Products
                        where p.ProductID >= 1
                        select p;
            var objProject = query.First();
            objProject.UnitsInStock = 111;
            context.SaveChanges();
            dataGridView1.DataSource = query.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var query = from p in context.Products select p;
            var query2 = query.OrderByDescending(p => p.UnitPrice);
            dataGridView1.DataSource = query2.ToList();

            var maxs = query.Max(p => p.UnitPrice);
            button5.Text = maxs.ToString();

            var mins = query.Min(p => p.UnitPrice);
            button6.Text = mins.ToString();

            var sums = query.Sum(p => p.UnitPrice);
            button7.Text = sums.ToString();

            var avgs = query.Average(p => p.UnitPrice);
            button8.Text = avgs.ToString();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var query = from p in context.Products
                        join c in context.Categories on p.CategoryID equals c.CategoryID
                        select new
                        {
                            CategoryName = c.CategoryName,
                            ProductName = p.ProductName,
                            UnitsInStock = p.UnitsInStock
                        };
            dataGridView1.DataSource = query.ToList();
        }
    }
}
