using System; //Importa las funciones básicas .NET

namespace Laboratorio7 //Para organizar el código
{
    class Program
    {
        static void Main(string[] args) //Función principal
        {
            Banco banco1 = new Banco(); //Crea un objeto de la clase Banco
            banco1.Operar(); //Llama al método Operar del objeto banco1
            banco1.DepositosTotales(); //Llama al método DepositosTotales del objeto banco1
            Console.ReadKey(); //Espera a que el usuario presione una tecla antes de cerrar la consola
        }
    }
}