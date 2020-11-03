using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class RepresentativeRepository : GenericRepository<Representante>, IRepresentativeRepository
    {
        public RepresentativeRepository(GestionReclamosContext context) : base(context)
        {

        }
        
    }
}