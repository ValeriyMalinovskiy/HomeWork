using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class SumOperation : Operation
    {
        public override string Action { get; protected set; }
        public SumOperation(double num1, double num2)
        {
            this.Action = (num1 + num2).ToString();
        }
    }
}
