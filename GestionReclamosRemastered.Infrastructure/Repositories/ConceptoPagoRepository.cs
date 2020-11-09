using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class ConceptoPagoRepository : GenericRepository<ConceptoPago>, IConceptoPagoRepository
    {
        public ConceptoPagoRepository(GestionReclamosContext context) : base(context) { }
    }
}
