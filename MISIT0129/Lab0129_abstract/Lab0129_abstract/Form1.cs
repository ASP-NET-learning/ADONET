using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0129_abstract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = CToolBox.GetTime();
            //button1.Text = CToolBox.GetTime(); 必須有static
        }
    }

    class CToolBox
    {
        public string TEST()
        {
            return "A";
        }
        public static string GetTime()
        {
            return DateTime.Now.ToString();
        }
    }

    abstract class Door
    {
        public abstract void Open(int power);
    }

    class ChiYaDoor : Door
    {
        public override void Open(int power)
        {
            MessageBox.Show("Open");
        }
    }
}
