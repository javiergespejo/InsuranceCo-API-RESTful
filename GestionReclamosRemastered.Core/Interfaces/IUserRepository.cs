using GestionReclamosRemastered.Core.Interfaces;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Entities
{
    public interface IUserRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> AuthenticationAsync(string user, string pass);
        Task<Usuario> GetUser(int id);

    }
}
