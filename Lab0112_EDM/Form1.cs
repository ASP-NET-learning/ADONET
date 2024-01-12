using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0112_EDM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private NWEntities context = new NWEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            var query = from o in context.Products
                        select o;
            dataGridView1.DataSource = query.ToList();
                        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.ProductName = "PIZZA";
            p.Discontinued = false;
            context.Products.Add(p);
            context.SaveChanges();
            button2.Text = "OK";

        }

        private void button3_Click(object sender, EventArgs e)
        {   
            Product p = context.Products.Find(80);
            if (p == null)
            {
                button3.Text = "Not Find 80";
                return;
            }
           
            p.ProductName = "Fish";
            context.SaveChanges();
            button3.Text = "OK";


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Product p = context.Products.Find(80);
            if (p == null) 
            {
                button3.Text = "Not Find 80";
                return;
            }
            context.Products.Remove(p);
            context.SaveChanges();
            button4.Text = "OK";
        }
    }
}
