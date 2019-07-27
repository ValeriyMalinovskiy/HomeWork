using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class RoadBoundary
    {
        public (int, int, bool)[] Curb { get; private set; }

        public RoadBoundary()
        {
            Curb = new (int, int, bool)[40];
        for (int i = 0; i < Curb.Length; i++)
            {
                Curb[i].Item1 = 0;
                Curb[i].Item2 = i;
                Curb[i*2].Item1 = 9;
                Curb[i*2].Item2 = i;
                if (i%4==0)
                    {
                        Curb[i].Item3 = false;
                    Curb[i*2].Item3 = false;
                    }
                else
	{
                        Curb[i].Item3 = true;;
                    Curb[i*2].Item3 = true;
	}
                    
                }
        }

        public void MoveBoundary()
        {
            for (int i = 0; i < Curb.Length; i++)
            {
                if (Curb[i].Item2 == 19)
                {
                    Curb[i].Item2 = 0;
                }
                else
                {
                    Curb[i].Item2++;
                }
            }
        }
    }
}

