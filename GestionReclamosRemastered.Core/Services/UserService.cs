using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<Usuario> AuthenticationAsync(string user, string pass)
        {
            return await _unitOfWork.UserRepository.AuthenticationAsync(user, pass);
        }

        public async Task<bool> UpdateUser(Usuario user)
        {
             _unitOfWork.UserRepository.Update(user);
             await _unitOfWork.SaveChangesAsync();
             return true;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user != null)
            {
                user.SnActivo = 0;
                _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
