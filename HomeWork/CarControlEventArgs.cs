using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class CarControlEventArgs : EventArgs
    {
        public (int, int)[] CarCoord { get; private set; }

        public CarControlEventArgs((int,int)[] carCoord)
        {
            this.CarCoord = carCoord;
        }
    }
}
