using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0124_TwoForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            //form.Show(); // 不會被凍結
            //this.Text = DateTime.Now.ToString();
            if(form.DialogResult == DialogResult.OK)
            {
                button1.Text = form.UserNameTextBox.Text;
            }
            else
            {
                button1.Text = "Cancel";
            }
            //button1.Text = form.UserNameTextBox.Text;
        }
    }
}
