using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0126_Exception
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "Notepadxxx";
            //string fileName = @"A:\MISIT\ADONET\DevDotNet\A_Codes_Classes.txt";
            //string url = "https://igouist.github.io/post/2020/07/oo-7-interface/";

            try
            {
                System.Diagnostics.Process.Start(fileName);
                //System.Diagnostics.Process.Start(url);
            }
            catch(System.ComponentModel.Win32Exception ex) 
            {
                textBox1.Text += "into try block \r\n";
                textBox1.Text += $"{ex.Message } \r\n";
            }
            catch (Exception ex) 
            {
                textBox1.Text = "into general catch blck \r\n";
            }
            button1.Text = DateTime.Now.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Exception obj = new Exception("Test Error Message");
            throw obj;
            button2.Text = obj.ToString();
        }
        int SendMail(int i)
        {
            int resure = 1;
            try
            {
                if (i == 4)
                {
                    throw new Exception("Email format is wrong");
                }
                string report = $"i = {i} \r\n";
                textBox1.Text += report;
            }
            catch (Exception ex)
            {
                resure = -1;
                string report = $"Error Message = {ex.Message} \r\n";
                textBox1.Text += report;
            }
            return resure;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i <= 9; i++) 
            {

                int result = SendMail(i);
                if (result == 0)
                {
                    SendMail(i);
                }
                else if (result == -1)
                {
                    break;
                }
            }
        }
    }
}
