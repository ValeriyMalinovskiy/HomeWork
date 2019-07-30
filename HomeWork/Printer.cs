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

        private Curb curb;

        private bool carPositionChanged;

        public Printer()
        {
            this.car = new Car();
            this.tempCar = new Car();
            this.curb = new Curb();
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
            for (int i = 0; i < this.curb.Coordinates.Length; i++)
            {
                this.curb.Coordinates[i].Item1 = curb[i].Item1;
                this.curb.Coordinates[i].Item2 = curb[i].Item2;
                this.curb.Coordinates[i].Item3 = curb[i].Item3;
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
                foreach (var item in curb.Coordinates)
                {
                    Console.SetCursorPosition(item.Item1, item.Item2);
                    if (item.Item3)
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
                    foreach (var item in this.tempCar.Coordinates)
                    {
                        Console.SetCursorPosition(item.Item1, item.Item2);
                        Console.Write(" ");
                    }
                    this.carPositionChanged = false;
                }
                foreach (var item in this.car.Coordinates)
                {
                    Console.SetCursorPosition(item.Item1, item.Item2);
                    Console.Write("#");
                }
            }
        }
    }
}
