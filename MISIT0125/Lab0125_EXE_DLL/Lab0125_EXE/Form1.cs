using Lab0125_DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0125_EXE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CToolBox cToolBox = new CToolBox();
            button1.Text = cToolBox.DisPlay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CToolBox cbToolBox = new CToolBox();
            button2.Text = cbToolBox.Sum(10).ToString();
        }
    }
}
