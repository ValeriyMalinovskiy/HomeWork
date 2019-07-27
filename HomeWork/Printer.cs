﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{
    class Printer
    {
        private Curb curb;

        public void UpdateCurb(Curb curb)
        {
            this.curb = curb;
        }

        public void PrintEverything()
        {
            Console.CursorVisible = false;
            while (true)
            {
                //
                //curb
                //
                foreach (var item in curb.Coordinates)
                {
                    Console.SetCursorPosition(item.Item1 * 2, item.Item2);
                    if (item.Item3)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
        }



    }
}
