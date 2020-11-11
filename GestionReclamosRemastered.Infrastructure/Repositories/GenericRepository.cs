using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly GestionReclamosContext _context;
        protected readonly DbSet<T> _entities;
        public GenericRepository(GestionReclamosContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task<T> GetByLongId(long id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _entities.Update(entity);
        }
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
        public async Task DeleteLong(long id)
        {
            T entity = await GetByLongId(id);
            _entities.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }
    }
}
