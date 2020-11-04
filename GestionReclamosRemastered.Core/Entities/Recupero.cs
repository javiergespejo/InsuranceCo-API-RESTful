using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class Recupero : BaseEntity
    {
        public long IdRecupero { get; set; }
        public DateTime FechaReclamo { get; set; }
        public string CiaSeguro { get; set; }
        public double MontoReclamado { get; set; }
        public double CostoReparacionUnidad { get; set; }
        public double LucroCesante { get; set; }
        public int DiasDetencionUnidad { get; set; }
        public double PerdidaValorUnidad { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FecCarga { get; set; }
        public long IdStro { get; set; }
        public DateTime FecEstimPago { get; set; }
    }
}
