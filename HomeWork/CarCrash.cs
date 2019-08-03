using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class CarCrash
    {
        public bool Check(Car car, IEnumerable<OncomingCar> rivals)
        {
            foreach (var rival in rivals)
            {
                foreach (var carPoint in car.Coordinates)
                {
                    foreach (var rivalPoint in rival.Coordinates)
                    {
                        if (rivalPoint.Item1 == carPoint.Item1 && rivalPoint.Item2 == carPoint.Item2)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
