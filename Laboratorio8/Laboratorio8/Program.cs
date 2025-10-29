using System; //Importa las funciones básicas .NET

namespace Laboratorio8 //Para organizar el código
{
    class Program //Clase principal
    {
        public static void Main()
        {
            Trabajador p = new Trabajador("Josan", 22, "77588260-Z", 100000); //Creamos un objeto Trabajador
            Console.WriteLine("Nombre:" + p.Nombre); //Mostramos el nombre del Trabajador
            Console.WriteLine("Edad:" + p.Edad); //Mostramos la edad del Trabajador
            Console.WriteLine("NIF:" + p.NIF); //Mostramos el NIF del Trabajador
            Console.WriteLine("Sueldo:" + p.Sueldo); //Mostramos el sueldo del Trabajador
            Console.ReadKey(); //Esperamos a que el usuario pulse una tecla
        }
    }
}