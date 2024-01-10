using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MISIT_ADONET0108
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


    }
}

/*
 Data Source=TAKODACHI;       → Server
 Initial Catalog=Northwind;   → DataBase
 Persist Security Info=True;  → 安全性設定
 User ID=tako1;               → 使用者ID
 Password=takodachi885;       →  密碼
 TrustServerCertificate=True  → 是否信任
 */