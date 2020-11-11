using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface ISiniestroService
    {
        Task<List<SiniestroDto>> GetAllSiniestros(SiniestroQueryFilter siniestroQueryFilter);

        Task<SiniestroDto> GetSiniestroByNroStro(long nroStro);
    }
}
