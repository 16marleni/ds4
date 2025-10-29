using System; //Importa las funciones básicas .NET

namespace Laboratorio4 //Para organizar el código
{
    internal class Program //Clase principal donde esta el metodo main
    {
        static void Main(string[] args)
        {
            int n, x;
            string linea;
            Console.Write("Ingrese el valor de n: ");
            linea = Console.ReadLine();
            n = int.Parse(linea); //Convierte la cadena a entero
            x = 1;
            while (x <= n) 
            {
                Console.Write(x); //Solo write escribe en la misma línea
                Console.Write(" , ");
                x = x + 1;
            }
            Console.ReadKey();
        }
    }

}