using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio72
{
    internal class Dado
    {
        private int valor;
        private static Random aleatorio; //Atributo estatico para que todos los objetos compartan la misma instancia de Random

        public Dado() //Constructor de la clase Dado
        {
            aleatorio = new Random();
        }

        public void Tirar() //Metodo para tirar el dado
        {
            valor = aleatorio.Next(1, 7); //Genera un número aleatorio entre 1 y 6
        }

        public void Imprimir()
        {
            Console.WriteLine("El valor del dado es: " + valor);
        }

        public int RetornarValor()
        {
            return valor;
        }
    }
}
