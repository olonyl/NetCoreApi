using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoLisbrosAPI.Models
{
    public class Estudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLector { get; set; }
        public string CI{ get; set; }
        public  string Nombre { get; set; }
        public string Dierccion { get; set; }   
        public string Carrera { get; set; }
        public int Edad { get; set; }
    }
}
