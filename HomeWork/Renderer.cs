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

        private bool MoveDirectionChanged;

        private bool rivalsPositionChanged;

        public Renderer()
        {
            this.car = new Car();
            this.tempCar = new Car();
            this.curb = new Curb();
            this.rivals = new Rival[4];
            this.tempRivals = new Rival[4];
            for (int i = 0; i < this.curb.Nodes.Length; i++)
            {
                this.curb.Nodes[i] = new Node();
            }
            for (int i = 0; i < this.car.Nodes.Length; i++)
            {
                this.car.Nodes[i] = new Node();
                this.tempCar.Nodes[i] = new Node();
            }
            for (int i = 0; i < rivals.Length; i++)
            {
                rivals[i] = new Rival();
                tempRivals[i] = new Rival();
                for (int j = 0; j < 7; j++)
                {
                    this.rivals[i].Nodes[j] = new Node();
                    this.tempRivals[i].Nodes[j] = new Node();
                }
            }
        }

        public void UpdateCar(Car car)
        {
            for (int i = 0; i < this.car.Nodes.Length; i++)
            {
                this.tempCar.Nodes[i].X = this.car.Nodes[i].X;
                this.tempCar.Nodes[i].Y = this.car.Nodes[i].Y;
                this.tempCar.Nodes[i].IsVisible = this.car.Nodes[i].IsVisible;
                this.car.Nodes[i].X = car.Nodes[i].X;
                this.car.Nodes[i].Y = car.Nodes[i].Y;
                this.car.Nodes[i].IsVisible = car.Nodes[i].IsVisible;
            }
            this.MoveDirectionChanged = true;
        }

        public void UpdateRivals(Rival[] rivals)
        {
            for (int i = 0; i < rivals.Length; i++)
            {
                for (int j = 0; j < rivals[i].Nodes.Length; j++)
                {
                    this.tempRivals[i].Nodes[j].X = this.rivals[i].Nodes[j].X;
                    this.tempRivals[i].Nodes[j].Y = this.rivals[i].Nodes[j].Y;
                    this.rivals[i].Nodes[j].X = rivals[i].Nodes[j].X;
                    this.rivals[i].Nodes[j].Y = rivals[i].Nodes[j].Y;
                }
            }
            this.rivalsPositionChanged = true;
        }

        public void UpdateCurb(Curb curb)
        {
            for (int i = 0; i < this.curb.Nodes.Length; i++)
            {
                this.curb.Nodes[i].X = curb.Nodes[i].X;
                this.curb.Nodes[i].Y = curb.Nodes[i].Y;
                this.curb.Nodes[i].IsVisible = curb.Nodes[i].IsVisible;
            }
        }

        public void PrintEverything()
        {
            Console.CursorVisible = false;
            while (true)
            {
                //
                //curb
                //
                foreach (var point in curb.Nodes)
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    if (point.IsVisible)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                //
                //Car
                //
                if (this.MoveDirectionChanged)
                {
                    foreach (var point in this.tempCar.Nodes)
                    {
                        Console.SetCursorPosition(point.X, point.Y);
                        Console.Write(" ");
                    }
                    this.MoveDirectionChanged = false;
                }
                foreach (var point in this.car.Nodes)
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.Write(point.IsVisible ? "0" : " ");
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
                    this.rivalsPositionChanged = false;
                }
                foreach (var rival in this.rivals)
                {
                    foreach (var node in rival.Nodes)
                    {
                        if (node.Y >= 0 && node.Y < 20)
                        {
                            Console.SetCursorPosition(node.X, node.Y);
                            Console.Write("#");
                        }
                    }
                }
            }
        }
    }
}
