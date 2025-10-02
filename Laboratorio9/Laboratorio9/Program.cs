using System; //Importa las funciones básicas .NET

namespace Laboratorio9 //Para organizar el código
{
    class Program //Clase principal
    {
        private static void Main(string[] args)
        {
            double precio;
            string formaPagar;
            string nCuenta; //Usamos string para que los 0 a la izquierda no se pierdan

            do
            {
                Console.WriteLine("\nIngrese el precio del producto: ");
                precio = Convert.ToDouble(Console.ReadLine());

                if (precio <= 0) //Valida que el precio sea mayor a 0
                {
                    Console.WriteLine("Precio inválido. Debe ser mayor a 0.");
                }

            } while (precio <= 0);
            
            Console.WriteLine("Ingrese su método de pago (efectivo o tarjeta): ");
            formaPagar = Console.ReadLine(); //Lee la forma de pago ingresada por el usuario

            if (string.Equals(formaPagar, "efectivo", StringComparison.OrdinalIgnoreCase)) //Compara la cadena ingresada con "efectivo" sin importar mayúsculas o minúsculas
            {
              Console.WriteLine("Pago realizado en efectivo. Gracias por su compra.");
            }

            else if (string.Equals(formaPagar, "tarjeta", StringComparison.OrdinalIgnoreCase)) //Compara la cadena ingresada con "tarjeta" sin importar mayúsculas o minúsculas
            {
              Console.WriteLine("Ingrese su número de cuenta de 16 dígitos: ");
              nCuenta = Console.ReadLine(); //Lee el número de cuenta ingresado por el usuario

                if (nCuenta.Length == 16 && nCuenta.All(char.IsDigit)) //Valida que el número de cuenta tenga exactamente 16 dígitos y que todos los caracteres sean dígitos
                {
                    Console.WriteLine("Pago realizado con tarjeta. Gracias por su compra.");
                }
                else 
                {
                    Console.WriteLine("Número de cuenta inválido. Debe tener 16 dígitos.");

                    Console.WriteLine("\nIngrese nuevamente su número de cuenta de 16 dígitos: ");
                    nCuenta = Console.ReadLine(); //Lee el número de cuenta ingresado por el usuario

                    if (nCuenta.Length == 16 && nCuenta.All(char.IsDigit))
                    {
                       Console.WriteLine("Pago realizado con tarjeta. Gracias por su compra.");
                    }
                    else
                    {
                       Console.WriteLine("Número de cuenta inválido. Transacción cancelada.");
                    }
                }
            }
            else
            {
              Console.WriteLine("Método de pago no reconocido.");
            }

          Console.ReadKey(); //Mantiene la consola abierta hasta que se presione una tecla
        }
    }
}