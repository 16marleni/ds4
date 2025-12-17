using System;

namespace ProyectoFinal.Models
{
    public class Prestamos
    {
        public int PrestamoId { get; set; }
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }

        // Campos de apoyo para vistas
        public string Usuario { get; set; }
        public string Libro { get; set; }

        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaVencimiento { get; set; } // ← OBLIGATORIA
        public DateTime? FechaDevolucion { get; set; } //Lleva el ? porque puede ser nulo
        public string Estado { get; set; }
    }
}
