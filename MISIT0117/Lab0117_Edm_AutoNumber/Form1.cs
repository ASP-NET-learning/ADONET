using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0117_Edm_AutoNumber
{
    public partial class Form1 : Form
    {
        NorthwindEntities context = new NorthwindEntities();
        // 預載資料
        public Form1()
        {
            InitializeComponent();
        }

        // 複習新增資料
        private void button1_Click(object sender, EventArgs e)
        {
            //List<Product> list = context.Products.ToList();
            //this.Text = list[75].ProductName;
            Product p = context.Products.Create();
            p.ProductName = "Lab0117 p1";
            context.Products.Add(p);
            context.SaveChanges();
            button1.Text = p.ProductID.ToString(); // 0 -> 81 自動編號
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
