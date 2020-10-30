using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class Menu
    {
        public Menu()
        {
            Submenu = new HashSet<Submenu>();
        }

        public int IdMenu { get; set; }
        public string Descripcion { get; set; }
        public int SnActivo { get; set; }

        public virtual ICollection<Submenu> Submenu { get; set; }
    }
}
