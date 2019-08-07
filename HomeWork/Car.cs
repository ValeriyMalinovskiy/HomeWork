using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Car
    {
        public Node[] Nodes { get; private set; }

        public Car()
        {
            this.Nodes = new Node[12];
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                this.Nodes[i] = new Node();
            }
            this.Nodes[0].X = 2;
            this.Nodes[0].Y = 19;
            this.Nodes[0].IsVisible = true;
            this.Nodes[1].X = 4;
            this.Nodes[1].Y = 19;
            this.Nodes[1].IsVisible = true;
            this.Nodes[2].X = 3;
            this.Nodes[2].Y = 18;
            this.Nodes[2].IsVisible = true;
            this.Nodes[3].X = 2;
            this.Nodes[3].Y = 17;
            this.Nodes[3].IsVisible = true;
            this.Nodes[4].X = 3;
            this.Nodes[4].Y = 17;
            this.Nodes[4].IsVisible = true;
            this.Nodes[5].X = 4;
            this.Nodes[5].Y = 17;
            this.Nodes[5].IsVisible = true;
            this.Nodes[6].X = 3;
            this.Nodes[6].Y = 16;
            this.Nodes[6].IsVisible = true;
            this.Nodes[7].X = 3;
            this.Nodes[7].Y = 19;
            this.Nodes[7].IsVisible = false;
            this.Nodes[8].X = 2;
            this.Nodes[8].Y = 18;
            this.Nodes[8].IsVisible = false;
            this.Nodes[9].X = 4;
            this.Nodes[9].Y = 18;
            this.Nodes[9].IsVisible = false;
            this.Nodes[10].X = 2;
            this.Nodes[10].Y = 16;
            this.Nodes[10].IsVisible = false;
            this.Nodes[11].X = 4;
            this.Nodes[11].Y = 16;
            this.Nodes[11].IsVisible = false;
        }

        public void Shift(CarPosition carPosition)
        {
            switch (carPosition)
            {
                case CarPosition.Left:
                    foreach (var node in this.Nodes)
                    {
                        node.X -= 3;
                    }
                    break;
                case CarPosition.Right:
                    foreach (var node in this.Nodes)
                    {
                        node.X += 3;
                    }
                    break;
            }
        }
    }
}
