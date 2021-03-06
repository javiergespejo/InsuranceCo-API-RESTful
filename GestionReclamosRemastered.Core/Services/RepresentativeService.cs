﻿using GestionReclamosRemastered.Core.Interfaces;
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
        /// Gets a list of active representatives or gets a filtered list by name 
        /// </summary>
        /// <param name="name">If name is not null, filters the name by its value</param>
        /// <returns>A list of active representatives, filtered or not</returns>
        public async Task<IEnumerable<Representante>> GetAllRepresentatives(string name)
        {
            if (name == null)
            {
                var repWithoutName =  await _unitOfWork.RepresentativeRepository.GetRepresentativesAsync();
                if (repWithoutName.Count() > 0)
                {
                    return repWithoutName;
                }
                throw new Exception();
            }
            var repWithName = await _unitOfWork.RepresentativeRepository.GetByName(name);
            if (repWithName.Count() > 0)
            {
                return repWithName;
            }
            throw new Exception();
        }

        /// <summary>
        /// Gets a representative by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Representante> GetRepresentativeById(int id)
        {
            var rep =  await _unitOfWork.RepresentativeRepository.GetById(id);
            if (rep != null)
            {
                return rep;
            }
            else
            {
                throw new Exception();
            }
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
