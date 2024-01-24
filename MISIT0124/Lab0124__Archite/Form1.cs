using Lab0124__Archite;
using System;
using System.Windows.Forms;
using MotherNature.Creature;

namespace Lab0124__Archite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CAnimal obj = new CAnimal(3);
            button1.Text = obj.Weight.ToString();
            obj.MakeSound();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            CDog dog = new CDog();
            button2.Text = dog.Weight.ToString();
            dog.MakeSound();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CAnimal dog = new CDog(5, "KING"); //動物是狗狗會發出聲音
            button3.Text = dog.Weight.ToString();
            dog.MakeSound();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CDog obj = new CDog();
            button4.Text = obj.ToString();
        }
    }

    class CAnimal : Object
    {
        public int Weight {  get; set; }
        public CAnimal()
        {
            this.Weight = 1;
        }
        public CAnimal(int WeightValue)
        {
            this.Weight = WeightValue;
        }
        public virtual void MakeSound()
        {
            MessageBox.Show("AAA..........");
        } // 根據物件參考級別

        protected int Test = 100;
    }

    // 衍生類別 : 基礎類別 
    
}
namespace MotherNature
{
    namespace Creature
    {
        class CDog : CAnimal
        {
            public CDog() : base()
            {
                this.Host = "Null";
                Test = 100;
            }


            /// <summary>
            ///  base 是父階才有的功能
            /// </summary>
            /// <param name="WeightValue"></param>
            /// <param name="HostValue"></param>
            public CDog(int WeightValue, string HostValue) : base(WeightValue)
            {
                this.Host = HostValue;
            }


            public string Host { get; set; }
            public override void MakeSound()
            {
                base.MakeSound();
                MessageBox.Show("Bau Bau");
            }

            public override string ToString()
            {
                return "Wang! Wang!";
            }
        }
    }
}

