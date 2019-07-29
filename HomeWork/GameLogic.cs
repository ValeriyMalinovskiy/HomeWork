using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{
    public delegate void CarControlDelegate(CarControlEventArgs args);

    class GameLogic
    {

        Curb curb = new Curb();

        Car car = new Car();

        Printer printer = new Printer(new Car(), new Curb());

        CarPosition carPosition = CarPosition.Left;

        //public event CarControlDelegate ChangePosition;

        //protected virtual void OnChangePosition(CarControlEventArgs e)
        //{
        //    if (ChangePosition!=null)
        //    {
        //        ChangePosition(this, e);
        //    }
        //}
        
        //public void ProcessButtonPressed()
        //    {
        //    if (Console.ReadKey(false).Key == ConsoleKey.LeftArrow && carPosition == CarPosition.Right)
        //    {
        //        car.ShiftLeft();
        //    }
        //    if (Console.ReadKey(false).Key == ConsoleKey.RightArrow && carPosition == CarPosition.Left)
        //    {
        //        car.ShiftRight();
        //    }
        //    CarControlEventArgs args = new CarControlEventArgs(this.car.Coordinates);
        //    OnChangePosition(args);
        //}

        public void StartGame()
        {
            Task print = new Task(() => printer.PrintEverything());
            print.Start();

            Task curb = new Task(() => this.MoveCurb());
            curb.Start();

            //Task shiftCar = new Task(() => ProcessButtonPressed());
            //shiftCar.Start();

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
