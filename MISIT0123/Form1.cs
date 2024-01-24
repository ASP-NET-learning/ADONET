using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0123_Class
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CAnimal obj = new CAnimal(); // 建立新的動物物件
            obj.MakeSound(6); // obj參照MakeSound方法
            //obj.MakeSound(7, "*");
            // error! CAnimal obj = null; obj.MakeSound(); →
            // System.NullReferenceException:
            // 並未將物件參考設定為物件的執行個體。
            //CAnimal obj2 = null;
            //obj2.MakeSound();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CAnimal aimal = new CAnimal();
            //aimal.SetWeight(-3); // 不符合條件回傳預設值1
            //button2.Text = aimal.GetWeight().ToString();
            //------------------------------------------
            //aimal.Weight = 9999;
            //MessageBox.Show("GG");
            //button2.Text = aimal.Weight.ToString();

            //CAnimal obj = new CAnimal()
            //{
            //    Weight = 5,
            //    Location = "TaiChung"
            //};

            aimal.Location = "台中";
            aimal.Weight = 999;
            button2.Text = $"location : {aimal.Location}, weight: {aimal.Weight}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CAnimal obj = new CAnimal()
            {
                Weight = 5,
                Location = "TaiChung"
            };

            button3.Text = $"Weight: {obj.Weight}, Location: {obj.Location}";
        }
    }
    class CAnimal
    {
        public CAnimal()
        {
            this.Init(1, "Earth");
        }
        public CAnimal(int weightValue, string locationValue)
        {
            this.Init(weightValue, locationValue);
        }
        private void Init(int weightValue, string locationValue)
        {
            this.Weight = weightValue;
            this.Location = locationValue;
        }

        public string Location { get; set; }
        private int _weight = 1;
        public int Weight
        {
            get { return this._weight; }
            set 
            {
                MessageBox.Show($"Lab test: {this._weight}");
                if(value > 0)
                {
                    this._weight = value;
                }
            }
        }
        //public int GetWeight()
        //{
        //    return this._weight;
        //}
        //public void SetWeight(int value)
        //{
        //    if(value > 0)
        //    {
        //        this._weight = value;
        //    }
        //}


        // -----------------------------------------------
        public void MakeSound(int volume, string symbol = ")")
        {
            MessageBox.Show("Vers E");
            string result = "Animal: ";
            for (int i = 1; i <= volume; i++)
            {
                result += symbol;
            }
            MessageBox.Show(result, "Hint");
        }

        // 多載overload
        public void MakeSound()
        {
            MessageBox.Show("Vers A");
            MakeSound(6, "*");
        }

        public void MakeSound(int volume)
        {
            MessageBox.Show("Vers B");
            MakeSound(volume, "*");
        }

        public void MakeSound(string symbol)
        {
            MessageBox.Show("Vers C");
            MakeSound(6, symbol);
        }

        public void MakeSound(string symbol, int volume)
        {
            MessageBox.Show("Vers D");
            MakeSound(symbol, volume);
        }

    }

}
