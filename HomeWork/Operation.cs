using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    abstract class Operation
    {
        public virtual string Action { get; protected set; }

        public override string ToString()
        {
            return $"Calculation is being performed with: {this.GetType().Name}\tResult: {this.Action}";
        }
    }
}
