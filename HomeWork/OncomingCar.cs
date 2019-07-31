using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class OncomingCar
    {
        public (int, int)[] Coordinates { get; private set; }

        public OncomingCar(CarPosition carPosition)
        {
            switch (carPosition)
            {
                case CarPosition.Left:
                    {
                        this.Coordinates = new (int, int)[7];
                        this.Coordinates[0].Item1 = 2;
                        this.Coordinates[0].Item2 = -1;
                        this.Coordinates[1].Item1 = 4;
                        this.Coordinates[1].Item2 = -1;
                        this.Coordinates[2].Item1 = 3;
                        this.Coordinates[2].Item2 = -2;
                        this.Coordinates[3].Item1 = 2;
                        this.Coordinates[3].Item2 = -3;
                        this.Coordinates[4].Item1 = 3;
                        this.Coordinates[4].Item2 = -3;
                        this.Coordinates[5].Item1 = 4;
                        this.Coordinates[5].Item2 = -3;
                        this.Coordinates[6].Item1 = 3;
                        this.Coordinates[6].Item2 = -4;
                    }
                    break;
                case CarPosition.Right:
                    {
                        this.Coordinates = new (int, int)[7];
                        this.Coordinates[0].Item1 = 5;
                        this.Coordinates[0].Item2 = -1;
                        this.Coordinates[1].Item1 = 7;
                        this.Coordinates[1].Item2 = -1;
                        this.Coordinates[2].Item1 = 6;
                        this.Coordinates[2].Item2 = -2;
                        this.Coordinates[3].Item1 = 5;
                        this.Coordinates[3].Item2 = -3;
                        this.Coordinates[4].Item1 = 6;
                        this.Coordinates[4].Item2 = -3;
                        this.Coordinates[5].Item1 = 7;
                        this.Coordinates[5].Item2 = -3;
                        this.Coordinates[6].Item1 = 6;
                        this.Coordinates[6].Item2 = -4;
                    }
                    break;
            }
        }

        public void Move()
        {
            for (int i = 0; i < this.Coordinates.Length; i++)
            {
                this.Coordinates[i].Item2++;
            }
        }
    }
}
