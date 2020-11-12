using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IMontoRepository : IGenericRepository <Monto>
    {
        List<MontoCustomDTO> BuscarPagosPorIdSiniestroAPI(long? id_siniestro);
    }
}
