using System; //Importa las funciones básicas .NET

namespace Laboratorio72 //Para organizar el código
{
    class Program
    {
        static void Main(string[] args) //Función principal
        {
            JuegoDeDados j = new JuegoDeDados(); //Crea un objeto de la clase JuegoDeDados
            j.Jugar(); //Llama al método Jugar del objeto j
        }
    }
}