using System; //Importa las funciones básicas .NET

namespace Laboratorio93 //Para organizar el código
{
    class Program //Clase principal
    {
        private static void Main(string[] args)
        {
            double lado1, lado2, lado3; //Variables para los lados del triángulo

            Console.WriteLine("Ingrese el lado # 1 del triángulo: ");
            lado1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese el lado # 2 del triángulo: ");
            lado2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese el lado # 3 del triángulo: ");
            lado3 = Convert.ToDouble(Console.ReadLine());

            if (lado1 + lado2 > lado3 && lado1 + lado3 > lado2 && lado2 + lado3 > lado1) //Condición para que los lados formen un triángulo
            {

                if ((lado1 == lado2) && (lado2 == lado3)) //Si los tres lados son iguales
                {
                    Console.WriteLine("El triángulo es equilátero.");
                }
                else if ((lado1 == lado2) || (lado2 == lado3) || (lado1 == lado3)) //Si dos lados son iguales
                {
                    Console.WriteLine("El triángulo es isósceles.");
                }
                else //Si ningún lado es igual
                {
                    Console.WriteLine("El triángulo es escaleno.");
                }
            }
            else
            {
                Console.WriteLine("Los lados ingresados no forman un triángulo.");
            }

            Console.ReadKey(); //Mantiene la consola abierta hasta que se presione una tecla
            
        }
    }
}
