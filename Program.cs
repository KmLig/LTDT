using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTuan01
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string file_path = Environment.CurrentDirectory;
            Console.WriteLine("Cau 1, VD 1");
            
            BTTuan01_Cau01 action01_1 = new BTTuan01_Cau01();
            action01_1.Cau1("input_BT01_1.txt");
            Console.WriteLine("===***===");
            Console.WriteLine("Cau 1, VD 2");
            BTTuan01_Cau01 action01_2 = new BTTuan01_Cau01();
            action01_2.Cau1("input_BT01_2.txt");
            Console.WriteLine("===***===");


            Console.WriteLine("Cau 2, VD 1");
            BTTuan01_Cau02 action02_1 = new BTTuan01_Cau02();
            action02_1.Cau2("input_BT02_1.txt");
            Console.WriteLine("===***===");
            Console.WriteLine("Cau 2, VD 2");
            BTTuan01_Cau02 action02_2 = new BTTuan01_Cau02();
            action02_2.Cau2("input_BT02_2.txt");
        }
    }
}
