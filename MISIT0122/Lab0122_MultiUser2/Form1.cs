using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0122_MultiUser2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LabDbEntities context = new LabDbEntities();
            var t = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            Product obj = context.Products.Find(2);
            t.Commit();
            label1.Text = obj.UnitsInStock.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LabDbEntities context = new LabDbEntities();
            Product obj = context.Products.Find(2);
            obj.UnitsInStock -= 1;
            System.Threading.Thread.Sleep(1000 * 10);
            context.SaveChanges();
            (sender as Button).Text = "Done";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LabDbEntities context = new LabDbEntities();
            var t = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            Product obj = context.Products.SqlQuery("select * from products with (xlock) where productId = 2").FirstOrDefault();
            // Product obj = context.Products.FromSqlRaw<Product>("select * from products with (xlock) where productId = 2").FirstOrDefault();
            obj.UnitsInStock -= 1;
            context.SaveChanges();
            System.Threading.Thread.Sleep(1000 * 10);
            t.Commit();
        }
    }
}
