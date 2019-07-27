using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{
    class GameLogic
    {
        Curb curb = new Curb();

        Printer printer = new Printer();
        
        public void StartGame()
        {
            Task print = new Task(() => printer.PrintEverything());
            print.Start();

            for (int i = 0; i < 10; i++)
            {
                curb.Move();
                printer.UpdateCurb(curb);
                Thread.Sleep(1000);
            }
        }
    }
}
