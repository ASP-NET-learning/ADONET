using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0126_InterFace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void drive(IDrive x)
        {
            x.AddSpeed(10);
            x.AddSpeed(10);
            MessageBox.Show(x.Speed.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Car Carobj = new Car();
            drive(Carobj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.MakeTea();
            drive(game);
        }
    }
    public interface IDrive
    {

        int Speed { get; }
        void AddSpeed(int amount);
    }

    class Car : IDrive
    {
        private int _Speed = 0;

        public int Speed
        {
            get
            {
                return this._Speed;
            }
        }

        public void AddSpeed(int amount)
        {
            this._Speed += amount;
        }
    }

    class SoftWare
    {
    }

    class Game : SoftWare, IDrive
    {

        private int _Speed = 0;

        public int Speed
        {
            get
            {
                return this._Speed;
            }
        }

        public void AddSpeed(int amount)
        {
            this._Speed += amount * 10;
        }
        public void MakeTea() 
        {
            MessageBox.Show("開車泡奶茶");
        }
    }





}
