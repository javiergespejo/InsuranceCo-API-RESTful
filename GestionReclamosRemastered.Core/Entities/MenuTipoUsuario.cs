using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class MenuTipoUsuario
    {
        public int IdSubMenu { get; set; }
        public int IdTipoUsuario { get; set; }

        public virtual Submenu IdSubMenuNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
