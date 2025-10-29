using System; //Importa las funciones básicas .NET

namespace Laboratorio55 //Para organizar el código
{
    class Estudiante //Class y internal son equivalentes
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }

    class Program
    {
        static void Main(string[] args) //Punto de entrada del programa
        {

            List<Estudiante> estudiantes = new List<Estudiante>
            {
                new Estudiante { Nombre = "Ana", Edad = 12 },
                new Estudiante { Nombre = "Luis", Edad = 10 },
                new Estudiante { Nombre = "Sofia", Edad = 11 }
            };

            foreach (Estudiante estudiante in estudiantes)
            {
                Console.WriteLine("Nombre: " + estudiante.Nombre + ", Edad: " + estudiante.Edad);

            }

            Console.ReadKey(); //Pausa
        }
    }
}