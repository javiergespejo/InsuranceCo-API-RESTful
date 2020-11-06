using GestionReclamosRemastered.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IMontoService
    {
        IEnumerable<Monto> GetFullMonto();
        Task<Monto> GetFullMontoById(int id);
        Task<bool> UpdateMonto(Monto monto);

        Task<bool> Delete(int id);

    }
}
