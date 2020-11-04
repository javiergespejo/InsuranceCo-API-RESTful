using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class RecuperoRepository : GenericRepository<Recupero>, IRecuperoRepository
    {
         public RecuperoRepository(GestionReclamosContext context) : base(context)
        {
        }
    }
}
