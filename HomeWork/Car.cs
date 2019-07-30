using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Car
    {
        public (int, int)[] Coordinates { get; private set; }

        public Car()
        {
            this.Coordinates = new (int, int)[7];
            this.Coordinates[0].Item1 = 2;
            this.Coordinates[0].Item2 = 19;
            this.Coordinates[1].Item1 = 4;
            this.Coordinates[1].Item2 = 19;
            this.Coordinates[2].Item1 = 3;
            this.Coordinates[2].Item2 = 18;
            this.Coordinates[3].Item1 = 2;
            this.Coordinates[3].Item2 = 17;
            this.Coordinates[4].Item1 = 3;
            this.Coordinates[4].Item2 = 17;
            this.Coordinates[5].Item1 = 4;
            this.Coordinates[5].Item2 = 17;
            this.Coordinates[6].Item1 = 3;
            this.Coordinates[6].Item2 = 16;
        }

        public void Shift(CarPosition carPosition)
        {
            switch (carPosition)
            {
                case CarPosition.Left:
                    this.Coordinates[0].Item1 -= 3;
                    this.Coordinates[1].Item1 -= 3;
                    this.Coordinates[2].Item1 -= 3;
                    this.Coordinates[3].Item1 -= 3;
                    this.Coordinates[4].Item1 -= 3;
                    this.Coordinates[5].Item1 -= 3;
                    this.Coordinates[6].Item1 -= 3;
                    break;
                case CarPosition.Right:
                    this.Coordinates[0].Item1 += 3;
                    this.Coordinates[1].Item1 += 3;
                    this.Coordinates[2].Item1 += 3;
                    this.Coordinates[3].Item1 += 3;
                    this.Coordinates[4].Item1 += 3;
                    this.Coordinates[5].Item1 += 3;
                    this.Coordinates[6].Item1 += 3;
                    break;
            }
        }
    }
}
