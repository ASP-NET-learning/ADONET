using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0111_MutileUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Fill(productsDataSet1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Update(productsDataSet1);

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sqlDataAdapter1.Update(productsDataSet1);
            }
            catch
            {
                ProductsDataSet ds2 =
                productsDataSet1.GetChanges(DataRowState.Modified) as ProductsDataSet;

                dataGridView2.DataSource = ds2;
                dataGridView2.DataMember = "Products";

                DataRow dr = ds2.Products.Rows[0];
                short originlValue = Convert.ToInt16(dr["UnitsInStock", DataRowVersion.Original]);
                short diff = Convert.ToInt16(ds2.Products[0].UnitsInStock - originlValue);
                sqlDataAdapter1.Fill(productsDataSet1);
                productsDataSet1.Products[0].UnitsInStock += diff;  // -1

                sqlDataAdapter1.Update(productsDataSet1);

                button3.Text = dr["UnitsInStock"].ToString();
                button3.Text = dr["UnitsInStock", DataRowVersion.Original].ToString();

                //dataGridView2.DataSource = ds2;
                //dataGridView2.DataMember = "Products";
            }

        }
    }
}
