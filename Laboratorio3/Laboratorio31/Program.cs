using System; //Importa las funciones básicas .NET

namespace Laboratorio31 //Para organizar el código
{
    internal class Program //Clase principal donde esta el metodo main
    {
        static void Main(string[] args)
        {
            CalculosMatematicos calculos = new CalculosMatematicos(); //Objeto de la clase CalculosMatematicos
            Console.WriteLine("Ingrese el primer número: ");
            int primerNumero = Convert.ToInt32(Console.ReadLine()); //Convert para tomar el valor numerico del texto introducido
            Console.WriteLine("Ingrese el segundo número: ");
            int segundoNumero = Convert.ToInt32(Console.ReadLine());
            int suma = primerNumero + segundoNumero;
            Console.WriteLine("La suma de {0} y {1} es {2}", primerNumero, segundoNumero, suma); //$ Para iterpolación de cadenas {primerNumero} valido y no con error

            int resultado = calculos.Calcular(primerNumero, segundoNumero);
            Console.WriteLine("El resultado de la operacion es: {0}", resultado);
        }
    }

    public class CalculosMatematicos
    {
        public int Calcular(int a, int b) => (a + b) * (a - b); //Expresión lambda => forma para una sola expresión.
    }
}
