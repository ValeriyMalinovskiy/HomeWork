using System.Linq;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            Task3();
        }

        static void Task1()
        {
            SayHello.Human[] crowd =
            {
                new SayHello.Russian("Петя"),
                new SayHello.Ukrainian("Петро"),
                new SayHello.American("Peter")
                };
            foreach (var person in crowd)
            {
                person.SayHello();
            }
        }

        static void Task2()
        {
            Calculator.Calc calc = new Calculator.Calc();
            calc.ShowResults();
        }

        static void Task3()
        {
            Animals.Animal[] arrAnimal = new Animals.Animal[8];
            arrAnimal[0] = new Animals.Dog { Name = "Шарик" };
            arrAnimal[1] = new Animals.Cat { Name = "Кусака" };
            arrAnimal[2] = new Animals.Cat { Name = "Ленивец" };
            arrAnimal[3] = new Animals.Lynx { Name = "Леснушка" };
            arrAnimal[4] = new Animals.Dog { Name = "Джек" };
            arrAnimal[5] = new Animals.Cat { Name = "Черныш" };
            arrAnimal[6] = new Animals.Dog { Name = "Арчи" };
            arrAnimal[7] = new Animals.Lynx { Name = "Рыська" };

            foreach (var creature in arrAnimal)
            {
                //creature.Bite();
                //if (creature is Animals.IPurr)
                //{
                //    ((Animals.IPurr)creature).Purr();
                //}
            }
        }
    }
}
