using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class Juicio
    {
        public int IdJuicio { get; set; }
        public long IdStro { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TxtCaratula { get; set; }
        public string NroExpediente { get; set; }
        public DateTime? FechaNotificacion { get; set; }
        public int? IdTipoProceso { get; set; }
        public string TxtJuzgado { get; set; }
        public string TxtLetradoEmpresa { get; set; }
        public string TxtDomicilioEmpresa { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCarga { get; set; }
        public int IdUsuario { get; set; }

        public virtual Siniestro IdStroNavigation { get; set; }
    }
}
