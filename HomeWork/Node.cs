using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Node
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool Disabled { get; set; }

        public Node()
        {
            this.X = -1;
            this.Y = -1;
            this.Disabled = false;
        }
    }
}
