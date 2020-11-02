using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;
 
namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class UserTypeRepository : GenericRepository<TipoUsuario>, IUserTypeRepository
    {
        public UserTypeRepository(GestionReclamosContext context) : base(context) { }
    }
}
