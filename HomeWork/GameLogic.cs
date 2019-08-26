﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork
{
    internal delegate void ControlDelegate(GamepadEventArgs args);

    internal class GameLogic
    {
        private Curb curb = new Curb('|');

        private Car car = new Car('0');

        private Renderer renderer = new Renderer();

        private GameField field = new GameField();

        private ButtonPressEventRaiser eventRaiser = new ButtonPressEventRaiser();

        private Queue<Rival> rivals = new Queue<Rival>();

        private Position carPosition = Position.Left;

        private bool gameRunning = true;

        private bool gameOver = false;

        private bool speedIncreased = false;

        private readonly object rivalLocker = new object();

        private double level = 1.0;

        private int livesLeft = 10;

        private void ProcessControl(GamepadEventArgs args)
        {
            if (!this.gameOver)
            {
                switch (args.Control)
                {
                    case GameControl.ShiftCarLeft:
                        {
                            if (this.carPosition == Position.Right && gameRunning)
                            {
                                this.car.Move(Position.Left);
                                this.carPosition = Position.Left;
                                this.renderer.UpdateCar(this.car);
                            }
                        }
                        break;
                    case GameControl.ShiftCarRight:
                        {
                            if (this.carPosition == Position.Left && gameRunning)
                            {
                                this.car.Move(Position.Right);
                                this.carPosition = Position.Right;
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
                        {
                            this.gameOver = true;
                        }
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
                                    Thread.Sleep((int)(rnd.Next(500, 900) / this.level));
                                }
                                break;
                            case false:
                                {
                                    Thread.Sleep((int)(rnd.Next(1000, 1500) / this.level));
                                }
                                break;
                        }
                        while (!this.CheckSafeDistance())
                        {
                        }
                        lock (this.rivalLocker)
                        {
                            this.rivals.Enqueue(new Rival('8', (ConsoleColor)rnd.Next(1, 16), (Position)rnd.Next(0, 2)));
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
                foreach (Rival rival in this.rivals)
                {
                    foreach (Node rivalNode in rival.Nodes)
                    {
                        if (rivalNode.Y <= 0)
                        {
                            safeDistance = false;
                        }
                    }
                }
            }
            Thread.Sleep(16);
            return safeDistance;
        }

        private bool CheckCrash()
        {
            lock (this.rivalLocker)
            {
                foreach (Rival rival in this.rivals)
                {
                    foreach (Node rivalNode in rival.Nodes)
                    {
                        if (!rivalNode.IsDisabled)
                        {
                            foreach (Node carNode in this.car.Nodes)
                            {
                                if (rivalNode.X == carNode.X && rivalNode.Y == carNode.Y)
                                {
                                    this.DisableCrashedRival(rival);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void DisableCrashedRival(Rival rival)
        {
            foreach (Node rivalNode in rival.Nodes)
            {
                rivalNode.IsDisabled = true;
            }
        }

        private void MoveRivals()
        {
            while (!this.gameOver)
            {
                if (this.gameRunning)
                {
                    lock (this.rivalLocker)
                    {
                        foreach (Rival rival in this.rivals)
                        {
                            rival.Move();
                        }
                        this.renderer.UpdateRivals(this.rivals.ToArray());
                    }
                }

                Thread.Sleep((int)((speedIncreased ? 80 : 160) / this.level));
            }
        }

        private void RivalDequeueController()
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
                                this.level += 0.01;
                                this.renderer.UpdateLevel((int)((this.level - 1) * 100));
                            }
                        }
                    }
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
                    Thread.Sleep((int)((this.speedIncreased ? 40 : 100) / this.level));
                }
            }
        }

        internal void StartGame()
        {
            this.renderer.ShowHelp();

            Task controlTask = new Task(() => eventRaiser.Watch());
            controlTask.Start();

            Task printTask = new Task(() => renderer.Render());
            printTask.Start();

            Task curbTask = new Task(() => this.MoveCurb());
            curbTask.Start();

            Task generateRivals = new Task(() => this.RivalSpawner());
            generateRivals.Start();

            Task rivalsTask = new Task(() => this.MoveRivals());
            rivalsTask.Start();

            Task dequeueTask = new Task(() => this.RivalDequeueController());
            dequeueTask.Start();

            eventRaiser.ControlPressed += this.ProcessControl;

            this.renderer.UpdateCar(this.car);
            this.renderer.UpdateLevel((int)((this.level - 1) * 100));
            this.renderer.UpdateLives(this.livesLeft);

            while (!this.gameOver)
            {
                this.speedIncreased = AccelerationControl.IsKeyDown();
                if (this.CheckCrash())
                {
                    this.renderer.NotifyCarCrash();
                    this.livesLeft--;
                    this.renderer.UpdateLives(this.livesLeft);
                    this.gameRunning = false;
                    if (this.livesLeft < 0)
                    {
                        this.renderer.NotifyGameOver();
                        Thread.Sleep(3000);
                        this.gameOver = true;
                    }
                    Thread.Sleep(1000);
                    this.gameRunning = true;
                }
                Thread.Sleep(16);
            }
        }
    }
}
