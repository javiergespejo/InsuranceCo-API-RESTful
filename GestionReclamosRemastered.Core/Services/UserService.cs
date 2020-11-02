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
        public IEnumerable<Usuario> GetFullUsers()
        {
            var users = _unitOfWork.UserRepository.GetAll().ToList();
            var userTypes = _unitOfWork.UserTypeRepository.GetAll().ToList();

            foreach (var item in users)
            {
                item.IdTipoUsuarioNavigation = userTypes.Where(x => x.IdTipoUsuario == item.IdTipoUsuario).FirstOrDefault();
            }

            return users;
        }
        public async Task<Usuario> GetFullUserById(int id)
        {

            var user = await _unitOfWork.UserRepository.GetById(id);
            var userTypes = _unitOfWork.UserTypeRepository.GetAll().ToList();
            user.IdTipoUsuarioNavigation = userTypes.Where(x => x.IdTipoUsuario == user.IdTipoUsuario).FirstOrDefault();
            return user;
        }

        public async Task<bool> UpdateUser(Usuario user)
        {
             _unitOfWork.UserRepository.Update(user);
             await _unitOfWork.SaveChangesAsync();
             return true;
        }

        public async Task<bool> SoftDelete(Usuario user)
        {
            user.SnActivo = 0;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
