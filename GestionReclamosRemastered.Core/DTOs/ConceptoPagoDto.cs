using System;

namespace GestionReclamosRemastered.Core.Entities
{
    public class ConceptoPagoDto
    {
        public int IdClasePago { get; set; }
        public int IdConcepto { get; set; }
        public string TxtDescripcion { get; set; }
        public int SnActivo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCarga { get; set; }

        public virtual ClasePago IdClasePagoNavigation { get; set; }
    }
}
