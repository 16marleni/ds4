using System; //Importa las funciones básicas .NET

namespace Laboratorio84 //Para organizar el código
{
    internal class Program //Clase principal
    {
        //Encapsulación con propiedades
        private static void Main(String[] args)
        {
            Empleado empleado = new Empleado();
            empleado.Nombre = "John Doe";
            Console.WriteLine($"Nombre del empleado: {empleado.Nombre}");

            CuentaBancaria cta = new CuentaBancaria();
            cta.Saldo = 100;
            Console.WriteLine($"El saldo del empleado es: {cta.Saldo}");
            //Probar después con un salfo negativo, para ver la excepción

            Cobertura c = new Cobertura(5);
            Console.WriteLine($"La cobertura es: {c.Radio}");
        }
    }
}