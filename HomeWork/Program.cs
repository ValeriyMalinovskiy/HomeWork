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
            string str = "How can mirrors be real if our eyes aren't real";
            StringBuilder sb = new StringBuilder();
            for (int i= 0; i<str.Length;i++)
            {
                if ((i==0)||(str[i-1]==' '))
                {
                    sb.Append(str[i].ToString().ToUpper());
                }
                else
                sb.Append(str[i]);
            }
            Console.WriteLine(sb);
        }

        static void Task2()
        {
            string str1 = "aaaaaaaaaaaaaabbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz";
            string str2 = "aaaxbbbbyyhwawiwjjjwwm";
            Console.WriteLine(PrinterError(str2));

        }

        static string PrinterError(string str)
        {
            int errorCount = 0;
            bool isMatched = false;
            for (int i = 0; i < str.Length; i++)
            {

                for (int j= 110; j < 123; j++)
                {
                    if (str[i] == (char)j)
                    {
                        isMatched = true;
                    }
                }
                if (isMatched)
                {
                    errorCount++;
                }
                isMatched = false;
            }
            return (errorCount.ToString() + "/" + str.Length.ToString());
        }

        static void Task3()
        {
            string str = "abracadabra";
            string vowels = "aeiou";
            int vowel = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (str[i]==vowels[j])
                    {
                        vowel++;
                    }
                }
            }
            Console.WriteLine(vowel);
        }
    }
}
