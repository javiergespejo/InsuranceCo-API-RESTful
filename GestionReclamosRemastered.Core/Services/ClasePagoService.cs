using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Services
{
    public class ClasePagoService : IClasePagoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClasePagoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> SoftDelete(int id)
        {
            var clase = await _unitOfWork.ClasePagoRepository.GetById(id);
            if (clase != null)
            {
                clase.SnActivo = 0;
                _unitOfWork.ClasePagoRepository.Update(clase);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateClasePago(ClasePago clase)
        {
            _unitOfWork.ClasePagoRepository.Update(clase);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
