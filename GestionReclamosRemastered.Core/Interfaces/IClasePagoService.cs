using GestionReclamosRemastered.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IClasePagoService
    {
        IEnumerable<ClasePago> GetFullClasePago();
        Task<ClasePago> GetFullClasePagoById(int id);
        Task<bool> UpdateClasePago(ClasePago pago);
        Task<bool> SoftDelete(ClasePago pago);
    }
}
