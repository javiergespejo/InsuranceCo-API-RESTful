using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class TipoProceso
    {
        public int IdTipoProceso { get; set; }
        public string Descripcion { get; set; }
        public int SnActivo { get; set; }
    }
}
