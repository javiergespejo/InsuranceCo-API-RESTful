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
        private readonly IMontoRepository _montoRepository;
        private readonly IConceptoPagoRepository _conceptoPagoRepository;
        private readonly IClasePagoRepository _clasePago;
        public UnitOfWork(GestionReclamosContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
        public IReclamanteRepository ReclamanteRepository => _reclamanteRepository ?? new ReclamanteRepository(_context);
        public ISiniestroRepository SiniestroRepository => _siniestroRepository ?? new SiniestroRepository(_context);
        public IRecuperoRepository RecuperoRepository => _recuperoRepository ?? new RecuperoRepository(_context);
        public IRepresentativeRepository RepresentativeRepository => _representativeRepository ?? new RepresentativeRepository(_context);
        public IMontoRepository MontoRepository => _montoRepository ?? new MontoRepository(_context);
        public IConceptoPagoRepository ConceptoPagoRepository => _conceptoPagoRepository ?? new ConceptoPagoRepository(_context);
        public IClasePagoRepository ClasePagoRepository => _clasePago ?? new ClasePagoRepository(_context);
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