using System;
using System.Collections.Generic;
using System.Text;

namespace GestionReclamosRemastered.Core.QueryFilters
{
    public class SiniestroQueryFilter
    {
        public long? NroSiniestroProteccion { get; set; }
        public string? TxtConductor { get; set; }
        public DateTime? FechaSiniestro { get; set; }
    }
}
