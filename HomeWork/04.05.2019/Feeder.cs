using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Feeder
    {
        public static void Feed(Mammal[] mammals)
        {
            foreach (var creature in mammals)
            {
                Console.WriteLine($"Enter the portions for the {creature.GetType().Name}:");
                creature.Eat(int.Parse(Console.ReadLine()));
                Console.WriteLine($"Current weight is {creature.Weight}");
            }
        }
    }
}
