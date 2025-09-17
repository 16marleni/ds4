using System; //Importa las funciones básicas .NET

namespace Laboratorio32 //Para organizar el código
{
    internal class Program //Clase principal donde esta el metodo main
    {
        static void Main(string[] args)
        {
            CalculosMatematicos calculos = new CalculosMatematicos(); //Objeto de la clase CalculosMatematicos
            Console.WriteLine("Ingrese el primer número para suma y calcular: ");
            int primerNumero = Convert.ToInt32(Console.ReadLine()); //Convert para tomar el valor numerico del texto introducido
            Console.WriteLine("Ingrese el segundo número para suma y calcular: ");
            int segundoNumero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el tercer número para radio del área del circulo: ");
            double tercerNumero = Convert.ToDouble(Console.ReadLine());
            int suma = primerNumero + segundoNumero;
            Console.WriteLine("La suma de {0} y {1} es {2}", primerNumero, segundoNumero, suma); //$ Para iterpolación de cadenas {primerNumero} valido y no con error

            int resultado1 = calculos.Calcular(primerNumero, segundoNumero);
            Console.WriteLine("El resultado de la operacion es: {0}", resultado1);

            double resultado2 = calculos.CalculoArea(tercerNumero);
            Console.WriteLine("El área del círculo con radio {0} es {1:F2}", tercerNumero, resultado2); //El F2 es para la cantidad de decimales
        }
    }

    public class CalculosMatematicos
    {
        public int Calcular(int a, int b) => (a + b) * (a - b); //Expresión lambda => forma para una sola expresión.
        public double CalculoArea(double c) => Math.PI * Math.Pow(c, 2); // PI ingresa directamente el valor de PI y Pow para potencias
    }
}