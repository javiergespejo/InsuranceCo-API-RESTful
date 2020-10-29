using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            MenuTipoUsuario = new HashSet<MenuTipoUsuario>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<MenuTipoUsuario> MenuTipoUsuario { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
