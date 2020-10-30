using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class TipoSiniestro
    {
        public TipoSiniestro()
        {
            Siniestro = new HashSet<Siniestro>();
        }

        public int IdTipoSiniestro { get; set; }
        public string TxtDescripcion { get; set; }

        public virtual ICollection<Siniestro> Siniestro { get; set; }
    }
}
