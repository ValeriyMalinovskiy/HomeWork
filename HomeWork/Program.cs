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
            Task1();

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
    }
}
