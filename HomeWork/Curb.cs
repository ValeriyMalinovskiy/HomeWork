using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Curb
    {
        //public (int, int, bool)[] Coordinates { get; private set; }
        public Node[] Nodes { get; protected set; }

        public Curb()
        {
            this.Nodes = new Node[40];
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                Nodes[i] = new Node();
            }
            for (int i = 0, j = 0; i < this.Nodes.Length; i++)
            {
                if (i < 20)
                {
                    this.Nodes[i].X = 0;
                    this.Nodes[i].Y = i;
                }
                else
                {
                    this.Nodes[i].X = 9;
                    this.Nodes[i].Y = j;
                    j++;
                }
                this.Nodes[i].IsVisible = (i % 4 == 0) ? (false) : (true);
            }
        }

        public void Move(CarPosition direction = CarPosition.Down)
        {
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                if (this.Nodes[i].Y == 19)
                {
                    this.Nodes[i].Y = 0;
                }
                else
                {
                    this.Nodes[i].Y++;
                }
            }
        }
    }
    //internal class Curb : RacingGameObject
    //{
    //    //public (int, int, bool)[] Coordinates { get; private set; }
    //    public override Node[] Nodes { get; protected set; }

    //    public Curb()
    //    {
    //        this.Nodes = new Node[40];
    //        for (int i = 0; i < this.Nodes.Length; i++)
    //        {
    //            Nodes[i] = new Node();
    //        }
    //        for (int i = 0, j = 0; i < this.Nodes.Length; i++)
    //        {
    //            if (i < 20)
    //            {
    //                this.Nodes[i].X = 0;
    //                this.Nodes[i].Y = i;
    //            }
    //            else
    //            {
    //                this.Nodes[i].X = 9;
    //                this.Nodes[i].Y = j;
    //                j++;
    //            }
    //            this.Nodes[i].IsVisible = (i % 4 == 0) ? (false) : (true);
    //        }
    //    }

    //    public override void Move(CarPosition direction = CarPosition.Down)
    //    {
    //        for (int i = 0; i < this.Nodes.Length; i++)
    //        {
    //            if (this.Nodes[i].Y == 19)
    //            {
    //                this.Nodes[i].Y = 0;
    //            }
    //            else
    //            {
    //                this.Nodes[i].Y++;
    //            }
    //        }
    //    }
    //}
}

