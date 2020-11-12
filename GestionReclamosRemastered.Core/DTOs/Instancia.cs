using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.DTOs
{
    public class Instancia
    {
        int id_instancia;

        public int Id_instancia
        {
            get { return id_instancia; }
            set { id_instancia = value; }
        }
        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
