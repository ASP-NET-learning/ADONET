using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0129_UsingEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void DoA(object sender, EventArgs e)
        {
            MessageBox.Show("AAA");
        }

        private void DoB(object sender, EventArgs e)
        {
            MessageBox.Show("BBB");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button5.Click += DoA;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button5.Click -= DoA;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button5.Click += DoB;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button5.Click-= DoB;
        }
    }
}
