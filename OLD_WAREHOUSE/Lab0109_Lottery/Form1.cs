using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0109_Lottery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lottery.Pick3Row dr =
                lottery.Pick3.NewPick3Row();

            dr.Text = textBox1.Text;

            lottery.Pick3.AddPick3Row(dr);

            //sqlDataAdapter1.Update(productsDataSet1);

            WriteDataToFile();
        }

        private void WriteDataToFile()
        {
            string dataFileName = System.IO.Path.GetDirectoryName(
                            Application.ExecutablePath) + "\\Lottery.xml";

            lottery.WriteXml(dataFileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string dataFileName = System.IO.Path.GetDirectoryName(
                Application.ExecutablePath) + "\\Lottery.xml";

            if(System.IO.File.Exists(dataFileName))
            {
                lottery.ReadXml(dataFileName);
            }
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            
        }

        private void show_Click(object sender, EventArgs e)
        {
            textBox2.Text = System.IO.Path.GetDirectoryName(
                Application.ExecutablePath);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void sqlDataAdapter1_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // 先找到位子
            int index = bindingSource1.Position;
            // RemoveAt 移除(只修改了記憶體不改資料庫內容)
            lottery.Pick3.Rows.RemoveAt(index);
            WriteDataToFile();
        }
    }
}
