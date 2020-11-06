using GestionReclamosRemastered.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IRepresentativeService
    {
        Task<IEnumerable<Representante>> GetAllRepresentatives();
        Task<Representante> GetRepresentativeById(int id);
        Task<bool> UpdateRepresentative(Representante representantive);
        Task<bool> DeleteRepresentative(Representante representantive);
    }
}
