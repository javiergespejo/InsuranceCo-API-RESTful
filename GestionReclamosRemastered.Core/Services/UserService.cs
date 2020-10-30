using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Usuario> Authentication(string user, string pass)
        {
            return _unitOfWork.UserRepository.AuthenticationAsync(user, pass);
        }

        public async Task<Usuario> GetUser(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }
    }
}
