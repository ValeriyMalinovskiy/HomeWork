using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    class Worker
    {
        public Tuple<int,int> TakeSomeAction()
        {
            Random rnd = new Random();
            return Tuple.Create<int, int>(rnd.Next(0, 4), rnd.Next(0, 3));
        }        
    }
}
