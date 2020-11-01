using System;
using System.Collections.Generic;
using System.Text;

namespace GestionReclamosRemastered.Core.DTOs
{
    public class RepresentanteDTO
    {
        public int IdRepresentante { get; set; }
        public string TxtNombre { get; set; }
        public string TxtTelefono { get; set; }
        public string TxtMail { get; set; }
        public int SnActivo { get; set; }
    }
}
