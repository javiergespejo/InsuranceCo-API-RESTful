﻿using GestionReclamosRemastered.Core.Entities;
using System;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ISiniestroRepository SiniestroRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
