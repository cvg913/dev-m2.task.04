using System;
using System.Collections.Generic;

#nullable disable

namespace dev_m2.task._03.Models
{
    public partial class Municipio
    {
        public Municipio()
        {
            Localidads = new HashSet<Localidad>();
        }

        public int EntidadId { get; set; }
        public int MunicipioId { get; set; }
        public string Nombre { get; set; }
        public int? PoblacionTotal { get; set; }
        public int? PoblacionMasculina { get; set; }
        public int? PolacionFemenina { get; set; }

        public virtual EntidaFederativa Entidad { get; set; }
        public virtual ICollection<Localidad> Localidads { get; set; }
    }
}
