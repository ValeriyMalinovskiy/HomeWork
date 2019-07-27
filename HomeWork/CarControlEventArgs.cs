using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class CarControlEventArgs : EventArgs
    {
        public ConsoleKey KeyPressed { get; set; }
    }
}
