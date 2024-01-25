using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0125_DDL
{
    public class CToolBox
    {
        public string DisplayTime()
        {
            return DateTime.Now.ToString();
        }

        public int Add(int x, int y)
        { return x + y; }
    }
}
