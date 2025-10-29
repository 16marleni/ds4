using System; //Importa las funciones básicas .NET

namespace Laboratorio56 //Para organizar el código
{
    class Program
    {
        static void Main(string[] args) //Punto de entrada del programa
        {
            // Se crea un diccionario donde la clave es un país y el valor es su capital
            Dictionary<string, string> paisesYCapitales = new Dictionary<string, string>
            {
                {"Francia", "París"},
                {"España", "Madrid"},
                {"Italia", "Roma"},
            };

            // Bucle que recorre cada par clave-valor del diccionario
            foreach (KeyValuePair<string, string> par in paisesYCapitales)
            {
                Console.WriteLine("La capital de " + par.Key + " es " + par.Value + ".");

            }
        }
    }
}