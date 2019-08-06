using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal abstract class RacingGameObject
    {

        public virtual bool Move(Func<, bool>) { }
    }
}
