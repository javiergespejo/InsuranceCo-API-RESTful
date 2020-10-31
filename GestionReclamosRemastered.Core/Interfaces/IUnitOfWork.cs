﻿using System;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IUserTypeRepository UserTypeRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
