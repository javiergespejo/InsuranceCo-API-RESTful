using AutoMapper;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Services
{
    // Este servicio fue realizado a modo de practica, de forma parcial, entendiendo que en un proyecto más grande
    // e involucrando más repositorios en un mismo controlador, tendría más utilidad.
    public class SiniestroService : ISiniestroService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SiniestroService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SiniestroDto>> GetAllSiniestros()
        {
            var siniestros = await _unitOfWork.SiniestroRepository.GetAllAsync();
            var siniestrosDto = _mapper.Map<List<SiniestroDto>>(siniestros);

            return siniestrosDto;
        }

        public async Task<SiniestroDto> GetSiniestroById(long id)
        {
            var siniestro = await _unitOfWork.SiniestroRepository.GetByLongId(id);
            var siniestroDto = _mapper.Map<SiniestroDto>(siniestro);

            return siniestroDto;
        }
    }
}
