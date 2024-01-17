using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0117_EDM_relationship
{
    public partial class Form1 : Form
    {
        NorthwindEntities context = new NorthwindEntities();
        public Form1()
        {
            InitializeComponent();
        }

        //談FIND 以及 關聯其他表的內容
        private void button1_Click(object sender, EventArgs e)
        {
            //Customer c = new Customer(); // 建構顧客物件
            //c.CustomerID.Take(10); // 取得顧客關係
            Customer c = context.Customers.Find("ALFKI");
            string line = $"name:{c.CompanyName} \r\n";
            textBox1.Text = line;

            //依導覽屬性去找效率佳
            List<Order> orderList = c.Orders.ToList();
            foreach(Order order in orderList) 
            {
                line = $"Order # :{orderList} \r\n";
                textBox1.Text += line;
            }

            //foreach(Order item in c.Orders) 
            //{
            //    line = $"Order # :{item.OrderID} \r\n";
            //    textBox1.Text += line;
            //} Lazy loading 效率差
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Order order = context.Orders.Find(10643);
            string line = $"order date : {order.OrderDate} \r\n";
            textBox1.Text += line;

            string line2 = $"Customer Name : {order.CustomerID} \r\n";
            textBox1.Text += line2;

            string line3 = $"Address : {order.ShipAddress} \r\n";
            textBox1.Text += line3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order order = context.Orders.Create();
            order.CustomerID = "RATTC";
            context.Orders.Add(order);

            Order_Detail od = context.Order_Details.Create();
            od.ProductID = 1;
            od.UnitPrice = 999;
            od.Quantity = 12;
            od.Discount = 0.1f;
            od.Order = order;
            context.Order_Details.Add(od);
            context.SaveChanges();

            string line = $"Order id : {order.OrderID} \r\n";
            textBox1.Text += line;

            string line2 = $"Order details id : {od.OrderID} \r\n";
            textBox1.Text += line2;

            string line3 = $"Unit Price : {od.UnitPrice} \r\n";
            textBox1.Text += line3;


        }

        //有錯修正
        private void button4_Click(object sender, EventArgs e)
        {
            // 今天的第一張訂單進來了
            Order order = context.Orders.Create();
            // 客戶是誰?
            order.CustomerID = "INA";
            // 下訂單的日期
            order.OrderDate = DateTime.Now;
            // 完成訂單後加入資料庫
            context.Orders.Add(order);

            //--------------------------
            // 今天INA要來看他買了多少錢
            Order_Detail od = context.Order_Details.Create();
            od.ProductID = 66;
            od.OrderID = order.OrderID;
            od.UnitPrice = 499;
            od.Quantity = 1;
            od.Discount = 0.9f;
            context.Order_Details.Add(od);
            context.SaveChanges();

            //var money = od.UnitPrice * od.Quantity * (1 - od.Discount);

            string line = $"Order id : {order.OrderID} \r\n";
            textBox1.Text += line;

            string line2 = $"Order details id : {od.OrderID} \r\n";
            textBox1.Text += line2;

            string line3 = $"Unit Price : {od.UnitPrice} \r\n";
            textBox1.Text += line3;
        }
    }
}
