using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0118_LINQ_ADONET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Fill(northwindDataSet1);

            var query = from o in northwindDataSet1.Products
                        select o;
            dataGridView1.DataSource = query.ToList();
        }
    }
}
