using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class RepresentativeRepository : GenericRepository<Representante>, IRepresentativeRepository
    {
        public RepresentativeRepository(GestionReclamosContext context) : base(context)
        {

        }
        /// <summary>
        /// Returns active Representative by id, else returns null. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Representante> GetByIdAsync(int id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.IdRepresentante == -1);
        }

        /// <summary>
        /// Returns a list of active representatives
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Representante>> GetRepresentativesAsync()
        {
            return await _entities.Where(x => x.SnActivo == -1).ToListAsync();
        }
    }
}