using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayHello
{
    class American : Human
    {
        public American(string name) : base(name)
        {

        }

        public override void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
