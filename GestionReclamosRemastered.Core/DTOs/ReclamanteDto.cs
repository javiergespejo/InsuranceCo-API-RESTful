using System;
using System.Collections.Generic;
using System.Text;

namespace GestionReclamosRemastered.Core.DTOs
{
    public class ReclamanteDto
    {
        public long IdReclamante { get; set; }
        public long IdStro { get; set; }
        public string TxtNombre { get; set; }
        public string TxtDni { get; set; }
        public string TxtDomicilio { get; set; }
        public string TxtVehiculo { get; set; }
        public string TxtDominio { get; set; }
        public string TxtDanTerceros { get; set; }
        public long NroReclamo { get; set; }
        public DateTime FechaCarga { get; set; }
        public int IdUsuario { get; set; }
        public int SnActivo { get; set; }

        //public virtual Siniestro IdStroNavigation { get; set; }
        //public virtual UserDto IdUsuarioNavigation { get; set; }
    }
}
