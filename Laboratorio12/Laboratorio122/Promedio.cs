using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio122
{
    internal class Promedio
    {
        public double RNota1 { get; set; }
        public double RNota2 { get; set; }
        public double RNota3 { get; set; }

        public Promedio(double Nota1, double Nota2, double Nota3)
        {
            RNota1 = Nota1;
            RNota2 = Nota2;
            RNota3 = Nota3;
        }

        public double CalcularPromedio()
        {
            return (RNota1 + RNota2 + RNota3) / 3;
        }
    }
}
