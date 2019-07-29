using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class CarControlEventArgs : EventArgs
    {
        public ConsoleKey keyPressed { get; private set; }

        public CarControlEventArgs()
        {
            this.keyPressed = Console.ReadKey().Key;
        }
    }
}
