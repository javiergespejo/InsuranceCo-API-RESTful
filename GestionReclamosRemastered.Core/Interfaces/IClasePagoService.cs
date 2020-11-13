using GestionReclamosRemastered.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IClasePagoService
    {
        Task<bool> UpdateClasePago(ClasePago pago);
        Task<bool> SoftDelete(int id);
    }
}
