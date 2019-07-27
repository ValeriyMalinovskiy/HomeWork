using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork
{
    class GameLogic
    {
        RoadBoundary roadBoundary = new RoadBoundary();

        public void TestPrint()
        {
            while (true)
            {
                Console.Clear();
                roadBoundary.MoveBoundary();
                foreach (var block in roadBoundary.BoundaryCoordinate)
                {
                    Console.SetCursorPosition(block.Item1, block.Item2);
                    Console.Write("#");
                }
                Thread.Sleep(100);
            }
        }
    }
}
