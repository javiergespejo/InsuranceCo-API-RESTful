using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.DTOs
{
    public class TipoMontoDto
    {
        public int IdTipoMonto { get; set; }
        public string TxtDescripcion { get; set; }
        public int Orden { get; set; }
    }
}
