using System; //Importa las funciones básicas .NET

namespace Laboratorio54 //Para organizar el código
{
    class Program //Class y internal son equivalentes
    {
        static void Main(string[] args)

        {
            List<int> calificaciones = new List<int> { 85, 90, 78, 92, 88 };

            int suma = 0;

            foreach (int calificacion in calificaciones)
            {
                suma += calificacion;
            }

            double promedio = suma / (double)calificaciones.Count; // Convertimos a double para obtener un resultado decimal (double)calificaciones.Count sirve para convertir un tipo de dato a otro
            Console.WriteLine($"El promedio de las calificaciones es: {promedio}");
        }
    }
}