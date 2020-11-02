using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Services
{
    class RepresentativeService : IRepresentativeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepresentativeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
    }
}
