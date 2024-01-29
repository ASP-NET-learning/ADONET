using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0129_FileSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(@"./test123/test456");
            button1.Text = "OK";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.Directory.Delete(@"./test123", true);
            button2.Text = "OK";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //"D:\holo en\ina2.png"
            System.IO.DirectoryInfo obj =
                new System.IO.DirectoryInfo(@"./test123");
            string imagePath = @"D:\holo en\ina2.png";
            string targetImagePath = Path.Combine(@"./test123", Path.GetFileName(imagePath));
            File.Copy(imagePath, targetImagePath, true);
            button3.Text = "圖片已複製到： " + targetImagePath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fs 
                = new FileStream(@"./test123/test.txt", FileMode.Create);

            //string s = DateTime.Now.ToString();
            string s = "這是中文字";

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(s);

            fs.Write(buffer, 0, buffer.Length);

            fs.Read(buffer, 0, buffer.Length);

            fs.Close();
            button4.Text = "OK";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileStream fs 
                = new FileStream(@"./test123/test.txt", FileMode.Create);
            String s = DateTime.Now.ToString();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(s);
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
        }
    }
}
