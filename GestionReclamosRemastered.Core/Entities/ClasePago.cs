using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class ClasePago : BaseEntity
    {
        public ClasePago()
        {
            ConceptoPago = new HashSet<ConceptoPago>();
            Monto = new HashSet<Monto>();
        }

        public int IdClasePago { get; set; }
        public string TxtDescripcion { get; set; }
        public int SnActivo { get; set; }

        public virtual ICollection<ConceptoPago> ConceptoPago { get; set; }
        public virtual ICollection<Monto> Monto { get; set; }
    }
}
