using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 
 通常我們的function，傳的參數不外乎是物件，像string、int，或我們自己撰寫的類別實體。
但某些時候，在function內需要動態的透過其他function來完成完全不一樣的事情，我們可以有兩種寫法
：在function內用一堆if判斷，透過識別參數在不同的if區塊完成各自的動作；
另一則是利用委派，所有功能放在同一function內，而獨立處理的功能則當成參數傳遞進去。

一的好處是程式好寫，但缺點就是當各自要做的事很複雜時，
程式碼會變得太長；而要增加新功能時，又要再多很多if，久了就很難維護。
 */
namespace Lab0119_FuntionToFuntion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Add(int x, int unit)
        { return x + unit; }

        int Add10(int x, int increment) 
        { return x + increment * 12; }

        int rectangle(int w, int h)
        {  return w*h; }

        //將副程式視為物件 描述具體物件 統一標準 ex: 手跟關節提供靈活彈性 
        //委派將事情搞清楚
        delegate int AddDelegate(int x, int unit);
        delegate int Area(int w, int h);

        private void button1_Click(object sender, EventArgs e)
        {
            int answer = Add(3, 5);
            button1.Text = answer.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 造一個委派事件p去委派某個函式去工作
            //AddDelegate p = new AddDelegate(Add10);造代理人去工作 
            //int answer = p.Invoke(100, 1); 去工作 : 工作格式已在delegate做好 
            //button2.Text = answer.ToString();
            /*https://hackmd.io/@BKLiang/csharp_delegate_event*/

            //AddDelegate p = Add; p 是委派人
            AddDelegate p = Add10;
            int answer = p(100, 1); 
            button2.Text = answer.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Area a =  rectangle;
            int result = a(10, 10);
            //string b = a("aaa", "bbb");
            int c = rectangle(10, 10);
            button3.Text = result.ToString();
        }
    }
}
