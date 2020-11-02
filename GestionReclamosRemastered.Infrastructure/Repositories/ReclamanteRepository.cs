using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class ReclamanteRepository : GenericRepository<Reclamante>, IReclamanteRepository
    {
        public ReclamanteRepository(GestionReclamosContext context) : base(context) { }
    }
}
