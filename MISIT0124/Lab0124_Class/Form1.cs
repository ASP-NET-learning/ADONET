using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0124_Class
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CAnimal obj = new CAnimal();
            button1.Text = $"Weight: {obj.Weight}, Location: {obj.Location}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CAnimal obj = new CAnimal();
            obj.NameList.Add("fisrtName", "Jeremy");
            obj.NameList["lastName"] = "Lin";
            button2.Text = obj.NameList["lastName"].ToString();
            // button2.Text = obj.NameList.Count.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CAnimal obj = new CAnimal();
            obj.AddValueToDataList("ABA");
            button3.Text = obj[0];
        }
    }
    class CAnimal
    {
        
        //把資料公開
        public void AddValueToDataList(string s)
        {
            this._dataList.Add(s);
        }

        // 封裝List的方法
        private List<string> _dataList = new List<string>();
        public string this[int index] 
        {
            get { return _dataList[index]; }
            set { _dataList[index] = value; }
        }

        private Hashtable _nameList = new Hashtable();

        public Hashtable NameList 
        {
            // 不需要SET 因為有可能被從外部竄改
            get
            {
                return this._nameList;
            }
        }


        // overloading 
        public CAnimal()
        {
            this.Init(1, "Earth");
        }

        public CAnimal(int weightValue, string locationValue)
        {
            this.Init(weightValue, locationValue);
        }

        //重用function
        private void Init(int weightValue, string locationValue)
        {
            this.Weight = weightValue;
            this.Location = locationValue;
        }


        private int _Weight;

        public int Weight
        {
            get
            {
                return this._Weight;
            }
            set
            {
                if (value > 0)
                {
                    this._Weight = value;
                }
            }
        }

        public string Location { set; get; }

        public int getWeight()
        {
            return this._Weight;
        }
        public void setWeight(int value)
        {
            if (value > 0)
            {
                this._Weight = value;
            }
        }

        public void MakeSound()
        {
            MakeSound(3, ".");
        }

        public void MakeSound(int volume)
        {
            MakeSound(volume, ".");
        }

        public void MakeSound(string symbol, int volume)
        {
            MakeSound(volume, symbol);
        }

        public void MakeSound(int volume, string symbol)
        {
            string result = "Animal: ";
            for (int i = 1; i <= volume; i++)
            {
                result += symbol;
            }
            MessageBox.Show(result, "Hint");
        }

    }

}
