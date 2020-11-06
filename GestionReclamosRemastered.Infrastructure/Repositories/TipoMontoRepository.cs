using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class TipoMontoRepository : GenericRepository <TipoMonto>, ITipoMontoRepository
    {
        public TipoMontoRepository(GestionReclamosContext context) : base(context) { }
    }
}
