using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio89
{
    class Template : iTemplate
    {
        public void ponerVariable(string nombre, string var)
        {
            Console.WriteLine("Método poner variable {nombre} : {var}");
        }

        public string verHtml(string template) //Simula la visualización de una plantilla HTML debe colocarse string
        {
            Console.WriteLine(template);
            return template;
        }
    }
}
