using System; //Importa las funciones básicas .NET

namespace Laboratorio92 //Para organizar el código
{
    class Program //Clase principal
    {
        private static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++) //Recorre los números del 1 al 100
            {
                if (i % 2 == 0) //Si el número es par 
                {
                    Console.WriteLine("Número par:                {0}", i);
                }
                else if (i % 3 == 0)//Si el número es divisible entre 3 residuo 0
                {
                    Console.WriteLine("Número divisible entre 3:  {0}", i);
                }
            }
        }
    }
}