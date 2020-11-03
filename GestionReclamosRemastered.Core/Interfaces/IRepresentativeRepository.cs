using GestionReclamosRemastered.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IRepresentativeRepository : IGenericRepository<Representante>
    {
        Task<IEnumerable<Representante>> GetRepresentativesAsync();
    }
}
