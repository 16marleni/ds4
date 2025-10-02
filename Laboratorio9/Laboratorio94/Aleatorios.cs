using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio94
{
    public class Aleatorios
    {
        private Random generador;

        public Aleatorios()
        {
            generador = new Random();
        }

        // Método para generar un número entero aleatorio entre min y max
        public int GenerarNumero(int min, int max)
        {
            return generador.Next(min, max); //next(min, max) genera un número aleatorio en el rango [min, max)
        }

        // Método para generar un arreglo de números aleatorios
        // size: tamaño del arreglo
        // min, max: rango de los números generados
        public int[] GenerarArreglo(int size, int min, int max)
        {
            int[] arreglo = new int[size]; //Crea un arreglo de enteros con el tamaño especificado

            for (int i = 0; i < size; i++) //Llena el arreglo con números aleatorios
            {
                arreglo[i] = generador.Next(min, max); //next(min, max) genera un número aleatorio en el rango [min, max)
            }

            return arreglo;
        }
    }
}

