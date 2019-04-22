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
    }
}
