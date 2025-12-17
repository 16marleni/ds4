using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Resenas
    {
        [Key]
        public int ResenaId { get; set; } // Clave primaria

        [Required]
        [Display(Name = "Libro")]
        public int LibroId { get; set; } // FK a Libros

        [NotMapped]
        public string Libro { get; set; } // Título del libro para mostrar

        [Required(ErrorMessage = "El comentario es obligatorio.")]
        [StringLength(500, ErrorMessage = "El comentario no puede exceder 500 caracteres.")]
        public string Comentario { get; set; }

        [Required(ErrorMessage = "La calificación es obligatoria.")]
        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
        public int Calificacion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int UsuarioId { get; set; } // Usuario que registra la reseña

        [NotMapped]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

    }
}
