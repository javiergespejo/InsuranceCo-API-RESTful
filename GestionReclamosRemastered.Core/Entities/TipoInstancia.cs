using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class TipoInstancia : BaseEntity
    {
        public TipoInstancia()
        {
            Monto = new HashSet<Monto>();
            TipoSituacion = new HashSet<TipoSituacion>();
        }

        public int IdInstancia { get; set; }
        public string TxtDescripcion { get; set; }

        public virtual ICollection<Monto> Monto { get; set; }
        public virtual ICollection<TipoSituacion> TipoSituacion { get; set; }
    }
}
