using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calc
    {
        Calculator.Operation[] someOperations =
        {
                new Calculator.SumOperation(1.5, 2.6),
                new Calculator.DivideOperation(6, 3),
                new Calculator.MultiplyOperation(2, 2),
                new Calculator.SubtractOperation(5, 3.8)
        };
        public void ShowResults()
        {
            foreach (var operation in someOperations)
            {
                Console.WriteLine(operation.ToString());
            }
        }
    }
}

