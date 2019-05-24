using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class SubtractOperation : Operation
    {
        public override string Action { get; protected set; }
        public SubtractOperation(double num1, double num2)
        {
            this.Action = (num1 - num2).ToString();
        }
    }
}
