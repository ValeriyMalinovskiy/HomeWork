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
            Task7();
            Console.ReadKey();
        }
        static void Task1()
        {
            int x1 = int.MinValue;
            Console.WriteLine(x1);
        }
        static void Task2()
        {
            Console.WriteLine("Ваше имя?");
            string str1 = Console.ReadLine();
            string str2 = "Привет, " + str1;
            Console.WriteLine(str2);
        }
        static void Task3()
        {
            var v1 = 'v';
            v1 = 'a';
            Console.WriteLine(v1);
        }
        static void Task4()
        {
            Console.WriteLine("Введите длину стороны квадрата");
            string str = Console.ReadLine();
            int x1 = Int32.Parse(str);
            int perimetr = 4 * x1;
            Console.WriteLine(perimetr);
        }
        static void Task5()
        {
            Console.WriteLine("Введите радиус большого круга");
            double r1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите радиус маленького круга");
            double r2 = Int32.Parse(Console.ReadLine());
            const double Pi = 3.14;
            double s1 = Pi * r1 * r1;
            double s2 = Pi * r2 * r2;
            double s3 = s1 - s2;
            Console.WriteLine($"Площаль большого круга {s1}\n" +
                $"Площадь маленького круга {s2}\n" +
                $"Разность площадей {s3}");
        }
        static void Task6()
        {
            Console.WriteLine("введите двузначное число");
            int input = Int32.Parse(Console.ReadLine());
            int tihe = input / 10;
            int hundredth = input % 10;
            Console.WriteLine(hundredth.ToString() + tihe.ToString());
        }
        static void Task7()
        {
            int num1 = int.MaxValue;
            int num2 = int.MaxValue;
            long sum = (long)num1 + num2;
            Console.WriteLine(sum);
        }
    }
}
