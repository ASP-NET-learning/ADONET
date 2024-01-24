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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string _okOrCancel = "Cancel";
        public string OkOrCancel
        {
            get { return _okOrCancel; }
            set { _okOrCancel = value; this.Close(); }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //this.OkOrCancel = "Ok";
            //this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //this.OkOrCancel = "Cancel";
            //this.DialogResult= DialogResult.Cancel;
        }

        private void passWord_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
