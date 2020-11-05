using GestionReclamosRemastered.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface ISiniestroService
    {
        Task<List<SiniestroDto>> GetAllSiniestros();

        Task<SiniestroDto> GetSiniestroById(long id);
    }
}
