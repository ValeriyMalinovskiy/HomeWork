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

        public bool Invisible { get; set; }

        public Node()
        {
            this.X = -1;
            this.Y = -1;
            this.Invisible = false;
        }

        public void ChangeVisibility()
        {
            this.Invisible = !this.Invisible;
        }
    }
}
