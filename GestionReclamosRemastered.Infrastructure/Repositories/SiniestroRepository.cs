using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class SiniestroRepository : GenericRepository<Siniestro>, ISiniestroRepository
    {
        public SiniestroRepository(GestionReclamosContext context) : base(context)
        {
        }

        public async Task<bool> SiniestroExist(Siniestro siniestro)
        {
            return await _entities.AnyAsync(s => s.NroStro == siniestro.NroStro);            
        }
    }
}
