using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{
    internal delegate void ControlDelegate(GamepadHandlerEventArgs args);

    class GameLogic
    {
        Curb curb = new Curb();

        Car car = new Car();

        Printer printer = new Printer();

        GamepadHandlerEventArgs gamepad = new GamepadHandlerEventArgs();

        CarPosition carPosition = CarPosition.Left;

        bool gameRunning = true;

        bool gameOver = false;

        public void Process(GamepadHandlerEventArgs args)
        {
            switch (args.myProperty)
            {
                case GameControl.ShiftCarLeft:
                    {
                        if (this.carPosition == CarPosition.Right && gameRunning)
                        {
                            this.car.Shift(CarPosition.Left);
                            this.carPosition = CarPosition.Left;
                            this.printer.UpdateCar(this.car.Coordinates);
                        }
                    }
                    break;
                case GameControl.ShiftCarRight:
                    {
                        if (this.carPosition == CarPosition.Left && gameRunning)
                        {
                            this.car.Shift(CarPosition.Right);
                            this.carPosition = CarPosition.Right;
                            this.printer.UpdateCar(this.car.Coordinates);
                        }
                    }
                    break;
                case GameControl.GainSpeed:
                    break;
                case GameControl.Pause:
                    {
                        this.gameRunning = !gameRunning;
                    }
                    break;
                case GameControl.Quit:
                    break;
                default:
                    break;
            }
        }

        public void StartGame()
        {
            Task printTask = new Task(() => printer.PrintEverything());
            printTask.Start();

            Task controlTask = new Task(() => gamepad.ProcessButtonPressed());
            controlTask.Start();

            Task curbTask = new Task(() => this.MoveCurb());
            curbTask.Start();

            gamepad.ControlPressed += Process;

            while (true)
            {
            }
        }

        public void MoveCurb()
        {
            while (!this.gameOver)
            {
                if (this.gameRunning)
                {
                    curb.Move();
                    printer.UpdateCurb(curb.Coordinates);
                    Thread.Sleep(150);
                }
            }
        }
    }
}
