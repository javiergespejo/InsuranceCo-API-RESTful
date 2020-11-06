using GestionReclamosRemastered.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IUserService
    {
        Task<Usuario> AuthenticationAsync(string user, string pass);
        Task<bool> UpdateUser(Usuario user);
        Task<bool> SoftDelete(int id);
    }
}
