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
        private Car car;

        private Car tempCar;

        private (int, int, bool)[] curb;

        private bool carPositionChanged;

        public Printer()
        {
            this.car = new Car();
            this.tempCar = new Car();
            this.curb = new (int,int,bool)[40];
        }

        public void UpdateCar((int, int)[] car)
        {
            for (int i = 0; i < this.car.Coordinates.Length; i++)
            {
                this.tempCar.Coordinates[i].Item1 = this.car.Coordinates[i].Item1;
                this.tempCar.Coordinates[i].Item2 = this.car.Coordinates[i].Item2;
                this.car.Coordinates[i].Item1 = car[i].Item1;
                this.car.Coordinates[i].Item2 = car[i].Item2;
            }
            this.carPositionChanged = true;
        }

        public void UpdateCurb((int, int, bool)[] curb)
        {
            for (int i = 0; i < this.curb.Length; i++)
            {
                this.curb[i].Item1 = curb[i].Item1;
                this.curb[i].Item2 = curb[i].Item2;
                this.curb[i].Item3 = curb[i].Item3;
            }
        }

        //public void UpdateRivals(ref Queue<OncomingCar> rivals)
        //{
        //    this.tempRivals = this.rivals;
        //    this.rivals = rivals;
        //}

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
                    Console.SetCursorPosition(point.Item1, point.Item2);
                    if (point.Item3)
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
                if (this.carPositionChanged)
                {
                    foreach (var point in this.tempCar.Coordinates)
                    {
                        Console.SetCursorPosition(point.Item1, point.Item2);
                        Console.Write(" ");
                    }
                    this.carPositionChanged = false;
                }
                foreach (var point in this.car.Coordinates)
                {
                    Console.SetCursorPosition(point.Item1, point.Item2);
                    Console.Write("#");
                }
                //
                //Rivals
                //
                //foreach (var car in this.tempRivals)
                //{
                //    foreach (var point in car.Coordinates)
                //    {
                //        if (point.Item2 >= 0 && point.Item2 < 20)
                //        {
                //            Console.SetCursorPosition(point.Item1, point.Item2);
                //            Console.Write(" ");
                //        }
                //    }
                //}
                //foreach (var car in this.rivals)
                //{
                //    foreach (var point in car.Coordinates)
                //    {
                //        if (point.Item2 >= 0 && point.Item2 < 20)
                //        {
                //            Console.SetCursorPosition(point.Item1, point.Item2);
                //            Console.Write("#");
                //        }
                //    }
                //}
            }
        }
    }
}
