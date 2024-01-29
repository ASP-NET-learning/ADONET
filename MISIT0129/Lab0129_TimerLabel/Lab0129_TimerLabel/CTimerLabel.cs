using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0129_TimerLabel
{
    public partial class CTimerLabel: UserControl
    {

        public CTimerLabel()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToString();
        }

        private void CTimerLabel_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = DateTime.Now.ToString();
            DateTime current = DateTime.Now;
            label1.Text = current.ToString();
            if(this.AtTime != null) 
            {
                this.AtTime.Invoke(current.ToString());
            }
        }

        public void StopStart()
        {
            this.timer1.Enabled = !this.timer1.Enabled;
        }

        public delegate void TAtTime(string current);
        public event TAtTime AtTime;
        public int TimeInterval
        {
            get {  return this.timer1.Interval; }
            set { this.timer1.Interval = value;}
        }


    }
}
