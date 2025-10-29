using System; //Importa las funciones básicas .NET

namespace Laboratorio46 //Para organizar el código
{
    class Program //Class y internal son equivalentes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite el radio del círculo");
            double radio = double.Parse(Console.ReadLine());

            double area = Math.Pow(radio, 2) * Math.PI; //Math.PI asigna valor de PI y Math.Pow para potencia

            Console.WriteLine($"El área del círculo es: {area}");
        }
    }

}