﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0129_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is A");
        }
    }
}
