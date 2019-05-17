using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    public class Plant
    {
        public int Height { get; private set; }

        public int GreeneryPercent { get; private set; }

        private void AbsorbWater(int water)
        {
            //Console.WriteLine($"{this.GetType().Name} was watered with {water} liter(s)");
            this.Height += water * 2;
            Console.WriteLine($"{this.GetType().Name} grew by {water * 2} cm");
        }

        private void AbsorbMinerals(int fertiliizer)
        {
            //Console.WriteLine($"{this.GetType().Name} was enriched with {fertiliizer} kilograms of fertilizer");
            this.GreeneryPercent += fertiliizer * 3;
            Console.WriteLine($"{this.GetType().Name} became greener by {fertiliizer * 3} percent");
        }

        private void ProduceOxygen(int water, int fertilizer)
        {
            Console.WriteLine($"{water * fertilizer} cubic meters of oxygen was produced");
        }

        public virtual void ChangeState(int water, int fertilizer)
        {
            if (water >= 1)
            {
                this.AbsorbWater(water);
            }
            if (fertilizer >= 1)
            {
                this.AbsorbMinerals(fertilizer);
            }
            if (water >= 1 && fertilizer >= 1)
            {
                this.ProduceOxygen(water, fertilizer);
            }
        }

        public Plant(int height, int greeneryPercent)
        {
            this.Height = height;
            this.GreeneryPercent = greeneryPercent;
        }
    }
}
