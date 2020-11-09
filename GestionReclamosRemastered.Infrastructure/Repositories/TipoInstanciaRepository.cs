using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;


namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class TipoInstanciaRepository : GenericRepository <TipoInstancia>, ITipoInstanciaRepository
    {
        public TipoInstanciaRepository(GestionReclamosContext context) : base(context) { }
    }
}
