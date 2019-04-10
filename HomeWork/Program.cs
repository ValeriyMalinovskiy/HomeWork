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

            Task3();

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
    }
}
