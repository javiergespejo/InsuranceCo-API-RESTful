using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestionReclamosContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IReclamanteRepository _reclamanteRepository;
        private readonly ISiniestroRepository _siniestroRepository;
        private readonly IRecuperoRepository _recuperoRepository;
        private readonly IRepresentativeRepository _representativeRepository;
        public UnitOfWork(GestionReclamosContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
        public IReclamanteRepository ReclamanteRepository => _reclamanteRepository ?? new ReclamanteRepository(_context);
        public ISiniestroRepository SiniestroRepository => _siniestroRepository ?? new SiniestroRepository(_context);
        public IRecuperoRepository RecuperoRepository => _recuperoRepository ?? new RecuperoRepository(_context);
        public IRepresentativeRepository RepresentativeRepository => _representativeRepository ?? new RepresentativeRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}