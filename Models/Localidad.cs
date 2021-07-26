using System;
using System.Collections.Generic;

#nullable disable

namespace dev_m2.task._03.Models
{
    public partial class Localidad
    {
        public int EntidadId { get; set; }
        public int MunicipioId { get; set; }
        public int LocalidadId { get; set; }
        public string Nombre { get; set; }
        public string Ambito { get; set; }
        public decimal? LatitudDecimal { get; set; }
        public decimal? LongitudDecimal { get; set; }
        public int? Altitud { get; set; }
        public int? PoblacionTotal { get; set; }
        public int? PoblacionMasculina { get; set; }
        public int? PolacionFemenina { get; set; }

        public virtual Municipio Municipio { get; set; }
    }
}
