using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class MediacionAuditoria
    {
        public long? IdMediacion { get; set; }
        public long IdStro { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string TxtCaratula { get; set; }
        public string TxtLetradoActora { get; set; }
        public string TxtLetradoDemanda { get; set; }
        public string TxtMediador { get; set; }
        public string TxtNroExpediente { get; set; }
        public int? SnCerradaConAcuerdo { get; set; }
        public int? SnActaDeCierre { get; set; }
        public string FechaCarga { get; set; }
        public int? IdUsuario { get; set; }
    }
}
