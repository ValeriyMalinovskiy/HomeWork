using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    abstract internal class Human
    {
        public string Name { get; set; }

        public Human(string name)
        {
            this.Name = name;
        }

        public virtual void SayHello()
        {
        }
    }
}
