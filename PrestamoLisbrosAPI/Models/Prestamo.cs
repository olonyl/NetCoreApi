using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestamoLisbrosAPI.Models
{
    public class Prestamo
    {
        public int IdLector { get; set; }
        [ForeignKey("IdLector")]
        public Estudiante Lector { get; set; }
        public int IdLibro { get; set; }
        [ForeignKey("IdLibro")]
        public Libro Libro { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaPrestamo { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaDevolucion { get; set; }
        [DefaultValue("false")]
        public bool Devuelto { get; set; }
}

}
