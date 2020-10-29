using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class Submenu
    {
        public Submenu()
        {
            MenuTipoUsuario = new HashSet<MenuTipoUsuario>();
        }

        public int IdSubMenu { get; set; }
        public int IdMenu { get; set; }
        public string Descripcion { get; set; }
        public int SnActivo { get; set; }
        public string Pagina { get; set; }

        public virtual Menu IdMenuNavigation { get; set; }
        public virtual ICollection<MenuTipoUsuario> MenuTipoUsuario { get; set; }
    }
}
