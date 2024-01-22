using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0122_JOIN
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
            var query = from c in context.Categories
                        join p in context.Products
                        on c.CategoryID equals p.CategoryID
                        where p.UnitPrice >= 0
                        select new
                        {
                            CategoryId = c.CategoryID,
                            CategoryName = c.CategoryName,
                            ProductId = p.ProductID,
                            ProductName = p.ProductName
                        };
            dataGridView1.DataSource = query.ToList();
        }
    }
}
