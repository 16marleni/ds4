using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio89
{
    interface iTemplate
    {
        void ponerVariable(string nombre, string var); //No deben llevar public porque son públicos por defecto
        string verHtml(string template);
    }
}
