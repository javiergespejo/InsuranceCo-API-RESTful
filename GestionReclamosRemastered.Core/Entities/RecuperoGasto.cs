using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class RecuperoGasto
    {
        public long IdRecuperoGasto { get; set; }
        public long IdRecupero { get; set; }
        public int IdTipoGasto { get; set; }
        public double Importe { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCarga { get; set; }
        public int IdEstim { get; set; }
    }
}
