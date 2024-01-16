using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab0116_NextNumber {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "server=(local);database=Northwind;integrated security=true";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "exec NextNumber '0116'";
            int myNumber = Convert.ToInt32(cmd.ExecuteScalar());
            button1.Text = myNumber.ToString();
        }
    }
}
