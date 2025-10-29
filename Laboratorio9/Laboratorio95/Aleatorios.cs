using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio95
{
    public class Aleatorios
    {
        private Random generador; //Generador de números aleatorios private significa que solo es accesible dentro de la clase Aleatorios

        public Aleatorios() //Constructor
        {
            generador = new Random(); //Inicializa el generador de números aleatorios
        }
        public int[] GenerarArregloUnico(int size, int min, int max)
        {
            if (size > max)
                throw new ArgumentException("La cantidad no puede ser mayor que el rango máximo.");//Validación de entrada para saber si la cantidad es mayor que el rango máximo

            List<int> numeros = new List<int>(); //Lista para almacenar los números únicos
            for (int i = min; i < max; i++)
            {
                numeros.Add(i); //Llena la lista con números en el rango [min, max)
            }

            // Mezclar la lista usando el generador definido
            for (int i = numeros.Count - 1; i > 0; i--) //Algoritmo de Fisher-Yates para mezclar count significa la cantidad de elementos en la lista
            {                                           //El algioritmo recorre la lista desde el final hasta el principio luego intercambia cada elemento con otro elemento aleatorio que esté antes de él (incluyéndolo)
                int j = generador.Next(i + 1); //Genera un índice aleatorio j en el rango [0, i]
                (numeros[i], numeros[j]) = (numeros[j], numeros[i]); //Intercambia los elementos en las posiciones i y j
            }

            return numeros.GetRange(0, size).ToArray(); //Devuelve los primeros 'cantidad' números de la lista mezclada como un arreglo
        }                                               //GetRange(0, size) obtiene los primeros 'size' elementos de la lista y ToArray() los convierte en un arreglo

    }
}

// Recordar que min y max son valores, i y j son índices y size es la cantidad de números únicos que se desean generar.
// El segundo for es el algoritmo de Fisher-Yates para mezclar la lista de números, donde se intercambian los elementos en las posiciones i y j, como ejemplo: 
// Si la lista es [10, 20, 30, 40, 50 ] y i=4 (último índice) y j=1 (índice aleatorio generado), después del intercambio la lista sería [10, 50, 30, 40, 20].

