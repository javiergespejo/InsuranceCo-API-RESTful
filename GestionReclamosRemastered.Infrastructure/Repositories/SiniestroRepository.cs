using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Core.QueryFilters;
using GestionReclamosRemastered.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<long> NroStroAsign()
        {
            var lastSiniestro = await _entities.OrderByDescending(x => x.NroStro).FirstOrDefaultAsync();
            return lastSiniestro.NroStro + 1;
        }
        public async Task<IEnumerable<Siniestro>> SiniestroSearch(SiniestroQueryFilter siniestroQueryFilter)
        {
            if (siniestroQueryFilter.NroSiniestroProteccion != null)
            {
                var siniestros = await _entities.Where(x => x.NroSiniestroProteccion == siniestroQueryFilter.NroSiniestroProteccion).ToListAsync();
                return siniestros;
            }
            else if (siniestroQueryFilter.TxtConductor != null)
            {
                var siniestros = await _entities.Where(x => x.TxtConductor == siniestroQueryFilter.TxtConductor).ToListAsync();
                return siniestros;
            }
            else if (siniestroQueryFilter.FechaSiniestro != null)
            {
                var siniestros = await _entities.Where(x => x.FechaSiniestro == siniestroQueryFilter.FechaSiniestro).ToListAsync();
                return siniestros;
            }
            else
            {
                return await _entities.ToListAsync();
            }
        }
        public async Task<Siniestro> GetSiniestroByNroStro(long nroStro)
        {
            var siniestro = await _entities.FirstOrDefaultAsync(x => x.NroSiniestroProteccion == nroStro);
            return siniestro;
        }
    }
}
