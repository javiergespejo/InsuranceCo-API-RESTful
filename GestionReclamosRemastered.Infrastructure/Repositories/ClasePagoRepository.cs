using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class ClasePagoRepository : GenericRepository<ClasePago>, IClasePagoRepository
    {
        public ClasePagoRepository(GestionReclamosContext context) : base(context) { }
    }
}
