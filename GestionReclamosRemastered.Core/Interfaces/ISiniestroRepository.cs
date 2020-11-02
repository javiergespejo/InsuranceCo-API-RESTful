using GestionReclamosRemastered.Core.Entities;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface ISiniestroRepository : IGenericRepository<Siniestro>
    {
        Task<Siniestro> GetSiniestro(int id);
    }
}
