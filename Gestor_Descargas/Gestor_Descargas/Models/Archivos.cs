using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor_Descargas.Models
{
    public class Archivos
    {
        [Key]
        public int idArchivos { get; set; }
        public string nombre { get; set; }
        public string version { get; set; }
        public string peso { get; set; }
       

    }
}
