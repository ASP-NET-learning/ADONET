using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0129_Event
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
            obj.WeightError += obj_WeightError;
            //obj.Weight = 100;
            //obj.Weight = -999;
            obj.Weight = Convert.ToInt32(textBox1.Text);
            button1.Text = obj.Weight.ToString();

            obj.WeightError += obj_TesteError;
            obj.Weight = Convert.ToInt32(textBox1.Text);
            button1.Text = obj.Weight.ToString();

        }
        void obj_WeightError(object sender, WeightEventArgs e)
        {
            MessageBox.Show(e.WeightValue.ToString());
            e.WeightValue = 50;
            e.Handled = true;
        }

        void obj_TesteError(object sender, WeightEventArgs e)
        {
            e.WeightValue = 100;
            e.Handled = true;
        }
    }

    //宣告事件 說清楚事件長如何
    public class WeightEventArgs : EventArgs
    {
        public string Reason;
        public int WeightValue;
        public bool Handled;

        public WeightEventArgs()
        {
            Reason = "";
            WeightValue = 0;
            Handled = false;
        }

        public WeightEventArgs(string why, int value)
        {
            Reason = why;
            WeightValue = value;
            Handled = false;
        }
    } 

    //委派一個事件
    public delegate void WeightEventHandler(Object sender, WeightEventArgs e);

    public class CAnimal
    {

        private int _Weight = 0;


        // A. 宣告事件 重量輸入錯誤
        public event WeightEventHandler WeightError;
        // public event EventHandler WeightTooLow;

        public int Weight
        {
            get
            {
                return _Weight;
            }

            set
            {
                if (value > 0)
                    _Weight = value;
                else
                {
                    // B. 呼叫 Client 端的事件處理函式
                    // Invoke event (raise an event), calling EventHander
                    if (this.WeightError != null)
                    {
                        //事件相關資訊回傳給客戶端
                        WeightEventArgs e = new WeightEventArgs("Weight too low", value);
                        this.WeightError.Invoke(this, e);
                        if (e.Handled && e.WeightValue > 0) //用戶端有修正資料
                            _Weight = e.WeightValue;
                            
                    }
                }
            }
        }

    }
}
