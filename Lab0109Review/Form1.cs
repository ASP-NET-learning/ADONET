using System;
using System.Data;
using System.Windows.Forms;

namespace Lab0109Review
{
    public partial class Form1 : Form //繼承自Form類別
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Fill(productsDataSet1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Update(productsDataSet1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 顯示有無修改
            button3.Text = productsDataSet1.Products[0].RowState.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 先看表的資料結構那些不能為NULL
            ProductsDataSet.ProductsRow dr = 
                productsDataSet1.Products.NewProductsRow();

            dr.ProductID = 78;
            dr.ProductName = "susi";
            dr.ReorderLevel = 10;
            dr.Discontinued = false;

            productsDataSet1.Products.AddProductsRow(dr);

            button4.Text = dr.RowState.ToString();
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            //
            ProductsDataSet.ProductsRow dr =
                productsDataSet1.Products.FindByProductID(78);

            if (dr != null) 
            {
                Modify.Text = dr.ProductID.ToString();
            }
            else
            {
                Modify.Text = "Not Find!";
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            ProductsDataSet.ProductsRow dr =
                productsDataSet1.Products.FindByProductID(78);
            dr.Delete();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            productsDataSet1.RejectChanges(); //取消所有動作
            // productsDataSet1.Products[0].RejectChanges(); //只取消第一筆
        }
    }
}
