using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0117_Syntax_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 討論LINQ query
        private void button1_Click(object sender, EventArgs e)
        {
            string[] datalist = new string[]
            {"AME", "INA", "GURA", "KIWAWA", "Calli" };

            var query = from myth in datalist select myth;

            foreach (var item in query)
            {
                MessageBox.Show(item);
            }
        }

        // 討論order by
        private void OrderBy_Click(object sender, EventArgs e)
        {
            string[] datalist = new string[]
            {"AME","INA", "GURA", "KIWAWA", "Calli" };

            var query = from myth in datalist 
                        orderby myth ascending
                        select myth;

            foreach (var item in query)
            {
                MessageBox.Show(item);
            }
        }

        

        private void Where_Click(object sender, EventArgs e)
        {
            string[] datalist = new string[]
            {"AME","INA", "GURA", "KIWAWA", "Calli" };

            var query = from myth in datalist
                            //where myth.IndexOf("a") == 0 開頭為a
                            //where myth.IndexOf("A") >= 0 // 包含A
                        where myth.ToUpper().IndexOf("A") >= 0
                        select myth;

            foreach (var item in query)
            {
                MessageBox.Show(item);
            }
        }

        private void Regex_Click(object sender, EventArgs e)
        {
            string[] dataList = new string[] { "a1", "b", "a31x", "a2", "c" };
            System.Text.RegularExpressions.Regex tester 
                = new System.Text.RegularExpressions.Regex(@"^a[0-9]*$");
            var query = from data in dataList 
                        where tester.IsMatch(data)
                        select data;
            foreach (var item in query)
            {
                MessageBox.Show(item);
            }
        }
    }
}






        