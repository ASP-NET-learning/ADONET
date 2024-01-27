﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0126_CloseForm
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
            // C. Assign EventHander
            //obj.WeightTooLow += obj_WeightTooLow;
            // C. 指定事件的事件處理函式 (Tab 兩次)
            obj.WeightError += obj_WeightError;
            obj.Weight = 100;
            obj.Weight = -1;
            button1.Text = obj.Weight.ToString();
            // this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = checkBox1.Checked;
        }

        void obj_WeightError(object sender, WeightEventArgs e)
        {
            // MessageBox.Show(e.WeightValue.ToString());
            e.WeightValue = 50;
            e.Handled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

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

    public delegate void WeightEventHandler(Object sender, WeightEventArgs e);

    public class CAnimal
    {

        private int _Weight = 0;


        // A. 宣告事件
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
                        WeightEventArgs e = new WeightEventArgs("Weight too low", value);
                        this.WeightError.Invoke(this, e);
                        if (e.Handled)
                            _Weight = e.WeightValue;
                    }
                }
            }
        }

    }

}
