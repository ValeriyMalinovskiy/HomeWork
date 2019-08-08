﻿using System;
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
        private Curb curb = new Curb();

        private Car car = new Car();

        private Renderer renderer = new Renderer();

        private GameField field = new GameField();

        private ButtonPressEventRaiser eventRaiser = new ButtonPressEventRaiser();

        private ConcurrentQueue<Rival> rivals = new ConcurrentQueue<Rival>();

        private Position Position = Position.Left;

        private bool gameRunning = true;

        private bool gameOver = false;

        private bool speedIncreased = false;

        private void ProcessControl(GamepadEventArgs args)
        {
            //ThreadStart threadDelegate = new ThreadStart(this.RivalSpawner);
            //Thread rivalSpawner = new Thread(threadDelegate);
            //rivalSpawner.Start();

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
                            //if (this.gameRunning)
                            //{
                            //    rivalSpawner.Suspend();
                            //}
                            //else
                            //{
                            //    rivalSpawner.Resume();
                            //}
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
                if (this.rivals.Count < 4)
                {
                    Thread.Sleep(rnd.Next(1600, 2100));
                    this.rivals.Enqueue(new Rival((Position)rnd.Next(0, 2)));
                }
            }
        }

        private bool CheckCrash(Car car, IEnumerable<Node> rivals)
        {
            foreach (var rivalNode in rivals)
            {
                foreach (var carNode in car.Nodes)
                {
                    if (rivalNode.X == carNode.X && rivalNode.Y == carNode.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void MoveRivals()
        {
            bool dequeue = false;
            while (!this.gameOver)
            {
                if (this.gameRunning)
                {
                    foreach (var rival in this.rivals)
                    {
                        rival.Move();
                        if (!this.field.CheckIsOnField(rival))
                        {
                            dequeue = true;
                        }
                    }
                    if (dequeue)
                    {
                        this.rivals.TryDequeue(out Rival result);
                        dequeue = false;
                    }
                    this.renderer.UpdateRivals(this.rivals.SelectMany(item => item.Nodes).Distinct().ToArray());
                }
                Thread.Sleep(200);
            }
        }

        internal void StartGame()
        {
            Task printTask = new Task(() => renderer.PrintEverything());
            printTask.Start();

            Task controlTask = new Task(() => eventRaiser.Watch());
            controlTask.Start();

            Task curbTask = new Task(() => this.MoveCurb());
            curbTask.Start();

            Task rivalsTask = new Task(() => this.MoveRivals());
            rivalsTask.Start();

            //Task generateRivals = new Task(() => this.GenerateOncomingCar());
            //generateRivals.Start();

            eventRaiser.ControlPressed += this.ProcessControl;

            this.renderer.UpdateCar(this.car);

            while (true)
            {
                this.speedIncreased = AccelerationControl.IsKeyDown(38);
                //if (this.CheckCrash(this.car, this.rivals.SelectMany(item => item.Nodes).Distinct()))
                //{
                //    this.gameOver = true;
                //}
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
                    Thread.Sleep(speedIncreased ? 40 : 100);
                }
            }
        }
    }
}
