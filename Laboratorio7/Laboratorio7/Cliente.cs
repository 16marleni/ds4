using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio7
{
    internal class Cliente
    {
        private string nombre;
        private int monto;

        public Cliente(string nom) //Constructor de la clase Cliente
        {
            nombre = nom;
            monto = 0;
        }

        public void Depositar(int m) //Metodo para depositar dinero donde void no retorna nada
        {
            monto = monto + m;
        }

        public void Extraer(int m) //Metodo para extraer dinero donde void no retorna nada
        { 
            monto = monto - m;
        }

        public int RetornarMonto() //Metodo para retornar el monto
        {
            return monto;
        }   

        public void Imprimir() //Metodo para imprimir el nombre y el monto
        {
            Console.WriteLine(nombre + " tiene depositado la suma de " + monto);
        }
    }
}
