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
            Task1();

            Console.ReadKey();
        }

        static void Task1()
        {
            int input = Int32.Parse(Console.ReadLine());
            int factorial = 1;
            while (input > 0)
            {
                factorial *= input;
                input--;
            }
            Console.WriteLine(factorial);
        }
    }
}
