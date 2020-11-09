using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Services
{
    public class MontoService : IMontoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MontoService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IEnumerable<Monto> GetFullMonto()
        {
            var monto = _unitOfWork.MontoRepository.GetAll().ToList();
            return monto;
        }

        public async Task<Monto> GetFullMontoById(int id)
        {
            var monto = await _unitOfWork.MontoRepository.GetById(id);
            return monto;
        }

        public async Task<bool> UpdateMonto(Monto monto)
        {
            _unitOfWork.MontoRepository.Update(monto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.MontoRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
