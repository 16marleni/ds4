using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio12
{
    public class Movimiento
    {
        public double RVelocidad { get; set; }
        public double RTiempo { get; set; }

        public Movimiento(double Velocidad, double Tiempo)
        {
            RVelocidad = Velocidad;
            RTiempo = Tiempo;
        }

        public double CalcularDistancia()
        {
            return RVelocidad * RTiempo;
        }
    }
}
