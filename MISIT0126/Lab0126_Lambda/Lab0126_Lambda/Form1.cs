using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0126_Lambda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        int Add10(int x, int y) 
        {
            return (x + y)*10;
        }

        delegate int TAdd(int x, int y);

        private void button1_Click(object sender, EventArgs e)
        {
            Func<int, int, int> addFunction = Add10;
            //TAdd p = new TAdd();
            //TAdd p = Add10;
            int answer = addFunction(100, 200);
            button1.Text = answer.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TAdd p = (x,y) => Add10(x,y);
            TAdd q = (x,y) => Add(x, y);

            int answer1 = p(10, 20);
            int answer2 = q(10, 20);

            button1.Text=answer1.ToString();
            button2.Text=answer2.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TAdd test = (x,y) => Add(x,y) + Add10(x,y) + 77777;
            int a = test(1, 2);
            button3.Text = a.ToString();
        }

        void TestLambda(Object sender, TAdd p)
        {
            int answer = p(100,200);
            (sender as Button).Text = answer.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            TestLambda(sender, (x, y) => { return x + y * 100; });
        }

        void TestLambda2(Object sender, Func<int, int, int> p)
        {
            (sender as Button).Text = p(1000, 1).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TestLambda2(sender, (x,y) => { return x + y * (100 - 1); });
        }
    }
}
