using GestionReclamosRemastered.Core.Entities;
using System;

namespace GestionReclamosRemastered.Core.DTOs
{
    public class MontoDto
    {
        public int IdReclamante { get; set; }
        public int IdClasePago { get; set; }
        public int IdConcepto { get; set; }
        public int IdTipoMonto { get; set; }
        public double Importe { get; set; }
        public DateTime FechaCarga { get; set; }
        public int IdUsuario { get; set; }
        public long IdEstimacion { get; set; }
        public int IdInstancia { get; set; }
        public int IdSituacion { get; set; }
        public int CodEstim { get; set; }
    }

}
