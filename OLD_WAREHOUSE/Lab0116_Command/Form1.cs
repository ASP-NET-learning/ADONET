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
using System.Data.OracleClient;

namespace Lab0116_Command
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //hw :　連線Oracle
            SqlConnection cn = new SqlConnection("Server=TAKODACHI;Database=Northwind;Integrated Security=False;uid=tako1;password=takodachi885;Encrypt=False;");
            cn.Open();
            button1.Text = cn.State.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //錯誤會拋出例外:組態檔無法初始化 原因是App.config的連線字串有打錯!
            var s = System.Configuration.ConfigurationManager.
            ConnectionStrings["cn"].ConnectionString;
            // → 邏輯: 呼叫組態管理裡面的物件叫做ConnectionStrings去跟App.config
            //溝通 呼叫"cn"名稱的連線字串去跟底層的SQL做連線
            SqlConnection cn = new SqlConnection(s);
            cn.Open();
            button2.Text = cn.State.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection()
            {
                //連線字串
            };

        }
    }
}
