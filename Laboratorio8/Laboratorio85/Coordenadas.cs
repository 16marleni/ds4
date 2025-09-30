using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio85
{
    public partial class Coordenadas
    {
        private int x;
        private int y;

        public Coordenadas(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public partial class Coordenadas //Definición parcial de la clase
    {
        public void VerCoordenadas()
        {
            Console.WriteLine("Coordenadas: {0}, {1}", x, y);
        }
    }
}
