using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0125_DLL
{
    public class CToolBox
    {
        public string DisPlay()
        {
            return DateTime.Now.ToString();
        }

        public int Sum(int upper)
        {
            int result = 0;
            for (int i = 0; i <= upper; i++) 
            {
                result+= i;
            }
            return result;
        }
    }
}
// 夾殺法 : 縮小範圍 設定兩個中斷一個正確一個錯 程式錯在AB中間