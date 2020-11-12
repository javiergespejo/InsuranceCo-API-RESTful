using GestionReclamosRemastered.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IRepresentativeRepository : IGenericRepository<Representante>
    {
        Task<IEnumerable<Representante>> GetRepresentativesAsync();
        Task<IEnumerable<Representante>> GetByName(string name);
    }
}
