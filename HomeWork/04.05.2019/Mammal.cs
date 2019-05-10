using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Mammal
    {
        private int age;
        
        private double weight;

        public int Age
        {
            get
            {
                return age;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
        }

        public Mammal(int age)
        {
            this.age = age;
        }

        public void Eat(int foodAmount)
        {
            if (this.Age<1)
            {
                Console.WriteLine($"The {this.GetType().Name} is younger than a year. It drinks milk");
            }
            else
            {
                Console.WriteLine($"The {this.GetType().Name} eats any food");
            }
            this.weight += (double)foodAmount / 5;
        }
    }
}
