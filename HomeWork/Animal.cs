using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public abstract void Bite();
    }

    interface IPurr
    {
        void Purr();
    }

    public class Dog : Animal
    {
        public override void Bite()
        {
            Console.WriteLine("Собака {0} кусает", this.Name);
        }
    }

    public class Cat : Animal, IPurr
    {
        public override void Bite()
        {
            Console.WriteLine("Кошка {0} кусает", this.Name);
        }

        public void Purr()
        {
            Console.WriteLine("Кошка {0} мурчит", this.Name);
        }
    }

    public class Lynx : Animal, IPurr
    {
        public override void Bite()
        {
            Console.WriteLine("Рысь {0} кусает", this.Name);
        }

        public void Purr()
        {
            Console.WriteLine("Рысь {0} мурчит", this.Name);
        }
    }
}
