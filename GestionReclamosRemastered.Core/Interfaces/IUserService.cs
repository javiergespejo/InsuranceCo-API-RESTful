using GestionReclamosRemastered.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IUserService
    {
        Task<Usuario> AuthenticationAsync(string user, string pass);
        IEnumerable<Usuario> GetFullUsers();
        Task<Usuario> GetFullUserById(int id);
        Task<bool> UpdateUser(Usuario user);
        Task<bool> SoftDelete(Usuario user);
    }
}
