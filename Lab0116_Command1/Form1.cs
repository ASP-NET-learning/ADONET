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

namespace Lab0116_Command1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Server=TAKODACHI;Database=Northwind;Integrated Security=False;uid=tako1;password=takodachi885;Encrypt=False;");
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;
            //cmd.CommandText = "execute usp_ListProducts 100, 500";
            cmd.CommandText = "usp_ListProducts";
            // 加入參數
            cmd.Parameters.Add("@min", SqlDbType.Int).Value = 100;
            cmd.Parameters.Add("@max", SqlDbType.Int).Value = 500;
            
            

            //cmd.Parameters.Add("@aaa", SqlDbType.DateTime).Value = DateTime.Now; //增加日期
            //cmd.Parameters.RemoveAt(0); 從指定處移除參數
                        


            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) 
            {
                while (dr.Read()) 
                {
                    textBox1.Text += dr["ProductName"].ToString() + "\r\n";
                }
            }
            dr.Close();
            button1.Text = cn.State.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Server=TAKODACHI;Database=Northwind;Integrated Security=False;uid=tako1;password=takodachi885;Encrypt=False;");
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;

            cmd.CommandText = "usp_add";
            cmd.Parameters.Add("@a", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@b", SqlDbType.Int).Value = 2;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction 
                = ParameterDirection.Output;
            cmd.Parameters.Add("@returnValue", SqlDbType.Int).Direction 
                = ParameterDirection.ReturnValue;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                while (dr.Read())
                {
                    textBox1.Text += dr["result"].ToString() + "\r\n";
                }
            }

            dr.Close();
            button2.Text = cmd.Parameters["@returnValue"].Value.ToString();
            this.Text = cmd.Parameters["@result"].Value.ToString();
            
            //button2.Text = cn.State.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Server=TAKODACHI;Database=Northwind;Integrated Security=False;uid=tako1;password=takodachi885;Encrypt=False;");
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;

            cmd.CommandText = "usp_add";
            cmd.Parameters.Add("@a",SqlDbType.Int).Value = 99;
            cmd.Parameters.Add("@b", SqlDbType.Int).Value = 199;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction 
                = ParameterDirection.Output;
            cmd.Parameters.Add("@return_value", SqlDbType.Int).Direction =
                    ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            button3.Text = cmd.Parameters["@result"].Value.ToString();
            textBox1.Text = cmd.Parameters["@result"].Value.ToString();
        }
    }
}

