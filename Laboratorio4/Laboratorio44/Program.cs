using System; //Importa las funciones básicas .NET

namespace Laboratorio44 //Para organizar el código
{
    class Program //Class y internal son equivalentes
    {
        static void Main(string[] args)
        {
          Console.WriteLine("Ingrese la nota del estudiante");
          float score = float.Parse(Console.ReadLine());
          if (score >= 70)
          {
            Console.WriteLine(); //Espacio en blanco
            Console.WriteLine($"Su nota es {score} ha aprobado"); //$"{}" para interpolar variables en cadenas
          }
          else
          {
            Console.WriteLine();
            Console.WriteLine($"Su nota es {score} ha reprobado, debe repetir");
          }
        }
    }

}