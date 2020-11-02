using GestionReclamosRemastered.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionReclamosRemastered.Core.DTOs
{
    public class SiniestroDto
    {
        public long IdStro { get; set; }
        public long NroStro { get; set; }
        public int IdTipoSiniestro { get; set; }
        public DateTime FechaSiniestro { get; set; }
        public DateTime FechaCarga { get; set; }
        public int IdUsuario { get; set; }
        public string TxtLugar { get; set; }
        public string TxtDominio { get; set; }
        public string TxtInterno { get; set; }
        public string TxtConductor { get; set; }
        public string TxtDeclaracion { get; set; }
        public int IdRepresentante { get; set; }
        public int IdEmpresa { get; set; }
        public string TxtObservaciones { get; set; }
        public long NroSiniestroProteccion { get; set; }
        public long NroReclamoProteccion { get; set; }
        public string Gestiona { get; set; }
        public double? DañoTerecero { get; set; }
        public double? DañoAsegurado { get; set; }
        public string TxtHora { get; set; }
        public int IdResponsabilidad { get; set; }
        public  Empresa IdEmpresaNavigation { get; set; }
        public  Representante IdRepresentanteNavigation { get; set; }
        public  TipoSiniestro IdTipoSiniestroNavigation { get; set; }
        public  Usuario IdUsuarioNavigation { get; set; }
        public  ICollection<Juicio> Juicio { get; set; }
        public  ICollection<Mediacion> Mediacion { get; set; }
        public  ICollection<Reclamante> Reclamante { get; set; }

        //Parameterless constructor
        public SiniestroDto()
        {
        }

        public SiniestroDto(Siniestro siniestro)
        {
            this.IdStro = siniestro.IdStro;
            this.NroStro = siniestro.NroStro;
            this.IdTipoSiniestro = siniestro.IdTipoSiniestro;
            this.FechaSiniestro = siniestro.FechaSiniestro;
            this.FechaCarga = siniestro.FechaCarga;
            this.IdUsuario = siniestro.IdUsuario;
            this.TxtLugar = siniestro.TxtLugar;
            this.TxtDominio = siniestro.TxtDominio;
            this.TxtInterno = siniestro.TxtInterno;
            this.TxtConductor = siniestro.TxtConductor;
            this.TxtDeclaracion = siniestro.TxtDeclaracion;
            this.IdRepresentante = siniestro.IdRepresentante;
            this.IdEmpresa = siniestro.IdEmpresa;
            this.TxtObservaciones = siniestro.TxtObservaciones;
            this.NroSiniestroProteccion = siniestro.NroSiniestroProteccion;
            this.NroReclamoProteccion = siniestro.NroReclamoProteccion;
            this.Gestiona = siniestro.Gestiona;
            this.DañoTerecero = siniestro.DañoTerecero;
            this.DañoAsegurado = siniestro.DañoAsegurado;
            this.TxtHora = siniestro.TxtHora;
            this.IdResponsabilidad = siniestro.IdResponsabilidad;
            this.IdEmpresaNavigation = siniestro.IdEmpresaNavigation;
            this.IdRepresentanteNavigation = siniestro.IdRepresentanteNavigation;
            this.IdTipoSiniestroNavigation = siniestro.IdTipoSiniestroNavigation;
            this.IdUsuarioNavigation = siniestro.IdUsuarioNavigation;
            this.Juicio = siniestro.Juicio;
            this.Mediacion = siniestro.Mediacion;
            this.Reclamante = siniestro.Reclamante;
        }

        public Siniestro ToSiniestroEntity()
        {
            return new Siniestro()
            {
                IdStro = this.IdStro,
                NroStro = this.NroStro,
                IdTipoSiniestro = this.IdTipoSiniestro,
                FechaSiniestro = this.FechaSiniestro,
                FechaCarga = this.FechaCarga,
                IdUsuario = this.IdUsuario,
                TxtLugar = this.TxtLugar,
                TxtDominio = this.TxtDominio,
                TxtInterno = this.TxtInterno,
                TxtConductor = this.TxtConductor,
                TxtDeclaracion = this.TxtDeclaracion,
                IdRepresentante = this.IdRepresentante,
                IdEmpresa = this.IdEmpresa,
                TxtObservaciones = this.TxtObservaciones,
                NroSiniestroProteccion = this.NroSiniestroProteccion,
                NroReclamoProteccion = this.NroReclamoProteccion,
                Gestiona = this.Gestiona,
                DañoTerecero = this.DañoTerecero,
                DañoAsegurado = this.DañoAsegurado,
                TxtHora = this.TxtHora,
                IdResponsabilidad = this.IdResponsabilidad,
                IdEmpresaNavigation = this.IdEmpresaNavigation,
                IdRepresentanteNavigation = this.IdRepresentanteNavigation,
                IdTipoSiniestroNavigation = this.IdTipoSiniestroNavigation,
                IdUsuarioNavigation = this.IdUsuarioNavigation,
                Juicio = this.Juicio,
                Mediacion = this.Mediacion,
                Reclamante = this.Reclamante
            };
        }

        public static List<SiniestroDto> SiniestroDtoToEntityList(List<Siniestro> siniestros)
        {
            List<SiniestroDto> siniestroDtos = new List<SiniestroDto>();
            foreach (var item in siniestros)
            {
                siniestroDtos.Add(new SiniestroDto(item));
            }
            return siniestroDtos;
        }
    }   
}
