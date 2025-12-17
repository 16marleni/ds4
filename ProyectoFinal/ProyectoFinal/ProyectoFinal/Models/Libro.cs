using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Libro
    {
        public int LibroId { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        public string Autor { get; set; }

        [Display(Name = "Categoría")]
        public string Categoria { get; set; }
        public bool Disponible { get; set; }
        public int Cantidad { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}