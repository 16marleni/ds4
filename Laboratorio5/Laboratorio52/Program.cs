using System; //Importa las funciones básicas .NET

namespace Laboratorio52 //Para organizar el código
{
    class Matriz //Class y internal son equivalentes
    {
        private int[,] mat; //Declaramoos un vector

        public void Ingresar()
        {
            mat = new int[3,4]; //Inicializamos la matriz en 3 filas y 4 columnas (0 a 2 y 0 a 3)
            for (int f = 0; f < 3; f++) //Recorremos las filas
            {
                for (int c = 0; c < 4; c++) //Recorremos las columnas
                {
                    Console.Write("Ingrese posicion [" + (f + 1) + "," + (c + 1) + "]: "); //Solicitamos el valor
                    String linea;
                    linea = Console.ReadLine(); //Leemos la línea
                    mat[f, c] = int.Parse(linea);
                }
               
            }
        }

      
        public void Imprimir()
        {
           for (int f = 0; f < 3; f++) //Recorremos las filas
            {
                for (int c = 0; c < 4; c++) //Recorremos las columnas
                {
                    Console.Write(mat[f, c] + " "); //Mostramos los valores
                }
                Console.WriteLine();
            }
            Console.ReadKey(); //Pausa
        }

        //Main principal
        static void Main(string[] args)
        {
            Matriz ma = new Matriz (); //Creamos el objeto ma de la clase Matriz
            ma.Ingresar(); //Invocamos al método Ingresar
            ma.Imprimir(); //Invocamos al método Imprimir
        }
    }

}