using System; //Importa las funciones básicas .NET

namespace Laboratorio53 //Para organizar el código
{
    class Program //Class y internal son equivalentes
    {
        static void Main(string[] args)

        {
            string[] frutas = { "manzana", "plátano", "naranja" };

            foreach (string fruta in frutas)
            {
                Console.WriteLine(fruta);
            }
        }
    }
}


