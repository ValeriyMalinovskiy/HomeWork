using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HomeWork
{
    internal abstract class RacingGameObject
    {
        public ConsoleColor Color { get; protected set; }

        public Char Character { get; set; }

        public Node[] Nodes { get; protected set; }

        public abstract void Move(Position position);

        public RacingGameObject(Char character)
        {
            this.Character = character;
        }
    }
}
