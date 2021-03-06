﻿using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<Usuario>, IUserRepository
    {
        public UserRepository(GestionReclamosContext context) : base(context) { }

        public async Task<Usuario> AuthenticationAsync(string userName, string pass)
        {
            var u = await _entities.Where(x => x.CodUsuario == userName && x.Password == pass).FirstOrDefaultAsync();
            return u;
        }
    }
}
