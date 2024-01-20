using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0119_LINQ_ADONET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Fill(dataSet1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = dataSet1.Products;
            //dataGridView1.DataSource = dataSet1;
            //dataGridView1.DataMember = "Products";

            //DataView dv = new DataView(); // 觀景窗
            //dv.Table = dataSet1.Products; // 看風景
            //dv.RowFilter = "UnitPrice >= 100"; // 看哪個角度的風景
            //dataGridView1.DataSource = dv; // 顯示風景

            DataTable dt = dataSet1.Products;
            var query = from p in dataSet1.Products
                        select new
                        {
                            id = p.ProductID,
                            pName = p.ProductName,
                        };
            //var query = from p in dt.AsEnumerable() 
            //            select new
            //            {
            //                id = p["ProductId"],
            //                pName = p["ProductName"],
            //            } ;
            dataGridView1.DataSource = query.ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var query = from p in dataSet1.Products
                        select p;
            dataGridView1.DataSource = query.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var query = from p in dataSet1.Products
                        where p.ProductID == 1
                        select p;
            var prod = query.Single();
            prod.UnitPrice = 100;
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
