using System; //Importa las funciones básicas .NET

namespace Laboratorio47 //Para organizar el código
{
    class Program //Class y internal son equivalentes
    {
        static void Main(string[] args)
        {
            int numeroUno = 70;
            double numeroDos = 67.89;
            double numeroTres = 67.89;

            Console.WriteLine(Suma(numeroUno, numeroDos));
            Console.WriteLine(Suma(numeroUno, numeroDos, numeroTres));

            //Compare y analice las salidas de las 2 sumas realizadas
        }
        static double Suma(int x, double y, double z = 0) //Parámetro opcional z con valor por defecto 0
        {
            return x + y + z;
        }
    }

}