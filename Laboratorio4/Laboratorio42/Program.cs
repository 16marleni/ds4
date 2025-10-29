using System; //Importa las funciones básicas .NET

namespace Laboratorio42 //Para organizar el código
{
    internal class Program //Clase principal donde esta el metodo main
    {
        static void Main(string[] args)
        {
            int fac = 1, n;
            string linea;   
            Console.Write("Ingrese un número entero: ");
            linea = Console.ReadLine();
            n = int.Parse(linea); //Convierte la cadena a entero
            for (int i = 1; i <= n; i++)
            {
                fac = fac * i;
            }
            Console.Write("El factorial es: " + fac); //Factorial 1x2x3x...xn
            Console.ReadKey(); //Lee una tecla para finalizar    
        }
    }

}