using System;

namespace GestionReclamosRemastered.Core.DTOs
{
    public class RecuperoDto
    {
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
