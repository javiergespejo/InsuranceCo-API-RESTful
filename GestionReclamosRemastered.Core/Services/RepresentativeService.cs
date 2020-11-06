using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GestionReclamosRemastered.Core.Services
{
    public class RepresentativeService : IRepresentativeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepresentativeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Soft deletes the representative from the database, changing the active state to 1
        /// </summary>
        /// <param name="representantive"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRepresentative(Representante representative)
        {

           
            if (representative != null && representative.GetType().GetProperties()
                            .All(p => p.GetValue(representative) != null))
            {
                representative.SnActivo = 0;
                _unitOfWork.RepresentativeRepository.Update(representative);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            throw new Exception();
        }

        /// <summary>
        /// Gets a list of active representatives
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Representante>> GetAllRepresentatives()
        {
            return await _unitOfWork.RepresentativeRepository.GetRepresentativesAsync();
        }

        /// <summary>
        /// Gets a representative by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Representante> GetRepresentativeById(int id)
        {
            return await _unitOfWork.RepresentativeRepository.GetById(id);
        }
        /// <summary>
        /// Updates a representative information
        /// </summary>
        /// <param name="representative"></param>
        /// <returns></returns>
        public async Task<bool> UpdateRepresentative(Representante representative)
        {
            if (representative != null && representative.GetType().GetProperties()
                            .All(p => p.GetValue(representative) != null))
            {
                _unitOfWork.RepresentativeRepository.Update(representative);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            throw new Exception();
        }
    }
}
