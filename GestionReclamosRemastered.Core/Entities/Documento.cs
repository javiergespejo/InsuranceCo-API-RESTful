using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class Documento
    {
        public int IdDocumento { get; set; }
        public int IdStro { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; }
        public string Observacion { get; set; }
        public string Path { get; set; }
    }
}
