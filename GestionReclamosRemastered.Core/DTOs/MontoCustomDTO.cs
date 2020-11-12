using GestionReclamosRemastered.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionReclamosRemastered.Core.DTOs
{
    public class MontoCustomDTO
    {
        public MontoCustomDTO()
        {
            reclamante = new Reclamante();
            clase_pago = new ClasePago();
            concepto = new ConceptoPago();
            tipo_monto = new TipoMonto();
            usuario = new Usuario();
            instancia = new Instancia();
            situacion = new Situacion();

        }
        long id_stro;


        public int IdClasePago { get; set; }
        public int IdConcepto { get; set; }
        public long IdReclamante { get; set; }

        public int IdTipoMonto { get; set; }
        public int IdInstancia { get; set; }
        public int IdSituacion { get; set; }
        public int IdUsuario { get; set; }
        public long IdStro
        {
            get { return id_stro; }
            set { id_stro = value; }
        }

        int cod_estim;
        public int CodEstim
        {
            get { return cod_estim; }
            set { cod_estim = value; }
        }

        Reclamante reclamante;
        public Reclamante Reclamante
        {
            get { return reclamante; }
            set { reclamante = value; }
        }

        ClasePago clase_pago;
        public ClasePago ClasePago
        {
            get { return clase_pago; }
            set { clase_pago = value; }
        }

        ConceptoPago concepto;
        public ConceptoPago Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }

        TipoMonto tipo_monto;
        public TipoMonto TipoMonto
        {
            get { return tipo_monto; }
            set { tipo_monto = value; }
        }

        double importe;
        public double Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        DateTime fecha_carga;
        public DateTime FechaCarga
        {
            get { return fecha_carga; }
            set { fecha_carga = value; }
        }

        Usuario usuario;
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        long id_estimacion;
        public long IdEstimacion
        {
            get { return id_estimacion; }
            set { id_estimacion = value; }
        }

        Instancia instancia;
        public Instancia Instancia
        {
            get { return instancia; }
            set { instancia = value; }
        }

        Situacion situacion;
        public Situacion Situacion
        {
            get { return situacion; }
            set { situacion = value; }
        }
    }
}
