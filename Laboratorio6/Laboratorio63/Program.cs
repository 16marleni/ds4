using System; //Importa las funciones básicas .NET

namespace Laboratorio63 //Para organizar el código
{
    class Program
    {
        static void Main(string[] args) //Punto de entrada del programa
        {
            try
            {
                int[] myNumbers = { 1, 2, 3 };
                Console.WriteLine(myNumbers[10]); //Esto genera un error, ya que el índice 10 no existe
            }
            catch (Exception e) //Captura cualquier tipo de error
            {
                Console.WriteLine("Algo salió mal, valide el indice del arreglo");
            }
            finally //Bloque que se ejecuta siempre, haya o no error
            {
                Console.WriteLine("Continuación de la aplicación, luego del bloque try/catch");
            }
        }
    }
}