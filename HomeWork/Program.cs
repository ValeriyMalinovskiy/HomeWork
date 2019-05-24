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
            Human[] crowd =
            {
                new Russian("Петя"),
                new Ukrainian("Петро"),
                new American("Peter")
            };
            foreach (var person in crowd)
            {
                person.SayHello();
            }
        }
    }
}
