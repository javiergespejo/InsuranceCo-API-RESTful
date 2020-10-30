using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class Monto
    {
        public int IdReclamante { get; set; }
        public int IdClasePago { get; set; }
        public int IdConcepto { get; set; }
        public int IdTipoMonto { get; set; }
        public double Importe { get; set; }
        public DateTime FechaCarga { get; set; }
        public int IdUsuario { get; set; }
        public long IdEstimacion { get; set; }
        public int IdInstancia { get; set; }
        public int IdSituacion { get; set; }
        public int CodEstim { get; set; }

        public virtual ConceptoPago IdC { get; set; }
        public virtual ClasePago IdClasePagoNavigation { get; set; }
        public virtual TipoInstancia IdInstanciaNavigation { get; set; }
        public virtual TipoMonto IdTipoMontoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
