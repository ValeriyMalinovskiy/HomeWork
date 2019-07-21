using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{
    class MatrixString
    {
        public bool CompletelyPrinted { get; private set; }

        private (int, int)[] Locations { get; set; }

        public MatrixString(int consoleWidth, int consoleHeight)
        {
            Random rnd = new Random();
            int verticalPosition = rnd.Next(0, consoleWidth);
            this.CompletelyPrinted = false;
            this.Locations = new (int, int)[rnd.Next(3, consoleHeight)];
            for (int i = 0; i < this.Locations.Length; i++)
            {
                this.Locations[i].Item1 = verticalPosition;
                this.Locations[i].Item2 = -i - 1;
            }
        }

        public void Trace()
        {
            Random rdn = new Random();
            for (int i = 0; i < this.Locations.Length; i++)
            {
                this.Locations[i].Item2++;
                if ((this.Locations[i].Item2 >= 0) && this.Locations[i].Item2 < Console.LargestWindowHeight / 2)
                {
                    Console.SetCursorPosition(this.Locations[i].Item1, this.Locations[i].Item2);
                    switch (i)
                    {
                        case 0:
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case 1:
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            break;
                        default:
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            break;
                    }
                    Console.Write((char)rdn.Next(33, 127));
                }
            }
            if ((this.Locations[this.Locations.Length - 1].Item2 > 0) && (this.Locations[this.Locations.Length - 1].Item2 <= Console.LargestWindowHeight / 2))
            {
                Console.SetCursorPosition(this.Locations[this.Locations.Length - 1].Item1, this.Locations[this.Locations.Length - 1].Item2-1);
                Console.Write(" ");
            }
            if (this.Locations[Locations.Length - 1].Item2 == Console.LargestWindowHeight / 2)
            {
                this.CompletelyPrinted = true;
            }
            Thread.Sleep(10);
        }
    }
}
