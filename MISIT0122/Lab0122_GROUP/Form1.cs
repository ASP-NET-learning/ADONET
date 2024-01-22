using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0122_GROUP
{
    public partial class Form1 : Form
    {
        NorthwindEntities context = new NorthwindEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void GROUP_Click(object sender, EventArgs e)
        {
            Categories c = context.Categories.Find(1);
            dataGridView1.DataSource = c.Products.ToList();
        }

        private void GROUP2_Click(object sender, EventArgs e)
        {
            var query = from p in context.Products
                        group p by p.CategoryID into g
                        select g;

            foreach (var item in query)
            {
                string s = $"Key = {item.Key} \r\n";
                textBox1.Text += s;
                foreach (var p in item)
                {
                    s = $"\tProdccutName: {p.ProductName} \r\n";
                    textBox1.Text += s;
                }
            }
        }

        private void GROUP3_Click(object sender, EventArgs e)
        {
            var query = from p in context.Products
                        group p by p.CategoryID into g
                        select g;

            foreach (var item in query)
            {
                string s = $"Key = {item.Key} \r\n";
                textBox1.Text += s;
                foreach (var p in item)
                {
                    s = $"\tProdccutName: {p.ProductName} \r\n";
                    textBox1.Text += s;
                }
                s = $"\tTotal Stock: {item.Sum(p => p.UnitsInStock)} \r\n ";
                textBox1.Text += s;
            }
        }

       
    }
}
