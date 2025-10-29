using System; //Importa las funciones básicas .NET

namespace Laboratorio43 //Para organizar el código
{
    internal class Program //Clase principal donde esta el metodo main
    {
        static void Main(string[] args)
        {
            int suma, cant, valor, promedio;
            string linea;
            suma = 0;
            cant = 0;
            do
            {
                Console.Write("Ingrese un número (0 para finalizar): ");
                linea = Console.ReadLine();
                valor = int.Parse(linea); //Convierte la cadena a entero
                if (valor != 0)
                {
                    suma = suma + valor;
                    cant++;
                }  
            } while (valor != 0);
            if (cant != 0)
            {
                promedio = suma / cant;
                Console.Write("El promedio de los valores ingresados es: ");
                Console.Write(promedio);
            }
            else
            {
                Console.Write("No se ingresaron valores.");
            }
            Console.ReadKey(); //Lee una tecla para finalizar
        }
    }

}