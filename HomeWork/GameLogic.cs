using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{

    class GameLogic
    {
        Curb curb = new Curb();

        Car car = new Car();

        Printer printer = new Printer();

        CarPosition carPosition = CarPosition.Left;

        public void ProcessButtonPressed()
        {
            while (true)
            {
                ConsoleKeyInfo pressed = Console.ReadKey(true);
                if (pressed.Key == ConsoleKey.LeftArrow && this.carPosition == CarPosition.Right)
                {
                    this.car.Shift(CarPosition.Left);
                    this.carPosition = CarPosition.Left;
                }
                else if (pressed.Key == ConsoleKey.RightArrow && this.carPosition == CarPosition.Left)
                {
                    this.car.Shift(CarPosition.Right);
                    this.carPosition = CarPosition.Right;
                }
                this.printer.UpdateCar(this.car.Coordinates);
            }
        }

        public void StartGame()
        {
            Task print = new Task(() => printer.PrintEverything());
            print.Start();

            Task control = new Task(() => this.ProcessButtonPressed());
            control.Start();

            Task curb = new Task(() => this.MoveCurb());
            curb.Start();

            while (true)
            {
            }
        }

        public void MoveCurb()
        {
            while (true)
            {
                curb.Move();
                printer.UpdateCurb(curb.Coordinates);
                Thread.Sleep(100);
            }
        }
    }
}
