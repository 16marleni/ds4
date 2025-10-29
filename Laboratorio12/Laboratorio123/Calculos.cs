using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio123
{
    internal class Calculos
    {
        public double RLadoA { get; set; }
        public double RLadoB { get; set; }
        public double RLadoC { get; set; }
        public double semiperimetro { get; set; }
        public double area { get; set; }

        public Calculos(double LadoA, double LadoB, double LadoC)
        {
            RLadoA = LadoA;
            RLadoB = LadoB;
            RLadoC = LadoC;
        }

        public double CalcularSemiperimetro()
        {
            semiperimetro = (RLadoA + RLadoB + RLadoC) / 2;
            return semiperimetro;
        }

        public double CalcularArea()
        {
            area = Math.Sqrt(semiperimetro*(semiperimetro -  RLadoA) * (semiperimetro - RLadoB) * (semiperimetro - RLadoC));
            return area;
        }

    }
}
