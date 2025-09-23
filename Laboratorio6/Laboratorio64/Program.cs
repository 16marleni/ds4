using System; //Importa las funciones básicas .NET

namespace Laboratorio64 //Para organizar el código
{
    class Program
    {
        static void checkAge(int age) //Función que valida la edad
        {
          if (age < 18)
          {
                throw new ArithmeticException("Acceso negado - No cumple con el criterio de edad"); //Lanza una excepción si la edad es menor a 18
            }
          else
          {
                Console.WriteLine("Acceso Concedido");
          }
        }

        static void Main(string[] args)
        {
            checkAge(15); //Llamada a la función con un valor
        }
    }
}