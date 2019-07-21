using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Flower : Plant
    {
        public ConsoleColor BlossomColor { get; private set; }

        public Flower(int height, int greeneryPercent, ConsoleColor blossomColor) : base (height, greeneryPercent)
        {
            this.BlossomColor = blossomColor;
        }

        public override void ChangeState(int water, int fertilizer)
        {
            if (water>=0||fertilizer>=0)
            {
                Random rnd = new Random();
                this.BlossomColor = (ConsoleColor)rnd.Next(1, 16);
            }
            Console.ForegroundColor = this.BlossomColor;
            base.ChangeState(water, fertilizer);
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
    }
}
