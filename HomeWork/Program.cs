﻿using System;
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

            Task2();

            Console.ReadKey();
        }

        static void Task1()
        {
            string inputStr = Console.ReadLine();
            string[] inputArrStr= inputStr.Split(' ');
            bool toZero = true;

            int[] arr = new int[inputArrStr.Length]; // Array to store entered numbers
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(inputArrStr[i]);
            }

            long convertedVal = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (toZero)
                {
                    convertedVal *= ToOnesAndZeros(arr[i]).Item1;
                }
                else
                {
                    convertedVal *= ToOnesAndZeros(arr[i]).Item1;
                    convertedVal += ToOnesAndZeros(arr[i]).Item2;
                }
                toZero = !toZero;
            }
            Console.WriteLine(convertedVal);
            string result = convertedVal.ToString().Substring(1); // exclude the first digit to represent multiple zeros first.
            Console.WriteLine(result);
        }

        static (int,int) ToOnesAndZeros(int value) // Takes single number, returns ONEs (111...) and ZEROs (100...)
        {
            int zeros = 1;
            decimal ones = 0.11111111111111111m;
            for(int i=value; i>0;i--)
            {
                zeros *= 10;
                ones *= 10;
            }
            return (zeros,(int)ones);
        }

        private static int ChosenItem()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        return 0;
                    }
                case "2":
                    {
                        return 1;
                    }
                case "3":
                    {
                        return 2;
                    }
                case "4":
                    {
                        return 3;
                    }
                case "5":
                    {
                        return 4;
                    }
                case "6":
                    {
                        return 5;
                    }
                case "7":
                    {
                        return 6;
                    }
                case "8":
                    {
                        return 7;
                    }
                case "9":
                    {
                        return 8;
                    }
                case "10":
                    {
                        return 9;
                    }
            }
            return 10;
        }

        static void Task2()
        {
            string[] grocery = {"Pears","Apples","Cucumbers","Tomatos","Dill",
                "Parsley","Chiken","Cheese","Butter","Milk"};
            double[] priceList = { 40.50, 31.20, 21.80, 35.00, 150.00, 145.00,
                200.00 , 400.00 , 81.40, 53.35};
            Console.WriteLine();
            bool timeToPay = false;
            int userChoice;
            double currentSum = 0;
            double currentItemsPrice;
            double amount = 0;
            while(!timeToPay)
            {
                Console.Clear();
                Console.Write(
                    $"1\t{grocery[0]}\t\t{priceList[0]} UAH\n" +
                    $"2\t{grocery[1]}\t\t{priceList[1]} UAH\n" +
                    $"3\t{grocery[2]}\t{priceList[2]} UAH\n" +
                    $"4\t{grocery[3]}\t\t{priceList[3]} UAH\n" +
                    $"5\t{grocery[4]}\t\t{priceList[4]} UAH\n" +
                    $"6\t{grocery[5]}\t\t{priceList[5]} UAH\n" +
                    $"7\t{grocery[6]}\t\t{priceList[6]} UAH\n" +
                    $"8\t{grocery[7]}\t\t{priceList[7]} UAH\n" +
                    $"9\t{grocery[8]}\t\t{priceList[8]} UAH\n" +
                    $"10\t{grocery[9]}\t\t{priceList[9]} UAH\n" +
                    "0\tProceed\n");
                userChoice = ChosenItem();
                if (userChoice == 10)
                    timeToPay = true;
                else
                {
                    currentItemsPrice = priceList[userChoice];
                    Console.WriteLine("How much?");
                    amount = double.Parse(Console.ReadLine());
                    currentSum += currentItemsPrice * amount;
                }
            }
            Console.WriteLine($"Please pay {currentSum} UAH");
        }
    }
}
