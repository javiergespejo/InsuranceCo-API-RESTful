using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Task<bool> SoftDelete(Reclamante claimant)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateClaimant(Reclamante claimant)
        {
            _unitOfWork.ReclamanteRepository.Update(claimant);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
