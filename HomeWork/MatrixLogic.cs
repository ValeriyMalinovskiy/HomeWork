using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{
    class MatrixLogic
    {
        private List<MatrixString> matrixStrings;

        public void RunPrinting()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
            matrixStrings = new List<MatrixString>();
            Thread stringCreationThread = new Thread(new ThreadStart(CreateString));
            stringCreationThread.Start();
            Thread.Sleep(1000);

            while (true)
            {
                for (int i = 0; i < matrixStrings.Count; i++)
                {
                    lock (matrixStrings)
                    {
                        if (!matrixStrings[i].CompletelyPrinted)
                        {
                            matrixStrings[i].Trace();
                        }
                        else
                        {
                            matrixStrings.RemoveAt(i);
                        }
                    }
                }
            }
        }

        private void CreateString()
        {
            while (true)
            {
                if (matrixStrings.Count < 30)
                {
                    matrixStrings.Add(new MatrixString(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 3));
                    Thread.Sleep(10);
                }
            }
        }
    }
}

