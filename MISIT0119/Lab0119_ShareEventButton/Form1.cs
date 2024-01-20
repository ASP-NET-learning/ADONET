using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0119_ShareEventButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button3.Click += doClick;
        }

        
        delegate int AddDelegate(int a, int b);

        private void doClick(object sender, EventArgs e)
        {   string s = (sender as Button).Tag.ToString();
            //string s = (sender as Button).Text;
            MessageBox.Show(s);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddDelegate p = (x, y) => { return x + y; };

            int answer = p(1000, 1);
            (sender as Button).Text = answer.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddDelegate p = (x, y) => x + y * 10;
            int answer = p(1000, 1);
            (sender as Button).Text = answer.ToString();
        }

        // 勇者小隊接任務... 生產線拿資料生產...
        void TestLambda(Object sender, AddDelegate p)
        {
            int answer = p(1000, 1);
            (sender as Button).Text = answer.ToString();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            TestLambda(sender, (x, y) => { return x + y; });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Func<int, int, int, int> p = (x, y, z) => {
                return x + y + z;
            };

            int answer = p(1000, 1, 10);
            (sender as Button).Text = answer.ToString();
        }

        // 總戰力要超過50才能接
        private void button8_Click(object sender, EventArgs e)
        {
            Func<int, int, int> task = (x,y) =>
            {
                return x+y;
            };
            Func<int,int> task2 = (x) =>
            {
                if(x >= 50)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            };

            int team1 = task(10,20);
            int team2 = task(50, 20);

            int take = task2(team2);
            if(take == 1)
            {
                (sender as Button).Text = "可以接";
            }
            else
            {
                (sender as Button).Text = "不可以接";
            }

        }
    }
}
