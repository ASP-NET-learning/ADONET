using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0111_commend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 談更新的方法
        private void button1_Click(object sender, EventArgs e)
        {
            //建立連線物件
            SqlConnection conn = new SqlConnection();
            //建立連線字串
            conn.ConnectionString = "Server=TAKODACHI;Database=Northwind;Integrated Security=False;uid=tako1;password=takodachi885;Encrypt=False;";
            //開啟資料庫
            conn.Open();

            //使用MSSQL的終端機查詢
            SqlCommand cmd = new SqlCommand();
            //取得連線
            cmd.Connection = conn;
            //更新指令
            cmd.CommandText = "UPDATE Products " +
                "               SET UnitsInStock =100 " +
                "               WHERE ProductID = 1";
            //執行
            int i = cmd.ExecuteNonQuery();
            //顯示在button上
            button1.Text = "OK" + i.ToString();

        }

        // 談查詢的方法
        private void button2_Click(object sender, EventArgs e)
        {
            //快速重購
            SqlConnection conn;
            SqlCommand cmd;
            ConnectSQL(out conn, out cmd);


            cmd.Connection = conn;

            cmd.CommandText = "SELECT SUM(UnitPrice) AS Total FROM Products;";

            decimal result = Convert.ToDecimal(cmd.ExecuteScalar());
            button2.Text = result.ToString();
        }

        private static void ConnectSQL(out SqlConnection conn, out SqlCommand cmd)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Server=TAKODACHI;Database=Northwind;Integrated Security=False;uid=tako1;password=takodachi885;Encrypt=False;";
            conn.Open();

            cmd = new SqlCommand();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand cmd;
            ConnectSQL(out conn, out cmd);

            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Products;";
            SqlDataReader dr = cmd.ExecuteReader();
            //dr.Read();
            //textBox1.Text += dr["ProductName"].ToString() + "\r\n";

            while(dr.Read())
            {
                textBox1.Text += dr["ProductName"].ToString() + "\r\n";
            }
            dr.Close();
            conn.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //SQL 注入問題 面試...
            SqlConnection conn;
            SqlCommand cmd;
            ConnectSQL(out conn, out cmd);

            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Products where unitPrice >= @unitPrice";
            // 定義參數 有幾個參數就要Add幾次
            cmd.Parameters.Add(new SqlParameter("@unitPrice", SqlDbType.Decimal));
            cmd.Parameters["@unitPrice"].Value = 100;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text += dr["ProductName"].ToString() + "\r\n";
            }
            dr.Close();
            conn.Close();


        }

        //談交易模式
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand cmd;
            ConnectSQL(out conn, out cmd);

            cmd.Connection = conn;
            SqlTransaction t = conn.BeginTransaction();

           
            cmd.Connection = conn;
            cmd.CommandText = "update Products set UnitPrice = 11 where ProductID = 1";
            cmd.Transaction = t; // *******
            cmd.ExecuteNonQuery();
            MessageBox.Show("Pause...");
            /*
            use Northwind
            set transaction isolation level read uncommitted
            select * from Products
            */
            t.Rollback();
            // t.Commit();
            // A 原子性 C 一致性 I 隔離性 D 持續性
        }
    }
}
