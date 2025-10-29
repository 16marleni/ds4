using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio86
{
    class ClaseBase
    {
        public void test()
        {
        }

        public virtual void masTests() //Antes método sellado con sealed para que no pueda ser sobreescrito se debe usar virtual para que pueda ser sobreescrito con override
        {
        }
    }
}
