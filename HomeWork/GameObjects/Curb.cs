using System;

namespace HomeWork
{
    internal class Curb : RacingGameObject
    {
        public Curb(char character = '|', ConsoleColor color = ConsoleColor.White, Position position = Position.Left) : base(character, color)
        {
            this.Nodes = new Node[40];
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                Nodes[i] = new Node();
            }
            for (int i = 0, j = 0; i < this.Nodes.Length; i++)
            {
                if (i < 20)
                {
                    this.Nodes[i].X = 0;
                    this.Nodes[i].Y = i;
                }
                else
                {
                    this.Nodes[i].X = 9;
                    this.Nodes[i].Y = j;
                    j++;
                }
                this.Nodes[i].IsDisabled = (i % 4 == 0) ? true : false;
            }
        }

        public override void Move(Position position = Position.Down)
        {
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                if (this.Nodes[i].Y == 19)
                {
                    this.Nodes[i].Y = 0;
                }
                else
                {
                    this.Nodes[i].Y++;
                }
            }
        }
    }
}

