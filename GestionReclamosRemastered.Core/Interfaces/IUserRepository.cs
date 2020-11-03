using GestionReclamosRemastered.Core.Entities;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> AuthenticationAsync(string user, string pass);
    }
}
