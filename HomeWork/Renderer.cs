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

        public Renderer()
        {
            this.car = new Car();
            this.tempCar = new Car();
            this.curb = new Curb();
            this.rivals = new Rival[3];
            this.tempRivals = new Rival[3];
            for (int i = 0; i < this.rivals.Length; i++)
            {
                this.rivals[i] = new Rival();
                this.tempRivals[i] = new Rival();
            }
        }

        public void UpdateCar(Car car)
        {
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
            for (int i = 0; i < rivals.Length; i++)
            {
                this.tempRivals[i].Character = this.rivals[i].Character;
                this.rivals[i].Character = rivals[i].Character;
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
                this.curb.Nodes[i].Invisible = curb.Nodes[i].Invisible;
            }
        }

        public void PrintEverything()
        {
            Console.CursorVisible = false;
            while (true)
            {
                //Console.Clear();
                //
                //curb
                //
                foreach (var point in curb.Nodes)
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    if (point.Invisible)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(curb.Character);
                    }
                }
                //
                //Car
                //
                if (this.carPositionChanged)
                {
                    foreach (var point in this.tempCar.Nodes)
                    {
                        Console.SetCursorPosition(point.X, point.Y);
                        Console.Write(" ");
                    }
                    this.carPositionChanged = false;
                }
                foreach (var point in this.car.Nodes)
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.Write(point.Invisible ? ' ' : car.Character);
                }
                //
                //Rivals
                //
                {
                    for (int i = 0; i < this.rivals.Length; i++)
                    {
                        for (int j = 0; j < this.rivals[i].Nodes.Length; j++)
                        {
                            if (this.rivals[i].Nodes[j].Y >= 0 && this.rivals[i].Nodes[j].Y < 20)
                            {
                                Console.SetCursorPosition(this.rivals[i].Nodes[j].X, this.rivals[i].Nodes[j].Y);
                                Console.Write(this.rivals[i].Character);
                            }
                        }
                    }
                }
                if (this.rivalsPositionChanged)
                {
                    for (int i = 0; i < this.tempRivals.Length; i++)
                    {
                        for (int j = 0; j < this.rivals[i].Nodes.Length; j++)
                        {
                            if (this.tempRivals[i].Nodes[j].Y >= 0 && this.tempRivals[i].Nodes[j].Y < 20)
                            {
                                Console.SetCursorPosition(this.tempRivals[i].Nodes[j].X, this.tempRivals[i].Nodes[j].Y);
                                Console.Write(" ");
                            }
                        }
                    }
                    this.rivalsPositionChanged = false;
                }
            }
        }
    }
}
