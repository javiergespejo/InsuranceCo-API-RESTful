﻿using System;
using System.Collections.Generic;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class TipoEstadoNotaRecupero
    {
        public int IdEstado { get; set; }
        public string TxtDescripcion { get; set; }
        public int SnActivo { get; set; }
    }
}
