using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0126_WeightIsWrong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CAnimal cAnimal = new CAnimal();
            cAnimal.Weight = 1; 
            button1.Text = cAnimal.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CAnimal cAnimal = new CAnimal();
            cAnimal.Weight = -1;
            button2.Text = cAnimal.ToString();
        }
    }
    class CAnimal
    {
        private int _weight = 0;
        public int Weight
        {
            set 
            {
                if(value > 0) 
                {
                    _weight = value;
                }
                else
                {
                    throw new Exception("Error!");
                }
            }
            get { return _weight; }
        }
    }
}
