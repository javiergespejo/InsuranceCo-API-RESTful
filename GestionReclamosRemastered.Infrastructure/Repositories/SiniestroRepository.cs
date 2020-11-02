using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class SiniestroRepository : GenericRepository<Siniestro>, ISiniestroRepository
    {
        public SiniestroRepository(GestionReclamosContext context) : base(context)
        {
        }

        public Task<Siniestro> GetSiniestro(int id)
        {
            throw new NotImplementedException();
        }
    }
}
