using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0117_EDM_StoreProcedure
{
    public partial class Form1 : Form
    {
        NorthwindEntities context = new NorthwindEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = context.NextNumber("0116");
            var x = result.FirstOrDefault(); // 抓第一個如果沒有顯示預設
            textBox1.Text = x.ToString();

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
