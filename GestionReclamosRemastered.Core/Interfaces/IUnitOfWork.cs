using System;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IUserTypeRepository UserTypeRepository { get; }
        IMontoRepository MontoRepository { get; }

        IConceptoPagoRepository ConceptoPagoRepository { get; }

        IClasePagoRepository ClasePagoRepository { get; }
        
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
