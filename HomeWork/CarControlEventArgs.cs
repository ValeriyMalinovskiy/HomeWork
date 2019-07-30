using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class CarControlEventArgs : EventArgs
    {
        public CarPosition _CarPosition { get; set; }

        public CarControlEventArgs(CarPosition carPosition)
        {
            this._CarPosition = carPosition;
        }
    }
}
