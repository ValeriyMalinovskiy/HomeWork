using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class GameField
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public GameField(int width = 10, int height = 20)
        {
            this.Width = width;
            this.Height = height;
        }

        public bool CheckIsOnField((int, int)[] car)
        {
            foreach (var point in car)
	        {
                    if (point.Item1 <= this.Width && point.Item1>=0 && point.Item2 <= this.Height && point.Item2 >=0)
	                {
                        return true;
	                }
            }
            return false;
        }
    }
}

