using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0119_Events
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void DoAAA(object sender, EventArgs e)
        {
            MessageBox.Show("AAA");
        }

        private void DoBBB(object sender, EventArgs e)
        {
            MessageBox.Show("BBB");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test.Click += new EventHandler(DoBBB);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test.Click -= new EventHandler(DoBBB);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Test.Click += new EventHandler(DoAAA);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Test.Click -= new EventHandler(DoAAA);
        }

        private void Test_Click(object sender, EventArgs e)
        {

        }
    }
}
