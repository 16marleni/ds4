using System; //Importa las funciones básicas .NET

namespace Laboratorio5 //Para organizar el código
{
    class PruebaVector1 //Class y internal son equivalentes
    {
        private int[] sueldos; //Declaramoos un vector

        public void Cargar()
        {
            sueldos = new int[5]; //Inicializamos el vector en 5 (0 a 4)
            for (int f = 0; f <= 4; f++) //Recorremos el vector es lo mismo que f<5
            {
                Console.Write("Ingrese el sueldo del operario "+(f+1)+": "); //Solicitamos el sueldo
                String linea;
                linea = Console.ReadLine(); //Leemos la línea
                sueldos[f] = int.Parse(linea); //Asignamos los 5 sueldos al vector
            }
        }

        //Muestra los sueldos de los operarios en el vector sueldos [f]
        public void Imprimir()
        {
            Console.WriteLine("Los 5 sueldos de los operarios \n");
            for (int f = 0; f <= 4; f++) //Recorremos el vector
            {
                Console.WriteLine("["+sueldos[f]+"]"); //Mostramos los sueldos
            }
            Console.ReadKey(); //Pausa
        }

        //Main principal
        static void Main(string[] args)
        {
            PruebaVector1 pv = new PruebaVector1(); //Creamos el objeto pv de la clase PruebaVector1
            pv.Cargar(); //Invocamos al método Cargar
            pv.Imprimir(); //Invocamos al método Imprimir
        }   
    }

}