using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace HomeWork
{
    internal delegate void ControlDelegate(GamepadEventArgs args);

    internal class GameLogic
    {
        private Curb curb = new Curb('|');

        private Car car = new Car('*');

        private Renderer renderer = new Renderer();

        private GameField field = new GameField();

        private ButtonPressEventRaiser eventRaiser = new ButtonPressEventRaiser();

        private Queue<Rival> rivals = new Queue<Rival>();

        private Position Position = Position.Left;

        private bool gameRunning = true;

        private bool gameOver = false;

        private bool speedIncreased = false;

        object rivalLocker = new object();

        private void ProcessControl(GamepadEventArgs args)
        {
            if (!this.gameOver)
            {
                switch (args.control)
                {
                    case GameControl.ShiftCarLeft:
                        {
                            if (this.Position == Position.Right && gameRunning)
                            {
                                this.car.Move(Position.Left);
                                this.Position = Position.Left;
                                this.renderer.UpdateCar(this.car);
                            }
                        }
                        break;
                    case GameControl.ShiftCarRight:
                        {
                            if (this.Position == Position.Left && gameRunning)
                            {
                                this.car.Move(Position.Right);
                                this.Position = Position.Right;
                                this.renderer.UpdateCar(this.car);
                            }
                        }
                        break;
                    case GameControl.Pause:
                        {
                            this.gameRunning = !this.gameRunning;
                        }
                        break;
                    case GameControl.Quit:
                        break;
                }
            }
        }

        private void RivalSpawner()
        {
            Random rnd = new Random();
            while (!this.gameOver)
            {
                if (this.gameRunning)
                {
                    if (this.rivals.Count <= 10)
                    {
                        switch (this.speedIncreased)
                        {
                            case true:
                                {
                                    Thread.Sleep(rnd.Next(500, 900));
                                }
                                break;
                            case false:
                                {
                                    Thread.Sleep(rnd.Next(1000, 1500));
                                }
                                break;
                        }
                        while (!this.CheckSafeDistance())
                        {
                        }
                        lock (this.rivalLocker)
                        {
                            this.rivals.Enqueue(new Rival('8', (Position)rnd.Next(0, 2)));
                        }
                    }
                }
            }
        }

        private bool CheckSafeDistance()
        {
            bool safeDistance = true;
            lock (this.rivalLocker)
            {
                foreach (var rival in this.rivals)
                {
                    foreach (var rivalNode in rival.Nodes)
                    {
                        if (rivalNode.Y < 0)
                        {
                            safeDistance = false;
                        }
                    }
                }
            }
            return safeDistance;
        }

        private bool CheckCrash()
        {
            lock (this.rivalLocker)
            {
                foreach (var rival in this.rivals)
                {
                    foreach (var rivalNode in rival.Nodes)
                    {
                        foreach (var carNode in this.car.Nodes)
                        {
                            if (rivalNode.X == carNode.X && rivalNode.Y == carNode.Y)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void MoveRivals()
        {
            while (!this.gameOver)
            {
                if (this.gameRunning)
                    lock (this.rivalLocker)
                    {
                        foreach (var rival in this.rivals)
                        {
                            rival.Move();
                        }
                        this.renderer.UpdateRivals(this.rivals.ToArray());
                    }
                Thread.Sleep(speedIncreased ? 80 : 160);
            }
        }

        private void RivalQueueCountController()
        {
            while (!this.gameOver)
            {
                if (this.gameRunning)
                {
                    if (this.rivals.Count > 5)
                    {
                        lock (this.rivalLocker)
                        {
                            if (!this.field.CheckIsOnField(this.rivals.Peek()))
                            {
                                this.rivals.Dequeue();
                            }
                        }
                    }
                }
            }
        }

        internal void StartGame()
        {
            Task controlTask = new Task(() => eventRaiser.Watch());
            controlTask.Start();

            Task printTask = new Task(() => renderer.PrintEverything());
            printTask.Start();

            Task curbTask = new Task(() => this.MoveCurb());
            curbTask.Start();

            Task generateRivals = new Task(() => this.RivalSpawner());
            generateRivals.Start();

            Task rivalsTask = new Task(() => this.MoveRivals());
            rivalsTask.Start();

            Task dequeueTask = new Task(() => this.RivalQueueCountController());
            dequeueTask.Start();

            this.renderer.UpdateCar(this.car);

            eventRaiser.ControlPressed += this.ProcessControl;

            while (true)
            {
                this.speedIncreased = AccelerationControl.IsKeyDown(38);
                if (this.CheckCrash())
                {
                    this.renderer.CarCrashNotifier();
                    this.gameOver = true;
                }
            }
        }

        private void MoveCurb()
        {
            while (!this.gameOver)
            {
                if (this.gameRunning)
                {
                    curb.Move();
                    renderer.UpdateCurb(this.curb);
                    Thread.Sleep(this.speedIncreased ? 40 : 100);
                }
            }
        }
    }
}
