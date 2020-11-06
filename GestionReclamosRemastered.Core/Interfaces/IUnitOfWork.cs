using System;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IReclamanteRepository ReclamanteRepository { get; }
        ISiniestroRepository SiniestroRepository { get; }
        IRecuperoRepository RecuperoRepository { get; }
        IRepresentativeRepository RepresentativeRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
