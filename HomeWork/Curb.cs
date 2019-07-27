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
            Coordinates = new (int, int, bool)[40];
            for (int i = 0, j = 0; i < Coordinates.Length; i++)
            {
                if (i < 20)
                {
                    Coordinates[i].Item1 = 0;
                    Coordinates[i].Item2 = i;
                }
                else
                {
                    Coordinates[i].Item1 = 9;
                    Coordinates[i].Item2 = j;
                    j++;
                }
                Coordinates[i].Item3 = (i % 4 == 0)? (false) : (true);
            }
        }

        public void Move()
        {
            for (int i = 0; i < Coordinates.Length; i++)
            {
                if (Coordinates[i].Item2 == 19)
                {
                    Coordinates[i].Item2 = 0;
                }
                else
                {
                    Coordinates[i].Item2++;
                }
            }
        }
    }
}

