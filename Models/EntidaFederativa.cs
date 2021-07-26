using System;
using System.Collections.Generic;

#nullable disable

namespace dev_m2.task._03.Models
{
    public partial class EntidaFederativa
    {
        public EntidaFederativa()
        {
            Municipios = new HashSet<Municipio>();
        }

        public int EntidadId { get; set; }
        public string Nombre { get; set; }
        public string NombreAbreviado { get; set; }
        public int? PoblacionTotal { get; set; }
        public int? PoblacionMasculina { get; set; }
        public int? PoblacionFemenina { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
