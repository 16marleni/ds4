using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio72
{
    internal class JuegoDeDados
    {
        private Dado dado1, dado2, dado3; //Atributos de la clase JuegoDeDados

        public JuegoDeDados() //Constructor de la clase JuegoDeDados
        {
            dado1 = new Dado();
            dado2 = new Dado();
            dado3 = new Dado();
        }

        public void Jugar() //Metodo para jugar con los dados
        {
            dado1.Tirar();
            dado1.Imprimir();
            dado2.Tirar();
            dado2.Imprimir();
            dado3.Tirar();
            dado3.Imprimir();
            if (dado1.RetornarValor() == dado2.RetornarValor() && dado1.RetornarValor() == dado3.RetornarValor())
            {
                Console.WriteLine("Ganó");
            }
            else
            {
                Console.WriteLine("Perdió");
            }

            Console.ReadKey(); //Espera a que el usuario presione una tecla antes de cerrar la consola


        }
    }
}
