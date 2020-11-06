using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.DTOs
{
    public class ClasePagoDto
    {
        public int IdClasePago { get; set; }
        public string TxtDescripcion { get; set; }
        public int SnActivo { get; set; }
    }
}
