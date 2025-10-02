using System; //Importa las funciones básicas .NET

namespace Laboratorio94 //Para organizar el código
{
    class Program //Clase principal
    {
        static void Main(string[] args)
        {
            Aleatorios ale = new Aleatorios();

            int num = ale.GenerarNumero(1, 100); //Genera un número aleatorio entre 1 y 100
            Console.WriteLine($"Número aleatorio entre 1 y 100: {num}");

            int[] arreglo = ale.GenerarArreglo(5, 10, 50); //Genera un arreglo de 5 números aleatorios entre 10 y 50
            Console.WriteLine("Arreglo de números aleatorios entre 10 y 50:");

            foreach (int valor in arreglo) //Imprime cada valor del arreglo
            {
                Console.WriteLine(valor);
            }
        }
    }
}