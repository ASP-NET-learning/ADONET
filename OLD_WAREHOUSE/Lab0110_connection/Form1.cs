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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab0110_connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = "Data Source=TAKODACHI;Database=Northwind;Integrated Security=False;uid=tako1;password=takodachi885";
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                conn.Open();
                button1.Text = "Connect Success!";
            }
            catch 
            {
                this.Text = "fail";
                return;
            }
            
            
                
            
            conn.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
