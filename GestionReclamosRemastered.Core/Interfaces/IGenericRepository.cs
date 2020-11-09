using GestionReclamosRemastered.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByLongId(long id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);


    }
}
