using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseOperations.ConnectToDB();
            TimerTestTable TTT = new TimerTestTable();

            /*
            List<String> list = new List<String>();
            list.Add("Q3");
            list.Add("A3");
            list.Add("QType3");
            TTT.InsertRowIntoTable(TTT.TableName, list);
            */

            Timer timer = new Timer();
            timer.TimedMethod(TTT);


            Console.ReadKey();
        }
    }
}
