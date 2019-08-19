using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{
    class Renderer
    {
        private Car car;

        private Car tempCar;

        private Curb curb;

        private Rival[] rivals;

        private Rival[] tempRivals;

        private bool carPositionChanged;

        private bool rivalsPositionChanged;

        private bool curbPositionChanged;

        private bool carCrashed;

        private bool gameOver;

        private int level;

        private int livesLeft;

        private bool levelChanged;

        private bool livesLeftChanged;

        public Renderer()
        {
            this.car = new Car();
            this.tempCar = new Car();
            this.curb = new Curb();
            this.carCrashed = false;
            this.gameOver = false;
            this.levelChanged = false;
            this.rivals = new Rival[10];
            this.tempRivals = new Rival[10];
            for (int i = 0; i < this.rivals.Length; i++)
            {
                this.rivals[i] = new Rival();
                this.tempRivals[i] = new Rival();
            }
        }

        public void UpdateCar(Car car)
        {
            this.car.Character = car.Character;
            for (int i = 0; i < this.car.Nodes.Length; i++)
            {
                this.tempCar.Nodes[i].X = this.car.Nodes[i].X;
                this.tempCar.Nodes[i].Y = this.car.Nodes[i].Y;
                this.car.Nodes[i].X = car.Nodes[i].X;
                this.car.Nodes[i].Y = car.Nodes[i].Y;
            }
            this.carPositionChanged = true;
        }

        public void UpdateRivals(Rival[] rivals)
        {
            for (int i = 0; i < this.rivals.Length; i++)
            {
                this.tempRivals[i].Character = this.rivals[i].Character;
                for (int j = 0; j < this.rivals[i].Nodes.Length; j++)
                {
                    this.tempRivals[i].Nodes[j].X = this.rivals[i].Nodes[j].X;
                    this.tempRivals[i].Nodes[j].Y = this.rivals[i].Nodes[j].Y;
                }
            }
            for (int i = 0; i < rivals.Length; i++)
            {
                this.rivals[i].Character = rivals[i].Character;
                for (int j = 0; j < rivals[i].Nodes.Length; j++)
                {
                    this.rivals[i].Nodes[j].X = rivals[i].Nodes[j].X;
                    this.rivals[i].Nodes[j].Y = rivals[i].Nodes[j].Y;
                }
            }
            this.rivalsPositionChanged = true;
        }

        public void UpdateCurb(Curb curb)
        {
            this.curb.Character = curb.Character;
            for (int i = 0; i < this.curb.Nodes.Length; i++)
            {
                this.curb.Nodes[i].X = curb.Nodes[i].X;
                this.curb.Nodes[i].Y = curb.Nodes[i].Y;
                this.curb.Nodes[i].Disabled = curb.Nodes[i].Disabled;
            }
            this.curbPositionChanged = true;
        }

        public void CarCrashNotifier()
        {
            this.carCrashed = true;
        }

        public void UpdateLevel(int level)
        {
            this.level = level;
            this.levelChanged = true;
        }

        public void UpdateLives(int livesLeft)
        {
            this.livesLeft = livesLeft;
            this.livesLeftChanged = true;
        }

        public void NotifyGameOver()
        {
            this.gameOver = true;
        }

        public void PrintEverything()
        {
            Console.CursorVisible = false;
            while(true)
            {
                //
                //curb
                //
                if (this.curbPositionChanged)
                {
                    foreach (var curbNode in curb.Nodes)
                    {
                        Console.SetCursorPosition(curbNode.X, curbNode.Y);
                        Console.Write(curbNode.Disabled ? ' ' : curb.Character);
                        this.curbPositionChanged = false;
                    }
                }
                //
                //Car
                //
                foreach (var carNode in this.car.Nodes)
                {
                    Console.SetCursorPosition(carNode.X, carNode.Y);
                    Console.Write(carNode.Disabled ? ' ' : car.Character);
                }
                if (this.carPositionChanged)
                {
                    foreach (var carNode in this.tempCar.Nodes)
                    {
                        Console.SetCursorPosition(carNode.X, carNode.Y);
                        Console.Write(" ");
                    }
                    this.carPositionChanged = false;
                }                
                //
                //Rivals
                //
                if (this.rivalsPositionChanged)
                {
                    foreach (var rival in this.tempRivals)
                    {
                        foreach (var node in rival.Nodes)
                        {
                            if (node.Y >= 0 && node.Y < 20)
                            {
                                Console.SetCursorPosition(node.X, node.Y);
                                Console.Write(" ");
                            }
                        }
                    }
                    foreach (var rival in this.rivals)
                    {
                        foreach (var node in rival.Nodes)
                        {
                            if (node.Y >= 0 && node.Y < 20)
                            {
                                Console.SetCursorPosition(node.X, node.Y);
                                Console.Write(rival.Character);
                            }
                        }
                    }
                    this.rivalsPositionChanged = false;
                }
                if (this.carCrashed)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    for (int i = 0, j = 0; i < 3; i++, j++)
                    {
                        Console.SetCursorPosition(this.car.Nodes[4].X + i, this.car.Nodes[4].Y + j);
                        Console.Write('X');
                        Console.SetCursorPosition(this.car.Nodes[4].X - i, this.car.Nodes[4].Y + j);
                        Console.Write('X');
                        Console.SetCursorPosition(this.car.Nodes[4].X - i, this.car.Nodes[4].Y - j);
                        Console.Write('X');
                        Console.SetCursorPosition(this.car.Nodes[4].X + i, this.car.Nodes[4].Y - j);
                        Console.Write('X');
                        Thread.Sleep(100);
                        if (!this.gameOver)
                        {
                            Console.SetCursorPosition(this.car.Nodes[4].X + i, this.car.Nodes[4].Y + j);
                            Console.Write(' ');
                            Console.SetCursorPosition(this.car.Nodes[4].X - i, this.car.Nodes[4].Y + j);
                            Console.Write(' ');
                            Console.SetCursorPosition(this.car.Nodes[4].X - i, this.car.Nodes[4].Y - j);
                            Console.Write(' ');
                            Console.SetCursorPosition(this.car.Nodes[4].X + i, this.car.Nodes[4].Y - j);
                            Console.Write(' ');
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    this.carCrashed = false;
                }
                //
                //Level
                //
                if (this.levelChanged)
                {
                    Console.SetCursorPosition(15, 9);
                    Console.Write("Level:" + this.level);
                    this.levelChanged = false;
                }
                if (this.livesLeftChanged)
                {
                    Console.SetCursorPosition(15, 11);
                    Console.Write("Lives:  ");
                    Console.SetCursorPosition(15, 11);
                    Console.Write("Lives:" + this.livesLeft);
                    this.livesLeftChanged = false;
                }
                //
                //GameOver
                //
                if (this.gameOver)
                {
                    Console.SetCursorPosition(15, 11);
                    Console.Write("< Game Over >");
                }
            }
        }
    }
}
