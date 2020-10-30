using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class TipoMonto
    {
        public TipoMonto()
        {
            Monto = new HashSet<Monto>();
        }

        public int IdTipoMonto { get; set; }
        public string TxtDescripcion { get; set; }
        public int Orden { get; set; }

        public virtual ICollection<Monto> Monto { get; set; }
    }
}
