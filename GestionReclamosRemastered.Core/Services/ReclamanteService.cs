using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Services
{
    public class ReclamanteService : IReclamanteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReclamanteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var claimant = await _unitOfWork.ReclamanteRepository.GetByLongId(id);
            if (claimant != null)
            {
                claimant.SnActivo = 0;
                _unitOfWork.ReclamanteRepository.Update(claimant);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateClaimant(Reclamante claimant)
        {
            _unitOfWork.ReclamanteRepository.Update(claimant);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
