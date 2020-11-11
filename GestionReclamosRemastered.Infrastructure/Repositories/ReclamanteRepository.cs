using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class ReclamanteRepository : GenericRepository<Reclamante>, IReclamanteRepository
    {
        public ReclamanteRepository(GestionReclamosContext context) : base(context)
        {
        }

        public int GetReclamanteTieneMontosVinculados(long? id_reclamante, long? Id_stro)
        {
            var response = from m in _context.Monto
                       join r in _context.Reclamante on m.IdReclamante equals r.IdReclamante
                       where (m.IdReclamante == id_reclamante) && (r.IdStro == Id_stro)
                       select m;
            return response.Count();
        }
    }

}
