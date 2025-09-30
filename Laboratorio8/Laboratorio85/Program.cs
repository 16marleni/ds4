using System; //Importa las funciones básicas .NET

namespace Laboratorio85 //Para organizar el código
{
    internal class Program //Clase principal
    {
        //Partial class
        private static void Main(String[] args)
        {
            Coordenadas misCoords = new Coordenadas(10, 15);
            misCoords.VerCoordenadas();
        }
    }
}