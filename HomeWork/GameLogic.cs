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

        Printer printer = new Printer(new Car(), new Curb());

        CarPosition carPosition = CarPosition.Left;

        public delegate void CarControlDelegate();

        public event CarControlDelegate ButtonPressed;

        protected virtual void OnButtonPressed()
        {
            ButtonPressed?.Invoke();
        }

        public void ProcessButtonPressed()
        {
            if (Console.ReadKey(false).Key == ConsoleKey.LeftArrow && carPosition == CarPosition.Right)
            {
                this.car.Shift(CarPosition.Left);
            }
            if (Console.ReadKey(false).Key == ConsoleKey.RightArrow && carPosition == CarPosition.Left)
            {
                this.car.Shift(CarPosition.Right);
            }
        }

        public void StartGame()
        {
            Task print = new Task(() => printer.PrintEverything());
            print.Start();

            Task control = new Task(() => ProcessButtonPressed());
            control.Start();

            Task curb = new Task(() => this.MoveCurb());
            curb.Start();

            OnButtonPressed();
            ButtonPressed += ProcessButtonPressed;


            while (true)
            {
            }
        }

        public void MoveCurb()
        {
            while (true)
            {
                curb.Move();
                printer.UpdateCurb(curb);
                Thread.Sleep(100);
            }
        }
    }
}
