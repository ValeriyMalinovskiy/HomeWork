using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{
    class Printer
    {
        private Node[] car;

        private Node[] tempCar;

        private Node[] curb;

        private (int, int)[] rivals;

        private (int, int)[] tempRivals;

        private bool MoveDirectionChanged;

        private bool rivalsPositionChanged;

        public Printer()
        {
            this.car = new Node[12];
            this.tempCar = new Node[12];
            this.curb = new Node[40];
            this.rivals = new (int, int)[28];
            this.tempRivals = new (int, int)[28];
            for (int i = 0; i < this.curb.Length; i++)
            {
                this.curb[i] = new Node();
            }
            for (int i = 0; i < this.car.Length; i++)
            {
                this.car[i] = new Node();
            }
        }

        public void UpdateCar(Node[] car)
        {
            this.car = car;
            //for (int i = 0; i < this.car.Nodes.Length; i++)
            //{
            //    this.tempCar.Coordinates[i].Item1 = this.car.Coordinates[i].Item1;
            //    this.tempCar.Coordinates[i].Item2 = this.car.Coordinates[i].Item2;
            //    this.car.Coordinates[i].Item1 = car[i].Item1;
            //    this.car.Coordinates[i].Item2 = car[i].Item2;
            //}
            this.MoveDirectionChanged = true;
        }

        public void UpdateRivals((int, int)[] rivals)
        {
            for (int i = 0; i < rivals.Length; i++)
            {
                this.tempRivals[i].Item1 = this.rivals[i].Item1;
                this.tempRivals[i].Item2 = this.rivals[i].Item2;
                this.rivals[i].Item1 = rivals[i].Item1;
                this.rivals[i].Item2 = rivals[i].Item2;
            }
            this.rivalsPositionChanged = true;
        }

        public void UpdateCurb(Node[] curb)
        {
            for (int i = 0; i < this.curb.Length; i++)
            {
                this.curb[i].X = curb[i].X;
                this.curb[i].Y = curb[i].Y;
                this.curb[i].IsVisible = curb[i].IsVisible;
            }
        }

        public void PrintEverything()
        {
            Console.CursorVisible = false;
            while (true)
            {
                //
                //curb
                //
                foreach (var point in curb)
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    if (point.IsVisible)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                //
                //Car
                //
                //if (this.MoveDirectionChanged)
                //{
                //    foreach (var point in this.tempCar)
                //    {
                //        Console.SetCursorPosition(point.X, point.Y);
                //        Console.Write(" ");
                //    }
                //    this.MoveDirectionChanged = false;
                //}
                foreach (var point in this.car)
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.Write(point.IsVisible ? "#" : " ");
                }
                //
                //Rivals
                //
                foreach (var point in this.rivals)
                {
                    if (point.Item2 >= 0 && point.Item2 < 20)
                    {
                        Console.SetCursorPosition(point.Item1, point.Item2);
                        Console.Write("#");
                    }
                }
                if (this.rivalsPositionChanged)
                {
                    foreach (var point in this.tempRivals)
                    {
                        if (point.Item2 >= 0 && point.Item2 < 20)
                        {
                            Console.SetCursorPosition(point.Item1, point.Item2);
                            Console.Write(" ");
                        }
                    }
                    this.rivalsPositionChanged = false;
                }
            }
        }
    }
}
