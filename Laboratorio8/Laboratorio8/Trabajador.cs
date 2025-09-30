using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio8
{
    class Trabajador : Persona //Herencia de la clase Persona
    {
        //Campo de cada objeto Trabajador que almacena cuanto gana
        public int Sueldo;

        public Trabajador(string nombre, int edad, string nif, int sueldo) : base(nombre, edad, nif)
        { //Inicializampos cada Trabajador en base al constructor de Persona
            Sueldo = sueldo;
        }
    }
}
