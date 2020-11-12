using GestionReclamosRemastered.Core.Entities;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Interfaces
{
    public interface IReclamanteRepository : IGenericRepository<Reclamante>
    {
        //HACER ASNC? 
        int GetReclamanteTieneMontosVinculados(long? id_reclamante, long? Id_stro);

    }
}
