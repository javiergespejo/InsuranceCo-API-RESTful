using GestionReclamosRemastered.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IConceptoPagoService
    {
        IEnumerable<ConceptoPago> GetFullConceptoPagos();
        Task<ConceptoPago> GetConceptoPagosById(int id);
        Task<bool> UpdateConceptoPago(ConceptoPago conceptoPago);
        Task<bool> SoftDelete(ConceptoPago conceptoPago);

    }
}
