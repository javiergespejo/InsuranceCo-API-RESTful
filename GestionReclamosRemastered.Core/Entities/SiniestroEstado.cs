using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class SiniestroEstado
    {
        public long IdSiniestroEstado { get; set; }
        public long IdStro { get; set; }
        public DateTime Fecha { get; set; }
        public int IdInstancia { get; set; }
        public int IdSituacion { get; set; }
        public int IdUsuario { get; set; }
    }
}
