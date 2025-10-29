using System; //Importa las funciones básicas .NET

namespace Laboratorio95 //Para organizar el código
{
    class Program //Clase principal
    {
        static void Main(string[] args)
        {
            Aleatorios ale = new Aleatorios();

            int[] arreglo = ale.GenerarArregloUnico(5, 20, 30); //Genera un arreglo de 5 números aleatorios únicos entre 10 y 50
            Console.WriteLine("Arreglo de números aleatorios sin repeticiones entre 20 y 30:");

            foreach (int valor in arreglo) //Imprime cada valor del arreglo
            {
                Console.WriteLine(valor);
            }
        }
    }
}