using System; //Importa las funciones básicas .NET

namespace Laboratorio89 //Para organizar el código
{
    internal class Program //Clase principal
    {
        private static void Main(String[] args)
        {
            Template temp1 = new Template(); //Se instancia la clase Template
            temp1.ponerVariable("var1", "Valor 1"); //Se definen las variables a reemplazar en el HTML
            temp1.ponerVariable("var2", "Valor 2");
            temp1.ponerVariable("var3", "Valor 3");
            temp1.verHtml("<br>Texto de Prueba</br>"); //Se imprime el HTML con las variables reemplazadas
        }
    }
}

//La  diferencia entre una clase abstracta y una interfaz es que la clase abstracta puede contener implementación de métodos y propiedades, mientras que una interfaz solo puede contener definiciones de métodos y propiedades sin implementación. Una clase puede heredar de una sola clase abstracta, pero puede implementar múltiples interfaces. Las clases abstractas se utilizan cuando hay una relación "es un" entre la clase base y las clases derivadas, mientras que las interfaces se utilizan para definir un contrato que las clases pueden implementar, independientemente de su posición en la jerarquía de clases.