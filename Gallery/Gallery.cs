using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    class Gallery
    {
        public Plant[] CreateGallery()
        {
            Plant[] plants =
            {
                new Tree(3, 20),
                new Flower(1, 40, ConsoleColor.Blue),
            };
            return plants;
        }

        public void HireWorker(Plant[] plants)
        {
            Worker vasya = new Worker();
            Tuple<int, int> vasaysDecision;
            for (int i = 0; i < 50; i++)
            {
                foreach (var item in plants)
                {
                    vasaysDecision = vasya.TakeSomeAction();
                    item.ChangeState((vasaysDecision.Item1), (vasaysDecision.Item2));
                }
            }
        }
    }
}
