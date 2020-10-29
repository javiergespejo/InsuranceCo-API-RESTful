using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class Empresa
    {
        public Empresa()
        {
            Siniestro = new HashSet<Siniestro>();
        }

        public int IdEmpresa { get; set; }
        public string TxtDescripcion { get; set; }

        public virtual ICollection<Siniestro> Siniestro { get; set; }
    }
}
