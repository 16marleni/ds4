using System; //Importa las funciones básicas .NET

namespace Laboratorio62 //Para organizar el código
{
    class Program
    {
        static void Main(string[] args) //Punto de entrada del programa
        {
            int num;
            Console.WriteLine("Digite el número deseado");

            try
            {
                num = Int16.Parse(Console.ReadLine()); //Convierte la entrada en un número entero y el 16 indica que es un entero de 16 bits
            }
            catch (FormatException ex) //Captura el error en caso de que la entrada no sea un número
            {
                Console.WriteLine("No ha introducido un digito valido");
                num = -1; //Asignamos un valor por defecto en caso de error
            }catch (OverflowException ex) {
                Console.WriteLine("El número introducido es muy grande");
                num = -1; //Asignamos un valor por defecto en caso de error
            }

            Console.WriteLine(num);
        }
    }
}