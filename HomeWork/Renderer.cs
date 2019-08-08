using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{
    class Renderer
    {
        private Car car;

        private Car tempCar;

        private Curb curb;

        private List<Node[]> rivals;

        private List<Node[]> tempRivals;

        private bool MoveDirectionChanged;

        private bool rivalsPositionChanged;

        public Renderer()
        {
            this.car = new Car();
            this.tempCar = new Car();
            this.curb = new Curb();
            this.rivals = new List<Node[]>();
            //this.tempRivals = new List<Node[]>();
            for (int i = 0; i < this.curb.Nodes.Length; i++)
            {
                this.curb.Nodes[i] = new Node();
            }
        }

        public void UpdateCar(Car car)
        {
            for (int i = 0; i < this.car.Nodes.Length; i++)
            {
                this.tempCar.Nodes[i].X = this.car.Nodes[i].X;
                this.tempCar.Nodes[i].Y = this.car.Nodes[i].Y;
                this.car.Nodes[i].X = car.Nodes[i].X;
                this.car.Nodes[i].Y = car.Nodes[i].Y;
            }
            this.MoveDirectionChanged = true;
        }

        public void UpdateRivals(IEnumerable<Node[]> rivals)
        {
            for (int i = 0; i < this.rivals.Count; i++)
            {
                for (int j = 0; j < this.rivals[i].Length; j++)
                {
                    this.rivals[i][j].ChangeVisibility();
                }
            }
            //this.rivalsPositionChanged = true;
            //if (this.rivals.Count>0)
            //{
            //    while (this.rivalsPositionChanged)
            //    {
            //        Thread.Sleep(1);
            //    }
            //}
            Thread.Sleep(5);
            this.rivals = rivals.ToList();
        }

        public void UpdateCurb(Curb curb)
        {
            for (int i = 0; i < this.curb.Nodes.Length; i++)
            {
                this.curb.Nodes[i].X = curb.Nodes[i].X;
                this.curb.Nodes[i].Y = curb.Nodes[i].Y;
                this.curb.Nodes[i].Invisible = curb.Nodes[i].Invisible;
            }
        }

        public void PrintEverything()
        {
            Console.CursorVisible = false;
            while (true)
            {
                //Console.Clear();
                //
                //curb
                //
                foreach (var point in curb.Nodes)
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    if (point.Invisible)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("~");
                    }
                }
                //
                //Car
                //
                if (this.MoveDirectionChanged)
                {
                    foreach (var point in this.tempCar.Nodes)
                    {
                        Console.SetCursorPosition(point.X, point.Y);
                        Console.Write(" ");
                    }
                    this.MoveDirectionChanged = false;
                }
                foreach (var point in this.car.Nodes)
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.Write(point.Invisible ? " " : "0");
                }
                //
                //Rivals
                //
                foreach (var rival in this.rivals)
                {
                    foreach (var node in rival)
                    {
                        if (node.Y >= 0 && node.Y < 20 && !node.Invisible)
                        {
                            Console.SetCursorPosition(node.X, node.Y);
                            Console.Write("#");
                        }
                    }
                }
                //if (this.rivalsPositionChanged)
                {
                    foreach (var rival in this.rivals)
                    {
                        foreach (var node in rival)
                        {
                            if (node.Y >= 0 && node.Y < 20 && node.Invisible)
                            {
                                Console.SetCursorPosition(node.X, node.Y);
                                Console.Write(" ");
                            }
                        }
                    }
                    //this.rivalsPositionChanged = false;
                }
            }
        }
    }
}
