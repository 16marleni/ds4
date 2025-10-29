using System; //Importa las funciones básicas .NET

namespace Laboratorio82 //Para organizar el código
{
    internal class Program //Clase principal
    {
        public static void Main(String[] args)
        {
            const string CUENTA = "100";

            Cuenta cuenta = new Cuenta(CUENTA); //New hace que se imprima nuevamente "Constructor..." por eso se muestra 3 veces la frase en consola.
            CuentaCorriente cuentaCorriente = new CuentaCorriente(CUENTA);
            CuentaAhorro cuentaAhorro = new CuentaAhorro(CUENTA);
            cuenta.CalcularIntereses();
            cuentaCorriente.CalcularIntereses();
            cuentaAhorro.CalcularIntereses();
        }
    }
}