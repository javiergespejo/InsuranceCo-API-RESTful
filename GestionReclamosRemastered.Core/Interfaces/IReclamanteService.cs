using GestionReclamosRemastered.Core.Entities;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IReclamanteService
    {
        Task<bool> UpdateClaimant(Reclamante claimant);
        Task<bool> SoftDelete(int id);
    }
}
