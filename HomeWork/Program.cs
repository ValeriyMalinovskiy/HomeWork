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
            Mammal[] mammals =
            {
                new Terrestrial(0), new Terrestrial(1),
                new Subterrenean(0), new Subterrenean(2),
                new Arial(0), new Arial(3), new Aquatic(0),
                new Aquatic(4), new Arboreal(0), new Arboreal(5)
            };
            HomeWork.Feeder.Feed(mammals);
        }
    }
}

