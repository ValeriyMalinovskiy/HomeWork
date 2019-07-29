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
        private Curb curb;

        private Car car;

        private Car tempCar;

        private bool carPositionChanged;

        public Printer(Car car, Curb curb)
        {
            this.tempCar = car;
            this.car = car;
            this.curb = curb;
        }

        public void UpdateCar(Car car)
        {
            this.tempCar = this.car;
            this.car = car;
            this.carPositionChanged = true;
        }

        public void UpdateCurb(Curb curb)
        {
            this.curb = curb;
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
