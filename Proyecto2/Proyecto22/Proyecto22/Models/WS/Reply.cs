using System;

namespace Proyecto22.Models.WS
{
    public class Reply
    {
        public int Id { get; set; }
        public string Expresion { get; set; } = string.Empty;
        public decimal Resultado { get; set; }
        public DateTime Fecha { get; set; }
    }
}