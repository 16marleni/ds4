using System; //Importa las funciones básicas .NET

namespace Laboratorio88 //Para organizar el código
{
    internal class Program //Clase principal
    {
        private static void Main(String[] args)
        {
            ClaseConcreta1 concreta1 = new ClaseConcreta1();
            concreta1.printOut();
            Console.WriteLine(concreta1.prefixValor("ES_"));

            ClaseConcreta2 concreta2 = new ClaseConcreta2();
            concreta2.printOut();
            Console.WriteLine(concreta2.prefixValor("ES_"));
        }
    }
}