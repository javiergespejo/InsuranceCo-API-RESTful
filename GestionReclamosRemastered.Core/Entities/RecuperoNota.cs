using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class RecuperoNota
    {
        public long IdRecuperoNota { get; set; }
        public long IdRecupero { get; set; }
        public string TxtNota { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FecCarga { get; set; }
        public string TxtTitulo { get; set; }
    }
}
