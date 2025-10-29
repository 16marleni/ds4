using System; //Importa las funciones básicas .NET

namespace Laboratorio45 //Para organizar el código
{
    class Program //Class y internal son equivalentes
    {
        static void Main(string[] args)
        {
            //Declaración de variables

            int edad1;
            int edad2;
            int edad3;
            int edad4;
            int edad5 = 31;

            //inicialización de variables
            edad1=edad2=edad3=edad4=32; //Coloca el mismo valor a varias variables

            Console.WriteLine("{0} , {1} , {2} , {3} , {4}", edad1, edad2, edad3, edad4, edad5);
        }
    }

}