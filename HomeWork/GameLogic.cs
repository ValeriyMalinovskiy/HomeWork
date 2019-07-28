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

        CarPosition carPosition = CarPosition.Left;

        public delegate void CarControlDelegate(Object sender, CarControlEventArgs args);

        public event CarControlDelegate ChangePosition;

        Printer printer = new Printer();

        protected virtual void OnChangePosition(CarControlEventArgs e)
        {
            if (ChangePosition!=null)
            {
                ChangePosition(this, e);
            }
        }
        
        public void ProcessButtonPressed()
            {
                if (Console.ReadKey(false).Key == ConsoleKey.LeftArrow)
	            {
                    car.ShiftLeft();
                    printer.UpdateCar(this.car);
	            }
            }

        public void StartGame()
        {
            printer.UpdateCar(this.car);
            Task print = new Task(() => printer.PrintEverything());
            print.Start();

            Task shiftCar = new Task(() => ProcessButtonPressed());
            shiftCar.Start();

            for (int i = 0; i < 10; i++)
            {
                curb.Move();
                printer.UpdateCurb(curb);
                Thread.Sleep(1000);
            }
        }
    }
}
