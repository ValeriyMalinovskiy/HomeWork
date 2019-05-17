using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    class Program
    {
        static void Main(string[] args)
        {
            Gallery myGallery = new Gallery();
            myGallery.HireWorker(myGallery.CreateGallery());
        }

    }
}