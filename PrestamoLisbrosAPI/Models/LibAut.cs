using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoLisbrosAPI.Models
{
    public class LibAut
    {

        public int IdAutor { get; set; }
        [ForeignKey("IdAutor")]
        public Autor Autor { get; set; }
        public int IdLibro { get; set; }
        [ForeignKey("IdLibro")]
        public Libro Libro { get; set; }
    }
}
