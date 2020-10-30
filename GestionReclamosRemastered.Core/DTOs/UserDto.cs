using GestionReclamosRemastered.Core.Entities;

namespace GestionReclamosRemastered.Core.DTOs
{
    public class UserDto
    {
        public int IdUsuario { get; set; }
        public string CodUsuario { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public TipoUsuarioDto TipoUsuario { get; set; }
        public int SnActivo { get; set; }
    }
}
