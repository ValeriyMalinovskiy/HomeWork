using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixLogic matrixLogic = new MatrixLogic();
            matrixLogic.RunPrinting();
        }
        //    Console.CursorVisible = false;
        //    Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
        //    object l = new object();
        //    List<MatrixString> matrixStrings = new List<MatrixString>();
        //    Thread stringCreationThread = new Thread(new ParameterizedThreadStart(CreateString));
        //    stringCreationThread.Start(matrixStrings);

        //    Thread.Sleep(1000);

        //    while (true)
        //    {
        //            for (int i = 0; i < matrixStrings.Count; i++)
        //            {
        //                if (!matrixStrings[i].CompletelyPrinted)
        //                {
        //                    matrixStrings[i].Trace();
        //                }
        //                else
        //                {
        //                    matrixStrings.RemoveAt(i);
        //                }
        //            }
        //    }
        //}

        //static void CreateString(object matrixStrings)
        //{
        //    List<MatrixString> list = (List<MatrixString>)matrixStrings;
        //    while (true)
        //    {
        //        if (list.Count < 20)
        //        {
        //            list.Add(new MatrixString(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 3));
        //            Thread.Sleep(400);
        //        }
        //    }
        //}
    }
}
