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

        private Node[] rivals;

        private Node[] tempRivals;

        private bool carPositionChanged;

        private bool rivalsPositionChanged;

        public Renderer()
        {
            this.car = new Car();
            this.tempCar = new Car();
            this.curb = new Curb();
            //this.rivals = new Node[];
            //this.tempRivals = new List<Rival>();
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
            this.carPositionChanged = true;
        }

        public void UpdateRivals(Node[] rivals)
        {
            if (this.rivals!=null)
            {
                this.tempRivals = this.rivals;
            }
            this.rivals = rivals;
            this.rivalsPositionChanged = true;
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
            Thread.Sleep(100);
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
                if (this.carPositionChanged)
                {
                    foreach (var point in this.tempCar.Nodes)
                    {
                        Console.SetCursorPosition(point.X, point.Y);
                        Console.Write(" ");
                    }
                    this.carPositionChanged = false;
                }
                foreach (var point in this.car.Nodes)
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.Write(point.Invisible ? " " : "0");
                }
                //
                //Rivals
                //
                if (this.rivalsPositionChanged)
                {
                    foreach (var node in this.tempRivals)
                    {
                        if (node.Y >= 0 && node.Y < 20)
                        {
                            Console.SetCursorPosition(node.X, node.Y);
                            Console.Write(" ");
                        }
                    }
                    this.rivalsPositionChanged = false;
                }
                {
                    foreach (var node in this.rivals)
                    {
                        if (node.Y >= 0 && node.Y < 20)
                        {
                            Console.SetCursorPosition(node.X, node.Y);
                            Console.Write("6");
                        }
                    }
                }
            }
        }
    }
}
