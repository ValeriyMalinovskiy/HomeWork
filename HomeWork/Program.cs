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
            Task2();
        }

        static void Task1()
        {
            SayHello.Human[] crowd =
            {
                new SayHello.Russian("Петя"),
                new SayHello.Ukrainian("Петро"),
                new SayHello.American("Peter")
                };
            foreach (var person in crowd)
            {
                person.SayHello();
            }
        }

        static void Task2()
        {
            Calculator.Calc calc = new Calculator.Calc();
            calc.ShowResults();
        }
    }
}
