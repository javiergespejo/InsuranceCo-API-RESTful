using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class TipoGastoRecupero
    {
        public int IdTipoGastoRecupero { get; set; }
        public string TxtDescripcion { get; set; }
        public int SnActivo { get; set; }
    }
}
