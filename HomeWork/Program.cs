using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Task3();
            Console.ReadKey();
        }
        static void Task1()
        {
            int x1 = int.MinValue;
            Console.WriteLine(x1);
        }
        static void Task2()
        {
            Console.WriteLine("Ваше имя?");
            string str1 = Console.ReadLine();
            string str2 = "Привет, " + str1;
            Console.WriteLine(str2);
        }
        static void Task3()
        {
            var v1 = 'v';
            v1 = 'a';
            Console.WriteLine(v1);
        }
    }
}
