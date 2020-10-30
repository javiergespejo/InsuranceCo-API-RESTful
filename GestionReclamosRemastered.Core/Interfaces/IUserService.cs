using GestionReclamosRemastered.Core.Entities;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IUserService
    {
        Task<Usuario> Authentication(string user, string pass);
    }
}
