using System; //Importa las funciones básicas .NET

namespace Laboratorio83 //Para organizar el código
{
    internal class Program //Clase principal
    {
        //Estamos sobrecargando el método Suma para que admita distintos tipos de datos
        //Su resultado es el mismo, pero la función se adapta al tipo de dato que recibe
        private static void Main(String[] args)
        {
            Console.WriteLine(Suma(1.0, 2.2)); //Se pueden cambiar los valores para probar cada método, dependiendo de los tipos de datos que reciba cada uno de ellos.
        }

        static int Suma(int x, int y)
        {
            //Función que suma dos enteros
            return x + y;
        }

        static double Suma(double x, double y) 
        {
            //Función que suma dos doubles
            return x + y;
        }

        static long Suma(long x, long y) //Los long son enteros largos
        {
            //Función que suma dos long
            return x + y;
        }
    }
}