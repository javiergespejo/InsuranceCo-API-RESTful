using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionReclamosRemastered.Core.Entities
{
    public partial class Siniestro: BaseEntity
    {
        public Siniestro()
        {
            Juicio = new HashSet<Juicio>();
            Mediacion = new HashSet<Mediacion>();
            Reclamante = new HashSet<Reclamante>();
        }
        [Key]
        public long IdStro { get; set; }
        public long NroStro { get; set; }
        [Key]
        public int IdTipoSiniestro { get; set; }
        public DateTime FechaSiniestro { get; set; }
        public DateTime FechaCarga { get; set; }
        [Key]
        public int IdUsuario { get; set; }
        public string TxtLugar { get; set; }
        public string TxtDominio { get; set; }
        public string TxtInterno { get; set; }
        public string TxtConductor { get; set; }
        public string TxtDeclaracion { get; set; }
        [Key]
        public int IdRepresentante { get; set; }
        [Key]
        public int IdEmpresa { get; set; }
        public string TxtObservaciones { get; set; }
        public long NroSiniestroProteccion { get; set; }
        public long NroReclamoProteccion { get; set; }
        public string Gestiona { get; set; }
        public double? DañoTerecero { get; set; }
        public double? DañoAsegurado { get; set; }
        public string TxtHora { get; set; }
        [Key]
        public int IdResponsabilidad { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Representante IdRepresentanteNavigation { get; set; }
        public virtual TipoSiniestro IdTipoSiniestroNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Juicio> Juicio { get; set; }
        public virtual ICollection<Mediacion> Mediacion { get; set; }
        public virtual ICollection<Reclamante> Reclamante { get; set; }
    }
}
