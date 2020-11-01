using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class Representante : BaseEntity
    {
        public Representante()
        {
            Siniestro = new HashSet<Siniestro>();
        }

        public int IdRepresentante { get; set; }
        public string TxtNombre { get; set; }
        public string TxtTelefono { get; set; }
        public string TxtMail { get; set; }
        public int SnActivo { get; set; }

        public virtual ICollection<Siniestro> Siniestro { get; set; }
    }
}
