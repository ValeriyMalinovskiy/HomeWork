using System;

namespace HomeWork
{
    internal abstract class RacingGameObject
    {
        public ConsoleColor Color { get; set; }

        public char Character { get; set; }

        public Node[] Nodes { get; protected set; }

        public abstract void Move(Position position);

        public RacingGameObject(char character, ConsoleColor color)
        {
            this.Character = character;
            this.Color = color;
        }
    }
}
