using System; // Importa el espacio de nombres para clases básicas
using System.Data; // Importa el espacio de nombres para DataTable
using System.Text.RegularExpressions; // Importa el espacio de nombres para expresiones regulares


namespace Proyecto1 //Nombre del Proyecto
{

    public static class Calculos
    {
        // Evalúa una operación matemática básica como "2 + 3 * 4" no evalua funicones complejas
        public static double EvaluarOperacion(string operacion)
        {
            try
            {
                var resultado = new DataTable().Compute(operacion, null); //El DataTable Compute evalua la operacion y  devuelve el resultado, var es un tipo de dato implicito que toma el tipo de dato del valor asignado
                return Convert.ToDouble(resultado); // Convierte el resultado a double y lo retorna
            }
            catch (Exception)
            {
                throw new Exception("Operación inválida"); // Lanza una excepción si la operación es inválida
            }
        }

        // Aplica funciones matemáticas a un valor individual

        //Este método toma una cadena que representa una función matemática (como raíz cuadrada, potencia al cuadrado, potencia al cubo o porcentaje) y un valor numérico. Dependiendo de la función especificada, aplica la operación correspondiente al valor y devuelve el resultado.
        //Trabaja en conjunto con el método ProcesarFunciones para evaluar expresiones matemáticas que incluyen estas funciones.
        //AplicarFuncion se utiliza para realizar cálculos específicos en números individuales, mientras que ProcesarFunciones se encarga de identificar y reemplazar estas funciones dentro de una expresión matemática más amplia.
        public static double AplicarFuncion(string funcion, double valor)
        {
            switch (funcion)
            {
                case "√":
                    return Math.Sqrt(valor); //Math.Sqrt calcula la raíz cuadrada de un número
                case "^2":
                    return Math.Pow(valor, 2); //Math.Pow eleva un número a una potencia específica
                case "^3":
                    return Math.Pow(valor, 3);
                case "%":
                    return valor / 100; // Convierte un porcentaje a su valor decimal
                default:
                    throw new Exception("Función desconocida"); // Lanza una excepción si la función es desconocida
            }
        }

        // Procesar funciones como raíz, potencia y porcentaje en una expresión
        public static string ProcesarFunciones(string expresion)
        {
            // Raíz cuadrada: √n
            expresion = Regex.Replace(expresion, @"√\s*(\d+(\.\d+)?)", match => // Busca el patrón de raíz cuadrada y lo reemplaza
            {
                double valor = Convert.ToDouble(match.Groups[1].Value); // Convierte el valor encontrado a double
                return Calculos.AplicarFuncion("√", valor).ToString(); // Aplica la función de raíz cuadrada y devuelve el resultado como cadena
            });

            // Potencia cuadrada: n x² o n ^2
            expresion = Regex.Replace(expresion, @"(\d+(\.\d+)?)\s*(x²|\^2)", match => // @ obligatorio para cadenas literales (decimal o no) espacio o no ? (signos para potencia)
            {
                double valor = Convert.ToDouble(match.Groups[1].Value);
                return Calculos.AplicarFuncion("^2", valor).ToString();
            });

            // Potencia cúbica: n x³ o n ^3
            expresion = Regex.Replace(expresion, @"(\d+(\.\d+)?)\s*(x³|\^3)", match =>
            {
                double valor = Convert.ToDouble(match.Groups[1].Value);
                return Calculos.AplicarFuncion("^3", valor).ToString();
            });

            // Porcentaje relativo en suma o resta: ej. 100 - 50%
            expresion = Regex.Replace(expresion, @"(\d+(\.\d+)?)([\+\-])(\d+(\.\d+)?)%", match => //regex convierte la expresion en grupos para su posterior uso
            {
                double baseNum = Convert.ToDouble(match.Groups[1].Value);
                string operador = match.Groups[3].Value; // math.Groups[3] es el operador + o -
                double porcentaje = Convert.ToDouble(match.Groups[4].Value);

                double resultado = operador == "+" //Expresión ternaria condicional
                    ? baseNum + (baseNum * porcentaje / 100) //valor verdadero
                    : baseNum - (baseNum * porcentaje / 100); //valor falso

                return resultado.ToString();
            });

            // Porcentaje directo: ej. 50% → 0.5 (para multiplicaciones o divisiones)
            expresion = Regex.Replace(expresion, @"(\d+(\.\d+)?)\s*%", match =>
            {
                double valor = Convert.ToDouble(match.Groups[1].Value);
                return Calculos.AplicarFuncion("%", valor).ToString(); // valor / 100
            });

            return expresion;

        }
    }
}

