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
            this.rivals = new Node[28];
            this.tempRivals = new Node[28];
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
            int rivalArrLength = rivals.Length;
            //if (tempRivals!=null)
            //{
            //    for (int i = 0; i < this.tempRivals.Length; i++)
            //    {
            //        this.tempRivals[i].X = this.rivals[i].X;
            //        this.tempRivals[i].Y = this.rivals[i].Y;
            //        this.tempRivals[i].Invisible = this.rivals[i].Invisible;
            //    }
            //}

            for (int i = 0; i < this.rivals.Length; i++)
            {
                if (i < rivalArrLength)
                {
                    this.rivals[i].X = rivals[i].X;
                    this.rivals[i].Y = rivals[i].Y;
                    this.rivals[i].Invisible = rivals[i].Invisible;
                }
                else
                {
                    this.rivals[i].Invisible = true;
                }
            }
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
                //if (this.rivalsPositionChanged)
                //{
                //    for (int i = 0; i < 28; i++)
                //    {
                //        if (this.rivals[i].Y >= 0 && this.rivals[i].Y < 20)
                //        {
                //            Console.SetCursorPosition(this.rivals[i].X, this.rivals[i].Y);
                //            Console.Write("0");
                //        }
                //    }
                //    this.rivalsPositionChanged = false;
                //}
            }
        }
    }
}
