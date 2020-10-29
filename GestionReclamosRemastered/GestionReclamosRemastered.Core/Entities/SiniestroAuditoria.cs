using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Infrastructure.Data
{
    public partial class SiniestroAuditoria
    {
        public long IdStro { get; set; }
        public int IdTipoSiniestro { get; set; }
        public DateTime FechaSiniestro { get; set; }
        public DateTime FechaCarga { get; set; }
        public int IdUsuario { get; set; }
        public string TxtLugar { get; set; }
        public string TxtDominio { get; set; }
        public string TxtInterno { get; set; }
        public string TxtConductor { get; set; }
        public string TxtDeclaracion { get; set; }
        public int IdRepresentante { get; set; }
        public int IdEmpresa { get; set; }
        public string TxtObservaciones { get; set; }
        public long NroSiniestroProteccion { get; set; }
        public long NroReclamoProteccion { get; set; }
        public string Gestiona { get; set; }
        public double? DañoAsegurado { get; set; }
        public double? DañoTerecero { get; set; }
        public string TxtHora { get; set; }
        public int? IdResponsabilidad { get; set; }
    }
}
