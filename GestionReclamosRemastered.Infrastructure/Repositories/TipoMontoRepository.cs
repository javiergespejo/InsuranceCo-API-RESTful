﻿using GestionReclamosRemastered.Core.Entities;
using GestionReclamosRemastered.Core.Interfaces;
using GestionReclamosRemastered.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Infrastructure.Repositories
{
    public class TipoMontoRepository : GenericRepository <TipoMonto>, ITipoMontoRepository
    {
        public TipoMontoRepository(GestionReclamosContext context) : base(context) { }
    }
}
