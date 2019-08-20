using System;

namespace HomeWork
{
    internal class Rival : RacingGameObject
    {
        public Rival(char character = '0', ConsoleColor color = ConsoleColor.DarkCyan, Position position = Position.Left) : base(character, color)
        {
            this.Nodes = new Node[7];
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                this.Nodes[i] = new Node();
            }
            switch (position)
            {
                case Position.Left:
                    {
                        this.Nodes[0].X = 2;
                        this.Nodes[0].Y = -5;
                        this.Nodes[1].X = 4;
                        this.Nodes[1].Y = -5;
                        this.Nodes[2].X = 3;
                        this.Nodes[2].Y = -6;
                        this.Nodes[3].X = 2;
                        this.Nodes[3].Y = -7;
                        this.Nodes[4].X = 3;
                        this.Nodes[4].Y = -7;
                        this.Nodes[5].X = 4;
                        this.Nodes[5].Y = -7;
                        this.Nodes[6].X = 3;
                        this.Nodes[6].Y = -8;
                    }
                    break;
                case Position.Right:
                    {
                        this.Nodes[0].X = 5;
                        this.Nodes[0].Y = -5;
                        this.Nodes[1].X = 7;
                        this.Nodes[1].Y = -5;
                        this.Nodes[2].X = 6;
                        this.Nodes[2].Y = -6;
                        this.Nodes[3].X = 5;
                        this.Nodes[3].Y = -7;
                        this.Nodes[4].X = 6;
                        this.Nodes[4].Y = -7;
                        this.Nodes[5].X = 7;
                        this.Nodes[5].Y = -7;
                        this.Nodes[6].X = 6;
                        this.Nodes[6].Y = -8;
                    }
                    break;
            }
        }

        public override void Move(Position position = Position.Down)
        {
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                this.Nodes[i].Y++;
            }
        }
    }
}
