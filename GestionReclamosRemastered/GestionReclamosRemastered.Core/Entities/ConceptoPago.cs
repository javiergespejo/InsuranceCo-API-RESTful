using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class ConceptoPago
    {
        public ConceptoPago()
        {
            Monto = new HashSet<Monto>();
        }

        public int IdClasePago { get; set; }
        public int IdConcepto { get; set; }
        public string TxtDescripcion { get; set; }
        public int SnActivo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCarga { get; set; }

        public virtual ClasePago IdClasePagoNavigation { get; set; }
        public virtual ICollection<Monto> Monto { get; set; }
    }
}
