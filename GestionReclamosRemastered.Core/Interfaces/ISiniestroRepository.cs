using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface ISiniestroRepository : IGenericRepository<Siniestro>
    {
        Task<bool> SiniestroExist(Siniestro siniestro);
        Task<long> NroStroAsign();
        Task<IEnumerable<Siniestro>> SiniestroSearch(SiniestroQueryFilter siniestroQueryFilter);
    }
}
