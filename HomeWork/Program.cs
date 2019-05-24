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
            Calculator.Operation[] someOperations =
                {
                new Calculator.SumOperation(1.5, 2.6),
                new Calculator.DivideOperation(6, 3),
                new Calculator.MultiplyOperation(2, 2),
                new Calculator.SubtractOperation(5, 3.8)
        };
            foreach (var operation in someOperations)
            {
                Console.WriteLine(operation.ToString());
            }
        }
    }
}
