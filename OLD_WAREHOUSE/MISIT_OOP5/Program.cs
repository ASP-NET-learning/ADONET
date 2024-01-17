using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 談多型 
namespace MISIT_OOP5
{
    public class Programmer
    {
        //// 徵人啟事 : 軟體工程師
        //public string WriteCSharp()
        //{
        //    return "努力寫C#";
        //}
        //public string WriteSQL()
        //{
        //    return "努力寫SQL";
        //}
        //public string WriteVB()
        //{
        //    return "努力寫VB";
        //}

        //public class DesignPattern
        //{
        //    public string codeName;

        //    public DesignPattern(string codeName)
        //    {
        //        this.codeName = codeName;
        //    }
        //}

        ////猴子來面試了
        //public class monkey : Programmer
        //{
        //    public string WriteCSharp()
        //    {
        //        return "ShitCode";
        //    }
        //    public string WriteSQL()
        //    {
        //        return "ShitCode";
        //    }
        //    public string WriteVB()
        //    {
        //        return "ShitCode";
        //    }
        //}

        ////大神來面試了 不只會以上還會設計模式中的工廠模式
        //public class god : Programmer
        //{
        //    public string WriteCSharp()
        //    {
        //        return "CleanCode";
        //    }
        //    public string WriteSQL()
        //    {
        //        return "CleanCode";
        //    }
        //    public string WriteVB()
        //    {
        //        return "CleanCode";
        //    }
        //    public DesignPattern MakeFactory()
        //    {
        //        return new DesignPattern(codeName: "Factory");
        //    }
        //}

        //// 上工了!
        //public void Work()
        //{
        //    Programmer programmer = new god();
        //    Console.WriteLine(programmer.WriteCSharp());
        //    programmer.WriteCSharp();
        //    programmer.WriteSQL();
        //    programmer.WriteVB();
        //}

        ////大神跟猴子寫同個專案
        //public void newProject()
        //{
        //    Programmer programmer001 = new god();
        //    Programmer programmer002 = new monkey();

        //    Console.WriteLine(programmer001.WriteCSharp());
        //    programmer001.WriteCSharp(); // "CleanCode" 
        //    programmer002.WriteCSharp(); // "ShitCode"

        //    programmer001.WriteSQL(); // "CleanCode" 
        //    programmer002.WriteSQL(); // "ShitCode"
        //}
        public virtual string WriteCSharp()
        {
            return "努力寫C#";
        }
        public virtual string WriteSQL()
        {
            return "努力寫SQL";
        }
        public virtual string WriteVB()
        {
            return "努力寫VB";
        }

        public class DesignPattern
        {
            public string CodeName { get; }

            public DesignPattern(string codeName)
            {
                CodeName = codeName;
            }
        }

        // 猴子來面試了
        public class Monkey : Programmer
        {
            public override string WriteCSharp()
            {
                return "ShitCode";
            }
            public override string WriteSQL()
            {
                return "ShitCode";
            }
            public override string WriteVB()
            {
                return "ShitCode";
            }
        }

        // 大神來面試了 不只會以上還會設計模式中的工廠模式
        public class God : Programmer
        {
            public override string WriteCSharp()
            {
                return "God CleanCode C#";
            }
            public override string WriteSQL()
            {
                return "God CleanCode SQL";
            }
            public override string WriteVB()
            {   
                return "God CleanCode VB";
            }
            public DesignPattern MakeFactory(string codeName)
            {
                Console.WriteLine($"Creating a Factory with CodeName: {codeName}");
                return new DesignPattern(codeName);

            }
        }

        // 上工了!
        public void Work()
        {
            Programmer programmer = new God();
            God godInstance = new God();

            Console.WriteLine(programmer.WriteCSharp());
            Console.WriteLine(programmer.WriteSQL());
            Console.WriteLine(programmer.WriteVB());
            DesignPattern factory = godInstance.MakeFactory("God Code");
            Console.WriteLine($"Factory created with CodeName: {factory.CodeName}");

        }

        // 大神跟猴子寫同個專案
        public void NewProject()
        {
            Programmer programmer001 = new God();
            Programmer programmer002 = new Monkey();

            Console.WriteLine(programmer001.WriteCSharp()); // "CleanCode" 
            Console.WriteLine(programmer002.WriteCSharp()); // "ShitCode"

            Console.WriteLine(programmer001.WriteSQL()); // "CleanCode" 
            Console.WriteLine(programmer002.WriteSQL()); // "ShitCode"
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //一樣的事，不同做法 → 繼承了同一個物件，實現這個行為的方式也可以不同
            //狗跟鳥都是繼承自動物這個類別，但對於「移動」這個方法，他們實作的方式並不一樣。
            Programmer p = new Programmer();
            p.Work();
            p.NewProject();
        }
    }
}
