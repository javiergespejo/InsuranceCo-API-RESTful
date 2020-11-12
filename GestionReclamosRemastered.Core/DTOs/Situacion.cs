using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReclamosRemastered.Core.DTOs
{
    public class Situacion
    {
        int id_situacion;

        public int Id_situacion
        {
            get { return id_situacion; }
            set { id_situacion = value; }
        }


        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        int sn_carga_monto;

        public int Sn_carga_monto
        {
            get { return sn_carga_monto; }
            set { sn_carga_monto = value; }
        }
    }
}
