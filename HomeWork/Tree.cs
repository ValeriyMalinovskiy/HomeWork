using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Tree : Plant
    {
        public int Harvest { get; private set; }

        public Tree(int height, int greeneryPercent) : base(height, greeneryPercent)
        {
        }

        public override void ChangeState(int water, int fertilizer)
        {
            base.ChangeState(water, fertilizer);
            if (water >= 1)
            {
                this.Harvest += water * 3;
                Console.WriteLine($"{this.GetType().Name} produced {water * 3} kilograms of harvest");
            }
        }
    }
}
