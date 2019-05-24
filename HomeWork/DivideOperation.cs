using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class DivideOperation : Operation
    {
        public override string Action { get; protected set; }
        public DivideOperation(double num1, double num2)
        {
            this.Action = Math.Round(num1 / num2, 2).ToString();
        }
    }
}
