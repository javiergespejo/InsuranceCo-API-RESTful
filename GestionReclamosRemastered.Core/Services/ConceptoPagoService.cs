﻿using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.Services
{
    public class ConceptoPagoService : IConceptoPagoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConceptoPagoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ConceptoPago> GetFullConceptoPagos()
        {
            var conceptoPagos = _unitOfWork.ConceptoPagoRepository.GetAll().ToList();
            var clasePagos = _unitOfWork.ClasePagoRepository.GetAll().ToList();

            foreach (var item in conceptoPagos)
            {
                item.IdClasePagoNavigation = clasePagos.Where(x => x.IdClasePago == item.IdClasePago).FirstOrDefault();
            }
            return conceptoPagos;
        }

        public async Task<ConceptoPago> GetConceptoPagosById(int id)
        {
            var conceptoPagos = await _unitOfWork.ConceptoPagoRepository.GetById(id);
            var clasePagos = _unitOfWork.ClasePagoRepository.GetAll().ToList();
            conceptoPagos.IdClasePagoNavigation = clasePagos.Where(x => x.IdClasePago == conceptoPagos.IdClasePago).FirstOrDefault();
            return conceptoPagos;
        }

        public async Task<bool> UpdateConceptoPago(ConceptoPago conceptoPago)
        {
            _unitOfWork.ConceptoPagoRepository.Update(conceptoPago);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDelete(ConceptoPago conceptoPago)
        {
            conceptoPago.SnActivo = 0;
            _unitOfWork.ConceptoPagoRepository.Update(conceptoPago);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}