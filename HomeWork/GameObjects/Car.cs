using System;

namespace HomeWork
{
    internal class Car : RacingGameObject
    {
        public Car(char character = '0', ConsoleColor color = ConsoleColor.Blue, Position position = Position.Left) : base(character, color)
        {
            this.Nodes = new Node[12];
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                this.Nodes[i] = new Node();
            }
            this.Nodes[0].X = 2;
            this.Nodes[0].Y = 19;
            this.Nodes[1].X = 4;
            this.Nodes[1].Y = 19;
            this.Nodes[2].X = 3;
            this.Nodes[2].Y = 18;
            this.Nodes[3].X = 2;
            this.Nodes[3].Y = 17;
            this.Nodes[4].X = 3;
            this.Nodes[4].Y = 17;
            this.Nodes[5].X = 4;
            this.Nodes[5].Y = 17;
            this.Nodes[6].X = 3;
            this.Nodes[6].Y = 16;
            this.Nodes[7].X = 3;
            this.Nodes[7].Y = 19;
            this.Nodes[7].IsDisabled = true;
            this.Nodes[8].X = 2;
            this.Nodes[8].Y = 18;
            this.Nodes[8].IsDisabled = true;
            this.Nodes[9].X = 4;
            this.Nodes[9].Y = 18;
            this.Nodes[9].IsDisabled = true;
            this.Nodes[10].X = 2;
            this.Nodes[10].Y = 16;
            this.Nodes[10].IsDisabled = true;
            this.Nodes[11].X = 4;
            this.Nodes[11].Y = 16;
            this.Nodes[11].IsDisabled = true;
        }

        public override void Move(Position position)
        {
            switch (position)
            {
                case Position.Left:
                    for (int i = 0; i < this.Nodes.Length; i++)
                    {
                        this.Nodes[i].X -= 3;
                    }
                    break;
                case Position.Right:
                    for (int i = 0; i < this.Nodes.Length; i++)
                    {
                        this.Nodes[i].X += 3;
                    }
                    break;
            }
        }
    }
}
