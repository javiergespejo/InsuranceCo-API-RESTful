using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class Usuario : BaseEntity
    {
        public Usuario()
        {
            Monto = new HashSet<Monto>();
            Reclamante = new HashSet<Reclamante>();
            Siniestro = new HashSet<Siniestro>();
        }

        public int IdUsuario { get; set; }
        public string CodUsuario { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int IdTipoUsuario { get; set; }
        public int SnActivo { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Monto> Monto { get; set; }
        public virtual ICollection<Reclamante> Reclamante { get; set; }
        public virtual ICollection<Siniestro> Siniestro { get; set; }
    }
}
