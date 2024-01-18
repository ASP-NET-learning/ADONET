using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0118_LINQ_Syntax3
{
    public partial class Form1 : Form
    {
        class Food
        {
            public string name { set; get; }
            public int price { set; get; }
        }

        class Card
        {
            public string name { set; get; }
            public int price { set; get; }
            public int attack { set; get; }
            public int health { set; get; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] datalist = new string[]
            {"AME","INA", "GURA", "KIWAWA", "Calli" };

            var query = from myth in datalist
                            //where myth.IndexOf("a") == 0 開頭為a
                            //where myth.IndexOf("A") >= 0 // 包含A
                        where myth.ToUpper().IndexOf("A") >= 0
                        //select myth.ToLower();
                        select new {data =  myth.ToUpper(),
                        origin_data = myth};

            foreach (var item in query)
            {
                //MessageBox.Show(item);
                //MessageBox.Show(item.origin_data);
                MessageBox.Show(item.data);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Food[] foodList = new Food[]
            {
                new Food() {name = "Apple", price = 10},
                new Food() {name = "Fish", price = 12},
                new Food() {name = "Banana", price = 17},
                new Food() {name = "Wather", price = 10},
                new Food() {name = "Salt", price = 8},
            };

            var query = from food in foodList
                        where food.price > 11
                        orderby food.name descending, food.price ascending
                        select food;

            //Food f = query.Single(); 唯一一個
            // Food f = query.FirstOrDefault();  第一筆或預設 需搭配if else
            // Food f = query.First(); 多個中的第一筆

            foreach (var item in query)
            {
                //MessageBox.Show(item.name);
                string text = $"name:{item.name}, price:{item.price} \r\n";
                textBox1.Text += text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Food[] foodList = new Food[]
            {
                new Food() {name = "Apple", price = 10},
                new Food() {name = "Fish", price = 12},
                new Food() {name = "Banana", price = 17},
                new Food() {name = "Wather", price = 10},
                new Food() {name = "Salt", price = 8},
            };
            var query = from fod in foodList 
                        where fod.price >= 0
                        select fod;
            Food f = query.FirstOrDefault(o => o.price == 10);
            if (f == null)
            {
                textBox1.Text += $"第一筆或預設 : Not Find \r\n";
            }
            else
            {
                textBox1.Text += $"第一筆或預設 : {f.name} \r\n";
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Food[] foodList = new Food[]
            {
                new Food() {name = "Apple", price = 10},
                new Food() {name = "Wather", price = 10},
                new Food() {name = "Banana", price = 17},
                new Food() {name = "Fish", price = 12},
                new Food() {name = "Salt", price = 8},
            };


            var query = from fod in foodList
                        where fod.price >= 0
                        orderby fod.name ascending
                        select fod;

          
            Food f = query.FirstOrDefault(o => o.price <= 9);
            if (f == null)
            {
                textBox1.Text += $"第一筆或預設 : Not Find \r\n";
            }
            else
            {
                textBox1.Text += $"第一筆或預設 : {f.name} \r\n";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void test_Click(object sender, EventArgs e)
        {
            string[] datalist = new string[]
            {"AME","INA", "GURA", "KIWAWA", "Calli" };

            var query = from m in datalist
                        where m.ToUpper().IndexOf("R") >= 0
                        select m.ToLower();
            //顯示結果
            foreach (var item in query)
            {
                string text = item;
                textBox1.Text = text;
            }
        }

        private void test2_Click(object sender, EventArgs e)
        {
            Card[] card = new Card[] 
            { 
                new Card() {name = "ccc", price=10, attack=20, health=30},
                new Card() {name = "aaa", price=1, attack=20, health=30},
                new Card() {name = "cba", price=99, attack=20, health=32},
                new Card() {name = "ggg", price=121, attack=87, health=55},
                new Card() {name = "sss", price=888, attack=88, health=77},
            };

            var query = from c in card where c.price >= 100 select c;
            foreach (var item in query)
            {
                string line = $"{item.name}, {item.attack} \r\n";
                textBox1.Text += line;
            }
        }

        private void test21_Click(object sender, EventArgs e)
        {
            Card[] card = new Card[]
            {
                new Card() {name = "ccc", price=10, attack=20, health=30},
                new Card() {name = "aaa", price=1, attack=20, health=30},
                new Card() {name = "cba", price=99, attack=20, health=32},
                new Card() {name = "ggg", price=121, attack=87, health=55},
                new Card() {name = "sss", price=888, attack=88, health=77},
            };

            var query1 = from c in card where c.attack ==87 select c;
            Card c1 = query1.Single();
            textBox1.Text += $"Single 唯一一筆 {c1.name} \r\n";

            var query2 = from c in card where c.attack == 20 select c;
            Card c2 = query2.First();
            textBox1.Text += $"多筆中的第一筆 {c2.name}\r\n";

            var query3 = from c in card where c.attack == 123 select c;
            Card c3 = query3.FirstOrDefault();
            if (c3 == null)
            {
                textBox1.Text += $"第一筆或預設 : Not Find \r\n";
            }
            else
            {
                textBox1.Text += $"第一筆或預設 : {c3.name} \r\n";
            }
        }

        private void test3_Click(object sender, EventArgs e)
        {
            Card[] card = new Card[]
            {
                new Card() {name = "ccc", price=10, attack=20, health=30},
                new Card() {name = "aaa", price=1, attack=20, health=30},
                new Card() {name = "cba", price=99, attack=20, health=32},
                new Card() {name = "ssr", price=121, attack=87, health=55},
                new Card() {name = "sss", price=888, attack=88, health=77},
            };

            var query = from c in card
                        where c.price >= 0
                        select c;
            Card card1 = query.FirstOrDefault(t => t.price >= 100);
            if (card1 == null) 
            {
                textBox1.Text = "Not Find!";
            }
            else
            {
                textBox1.Text = card1.name;
            }
            

        }

        
    }
}
