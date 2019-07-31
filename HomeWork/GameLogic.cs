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

        Queue<OncomingCar> rivals = new Queue<OncomingCar>();

        CarPosition carPosition = CarPosition.Left;

        bool gameRunning = true;

        bool gameOver = false;

        private void ProcessControl(GamepadHandlerEventArgs args)
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

        //private void GenerateOncomingCar()
        //{
        //    Random rnd = new Random();
        //    while (!this.gameOver)
        //    {
        //        if (this.gameRunning && rivals.Count<4)
        //        {
        //            //Thread.Sleep(rnd.Next(500, 1500));
        //            rivals.Enqueue(new OncomingCar((CarPosition)rnd.Next(0,2)));
        //            this.printer.rivals = this.rivals;
        //        }
        //    }
        //}

        public void StartGame()
        {
            Task printTask = new Task(() => printer.PrintEverything());
            printTask.Start();

            Task controlTask = new Task(() => gamepad.ProcessButtonPressed());
            controlTask.Start();

            Task curbTask = new Task(() => this.MoveCurb());
            curbTask.Start();

            //Task rivalsTask = new Task(() => this.MoveRivals());
            //rivalsTask.Start();

            //Task generateRivals = new Task(() => GenerateOncomingCar());
            //generateRivals.Start();

            gamepad.ControlPressed += ProcessControl;

            while (true)
            {
            }
        }

        private void MoveCurb()
        {
            while (!this.gameOver)
            {
                if (this.gameRunning)
                {
                    curb.Move();
                    printer.UpdateCurb(curb.Coordinates);
                    Thread.Sleep(50);
                }
            }
        }
    }
}
