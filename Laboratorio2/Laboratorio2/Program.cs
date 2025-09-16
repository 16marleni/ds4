using System;

namespace Laboratorio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            //Ejemplo utilizando las variables de instancia de Clase.
            client.FirstName = "Marleni";
            client.LastName = "Barría";
            client.Age = 23;
            client.Id = 8977;
        
            Console.WriteLine(client.GetFullName());
        }
    }

    public class Client
    {
        //Declarando variables de instancia en clase.
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ushort Age { get; set; }

        public string GetFullName()
        {
            //Utilizando variables de instacia dentro de metodos de la clase.
            return FirstName + " " + LastName;
        }

    }
}
