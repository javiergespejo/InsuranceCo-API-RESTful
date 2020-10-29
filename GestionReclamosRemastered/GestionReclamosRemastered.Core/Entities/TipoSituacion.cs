using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class TipoSituacion
    {
        public int Id { get; set; }
        public int IdInstancia { get; set; }
        public int IdSituacion { get; set; }
        public string TxtDescripcion { get; set; }
        public int SnCargaMonto { get; set; }

        public virtual TipoInstancia IdInstanciaNavigation { get; set; }
    }
}
