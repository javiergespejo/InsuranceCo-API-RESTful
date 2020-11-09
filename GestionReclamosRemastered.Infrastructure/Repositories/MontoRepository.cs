using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class MontoRepository : GenericRepository<Monto>, IMontoRepository
    {
       
           public MontoRepository(GestionReclamosContext context) : base(context) { }
        
    }
}
