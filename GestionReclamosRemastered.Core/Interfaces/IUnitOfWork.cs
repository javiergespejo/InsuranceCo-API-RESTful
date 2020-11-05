using System;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IReclamanteRepository ReclamanteRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
