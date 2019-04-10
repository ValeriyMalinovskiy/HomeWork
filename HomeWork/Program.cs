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
            //Task1();

            //Task2();

            //Task3();

            //Task4();

            //Task5();

            //Task6();

            //Task7();

            Task8();

            Console.ReadKey();
        }

        static void Task1()
        {
            int input = Int32.Parse(Console.ReadLine());
            int factorial = 1;
            while (input > 0)
            {
                factorial *= input;
                input--;
            }
            Console.WriteLine(factorial);
        }

        static void Task2()
        {
            Console.WriteLine("1-line\n2-rectangle\n3-right triangle" +
                "\n4-equilateral triangle\n5-rhombus");
            string figureNumber = Console.ReadLine();
            Console.WriteLine("Enter the size");
            int size = Int32.Parse(Console.ReadLine());
            bool isFilled=false;
            if (figureNumber != "1")
            {
                Console.WriteLine("Filling - y/n");
                if (Console.ReadLine() == "y") isFilled = true;
            }
            Console.Clear();
            switch (figureNumber)
            {
                case "1":
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write('*');
                    }
                    break;
                case "2":
                    {
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                if ((isFilled) || ((i == 0) || (i == size - 1)) 
                                    || (j == 0) || (j == size - 1))
                                    Console.Write('*');
                                else Console.Write(' ');
                            }
                            Console.Write("\n");
                        }
                    }
                    break;
                case "3":
                    {
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j <= i; j++)
                            {
                                if ((isFilled) || (j == 0) || (i == size-1) || (i == j))
                                    Console.Write("* ");
                                else Console.Write("  ");
                            }
                            Console.Write("\n");
                        }
                    }
                    break;
                case "4":
                    {
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j <= i; j++)
                            {
                                Console.SetCursorPosition(size + j, i);
                                if ((isFilled) || (i == j))
                                    Console.Write("*");
                                else Console.Write(" ");
                                Console.SetCursorPosition(size - j, i);
                                if ((isFilled) || (i == j))
                                    Console.Write("*");
                                else Console.Write(" ");
                                if((!isFilled) && (i == size - 1))
                                {
                                    for (int k = 1; k < 2*size-2; k++)
                                    {
                                        if (k % 2 == 0) Console.Write("*");
                                        else Console.Write(" ");
                                    }
                                }
                            }
                            Console.Write("\n");
                        }
                    }
                    break;
                case "5":
                    {
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j <= i; j++)
                            {
                                Console.SetCursorPosition(size + j, i);
                                if ((isFilled)|| (i == j))
                                    Console.Write("*");
                                else Console.Write(" ");
                                Console.SetCursorPosition(size - j, i);
                                if ((isFilled) || (i == j))
                                    Console.Write("*");
                                else Console.Write(" ");
                                Console.SetCursorPosition(size - j, 2*size - i-2);
                                if ((isFilled) || (i == j))
                                    Console.Write("*");
                                else Console.Write(" ");
                                Console.SetCursorPosition(size + j, 2*size - i-2);
                                if ((isFilled) || (i == j))
                                    Console.Write("*");
                                else Console.Write(" ");
                            }
                            Console.Write("\n");
                        }
                    }
                    break;
            }
        }

        static void Task3()
        {
            int inputNum = Int32.Parse(Console.ReadLine());
            Console.WriteLine((inputNum > 0) ? "The number is positive":
                "The number is negative");
            int divCounter=0;
            for (int i = inputNum; i >0; i--)
            {
                if(inputNum%i==0)
                {
                    Console.WriteLine("Can be divided by " + i);
                    divCounter++;
                }
            }
            Console.WriteLine((divCounter > 2) ? "Entered number is not simple" : "Entered number is simple");
        }

        static void Task4()
        {
            Console.WriteLine("Enter the number of clients");
            int clientsNum = Int32.Parse(Console.ReadLine());
            int possibleRoutes = 1;
            do
            {
                possibleRoutes *= clientsNum;
                clientsNum--;
            }
            while (clientsNum > 1);
            Console.WriteLine($"Goods can be delivered in {possibleRoutes} way(s)");
        }

        static void Task5()
        {
            int numA = Int32.Parse(Console.ReadLine());
            int numB = Int32.Parse(Console.ReadLine());
            int sum = 0;
            if (numA > numB)
            {
                int tempNum = numA;
                numA = numB;
                numB = tempNum;
            }
            for (int i = numA+1; i < numB; i++)
            {
                sum += i;
                if (i % 2 == 0) Console.WriteLine($"Even intermediate number: {i}");
            }
            Console.WriteLine($"Sum: {sum}");
        }

        static void Task6()
        {
            int inputNum = Int32.Parse(Console.ReadLine());
            int evenDigCounter = 0;
            do
            {
                if (inputNum % 2 == 0) evenDigCounter++;
                inputNum /= 10;
            }
            while(inputNum!=0);
            Console.WriteLine($"The number contains {evenDigCounter} even digits");
        }

        static void Task7()
        {
            double numA = Double.Parse(Console.ReadLine());
            double numB = Double.Parse(Console.ReadLine());
            double sum = 0;
            int counter = 0;
            if (numA > numB)
            {
                double tempNum = numA;
                numA = numB;
                numB = tempNum;
            }
            for (double i = numA; i <= numB; i++)
            {
                sum += i;
                counter++;
            }
            Console.WriteLine($"The average of the entered number range is {sum / counter}");

        }

        static void Task8()
        {
            double distancePerDay = 10;
            double totalDistance = 0;
            int day = 1;
            do
            {
                distancePerDay *= 1.1;
                totalDistance += distancePerDay;
                day++;
            }
            while (totalDistance < 100);

            Console.WriteLine("By the {0} day skier covers {1} kms", day, totalDistance);
        }
    }
}
