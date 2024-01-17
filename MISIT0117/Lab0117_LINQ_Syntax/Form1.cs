using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0117_LINQ_Syntax
{
    

    public partial class Form1 : Form
    {
        class Employee
        {
            private int _id;
            public int id
            {
                set
                {
                    this._id = value;
                }
                get
                {
                    return this._id;
                }
            }

            public string name { get; set; }
        }

        class Card
        {
            public string card_name { get; set; }

            private int _id;
            public int id
            {
                set
                {
                    this._id = value;
                }
                get
                {
                    return this._id;
                }
            }

            public int attack;
            public int health;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var emp1 = new Employee();
            //emp1.id = 1;
            //emp1.name = "Jack";

            //var emp2 = new Employee();
            //emp2.id = 2;
            //emp2.name = "Bill";

            //var emp3 = new Employee();
            //emp3.id = 3;
            //emp3.name = "Luca";

            //Employee[] empList = new Employee[] 
            //{ emp1, emp2, emp3 };

            //foreach ( Employee emps in empList ) 
            //{
            //    string line = $"id : {emps.id}, name : {emps.name} \r\n";
            //    textBox1.Text += line;
            //}

            Employee[] empList = new Employee[]
            {
                new Employee {id = 1, name = "Ina"},
                new Employee {id = 2, name = "MIKO"},
                new Employee {id = 3, name = "AME"}
            };
            foreach (Employee emps in empList) 
            {
                string line = $"id : {emps.id}, name : {emps.name} \r\n";
                textBox1.Text += line;
            }
        }

        

        private void practise_Click(object sender, EventArgs e)
        {
            Card[] cardList = new Card[] {
                new Card {id = 1, card_name = "AAA", attack = 10, health = 30 },
                new Card {id = 2, card_name = "bbb", attack = 15, health = 10 },
                new Card {id = 3, card_name = "ccc", attack = 20, health = 70 }
            };
            foreach(Card card in cardList)
            {
                string line = $"id : {card.id}, name : {card.card_name}, attack : {card.card_name}, health : {card.health} \r\n";
                textBox1.Text += line;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var emp10 = new { id = 10, LastName = "Messi", country = "A." };
            textBox1.Text += emp10.GetType().ToString();
            this.Text = emp10.LastName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var cityList = new[] {
                new { cityID = "TC", cityName = "TaiChung" },
                new { cityID = "TP", cityName = "TaiPei" }
            };

            button3.Text = cityList[1].cityName;
        }
    }
}
