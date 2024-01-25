using System;
using System.Windows.Forms;
using Lab0125_DDL;

namespace Lab0125_UsingDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CToolBox obj = new CToolBox();
            button1.Text = obj.DisplayTime();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CToolBox obj = new CToolBox();
            button2.Text = obj.Add(100, 200).ToString();
        }

    }
}
