using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Curb
    {
        public (int, int, bool)[] Coordinates { get; private set; }

        public Curb()
        {
            this.Coordinates = new (int, int, bool)[40];
            for (int i = 0, j = 0; i < this.Coordinates.Length; i++)
            {
                if (i < 20)
                {
                    this.Coordinates[i].Item1 = 0;
                    this.Coordinates[i].Item2 = i;
                }
                else
                {
                    this.Coordinates[i].Item1 = 9;
                    this.Coordinates[i].Item2 = j;
                    j++;
                }
                this.Coordinates[i].Item3 = (i % 4 == 0)? (false) : (true);
            }
        }

        public void Move()
        {
            for (int i = 0; i < this.Coordinates.Length; i++)
            {
                if (this.Coordinates[i].Item2 == 19)
                {
                    this.Coordinates[i].Item2 = 0;
                }
                else
                {
                    this.Coordinates[i].Item2++;
                }
            }
        }
    }
}

