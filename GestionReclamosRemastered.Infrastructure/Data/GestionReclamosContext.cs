using GestionReclamosRemastered.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionReclamosRemastered.Infrastructure.Data
{
    public partial class GestionReclamosContext : DbContext
    {
        public GestionReclamosContext()
        {
        }

        public GestionReclamosContext(DbContextOptions<GestionReclamosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClasePago> ClasePago { get; set; }
        public virtual DbSet<ConceptoPago> ConceptoPago { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Juicio> Juicio { get; set; }
        public virtual DbSet<JuicioAuditoria> JuicioAuditoria { get; set; }
        public virtual DbSet<Mediacion> Mediacion { get; set; }
        public virtual DbSet<MediacionAuditoria> MediacionAuditoria { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuTipoUsuario> MenuTipoUsuario { get; set; }
        public virtual DbSet<Monto> Monto { get; set; }
        public virtual DbSet<Reclamante> Reclamante { get; set; }
        public virtual DbSet<Recupero> Recupero { get; set; }
        public virtual DbSet<RecuperoAuditoria> RecuperoAuditoria { get; set; }
        public virtual DbSet<RecuperoGasto> RecuperoGasto { get; set; }
        public virtual DbSet<RecuperoNota> RecuperoNota { get; set; }
        public virtual DbSet<Representante> Representante { get; set; }
        public virtual DbSet<Responsabilidad> Responsabilidad { get; set; }
        public virtual DbSet<Siniestro> Siniestro { get; set; }
        public virtual DbSet<SiniestroAuditoria> SiniestroAuditoria { get; set; }
        public virtual DbSet<SiniestroEstado> SiniestroEstado { get; set; }
        public virtual DbSet<Submenu> Submenu { get; set; }
        public virtual DbSet<TipoBusqueda> TipoBusqueda { get; set; }
        public virtual DbSet<TipoEstadoNotaRecupero> TipoEstadoNotaRecupero { get; set; }
        public virtual DbSet<TipoGastoRecupero> TipoGastoRecupero { get; set; }
        public virtual DbSet<TipoInstancia> TipoInstancia { get; set; }
        public virtual DbSet<TipoMonto> TipoMonto { get; set; }
        public virtual DbSet<TipoProceso> TipoProceso { get; set; }
        public virtual DbSet<TipoSiniestro> TipoSiniestro { get; set; }
        public virtual DbSet<TipoSituacion> TipoSituacion { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=GestionReclamos4;Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClasePago>(entity =>
            {
                entity.HasKey(e => e.IdClasePago)
                    .HasName("PK__clase_pa__C48CB38F4D6D304A");

                entity.ToTable("clase_pago");

                entity.Property(e => e.IdClasePago).HasColumnName("id_clase_pago");

                entity.Property(e => e.SnActivo)
                    .HasColumnName("sn_activo")
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.TxtDescripcion)
                    .IsRequired()
                    .HasColumnName("txt_descripcion")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConceptoPago>(entity =>
            {
                entity.HasKey(e => e.IdConcepto)
                    .HasName("PKconcepto303BBBDC34DA70F6");

                entity.ToTable("concepto_pago");

                entity.Property(e => e.IdClasePago).HasColumnName("id_clase_pago");

                entity.Property(e => e.IdConcepto).HasColumnName("id_concepto");

                entity.Property(e => e.FechaCarga)
                    .HasColumnName("fecha_carga")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.SnActivo)
                    .HasColumnName("sn_activo")
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.TxtDescripcion)
                    .IsRequired()
                    .HasColumnName("txt_descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasePagoNavigation)
                    .WithMany(p => p.ConceptoPago)
                    .HasForeignKey(d => d.IdClasePago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clase_pago");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento)
                    .HasName("PK__document__5D2EE7E5ED83A04E");

                entity.ToTable("documento");

                entity.Property(e => e.IdDocumento).HasColumnName("id_documento");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdStro).HasColumnName("id_stro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasColumnName("observacion")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(145)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__empresa__4A0B7E2CBB5A81D9");

                entity.ToTable("empresa");

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.TxtDescripcion)
                    .IsRequired()
                    .HasColumnName("txt_descripcion")
                    .HasMaxLength(145)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Juicio>(entity =>
            {
                entity.HasKey(e => e.IdJuicio)
                    .HasName("PK__juicio__C34C7089D2C0374F");

                entity.ToTable("juicio");

                entity.HasIndex(e => e.IdStro)
                    .HasName("FK_juicio_stro");

                entity.Property(e => e.IdJuicio).HasColumnName("id_juicio");

                entity.Property(e => e.FechaCarga)
                    .HasColumnName("fecha_carga")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fecha_ingreso")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.FechaNotificacion)
                    .HasColumnName("fecha_notificacion")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdStro).HasColumnName("id_stro");

                entity.Property(e => e.IdTipoProceso).HasColumnName("id_tipo_proceso");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NroExpediente)
                    .HasColumnName("nro_expediente")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.TxtCaratula)
                    .HasColumnName("txt_caratula")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TxtDomicilioEmpresa)
                    .HasColumnName("txt_domicilio_empresa")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TxtJuzgado)
                    .HasColumnName("txt_juzgado")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TxtLetradoEmpresa)
                    .HasColumnName("txt_letrado_empresa")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStroNavigation)
                    .WithMany(p => p.Juicio)
                    .HasForeignKey(d => d.IdStro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_juicio_stro");
            });

            modelBuilder.Entity<JuicioAuditoria>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("juicio_auditoria");

                entity.Property(e => e.FechaCarga)
                    .HasColumnName("fecha_carga")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fecha_ingreso")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.FechaNotificacion)
                    .HasColumnName("fecha_notificacion")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdJuicio)
                    .HasColumnName("id_juicio")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IdStro).HasColumnName("id_stro");

                entity.Property(e => e.IdTipoProceso).HasColumnName("id_tipo_proceso");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NroExpediente)
                    .HasColumnName("nro_expediente")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.TxtCaratula)
                    .HasColumnName("txt_caratula")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TxtDomicilioEmpresa)
                    .HasColumnName("txt_domicilio_empresa")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TxtJuzgado)
                    .HasColumnName("txt_juzgado")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TxtLetradoEmpresa)
                    .HasColumnName("txt_letrado_empresa")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mediacion>(entity =>
            {
                entity.HasKey(e => e.IdMediacion)
                    .HasName("PK__mediacio__B4AA75CFE1CECD9F");

                entity.ToTable("mediacion");

                entity.HasIndex(e => e.IdStro)
                    .HasName("FK_mediacion_siniestro");

                entity.Property(e => e.IdMediacion).HasColumnName("id_mediacion");

                entity.Property(e => e.FechaCarga)
                    .IsRequired()
                    .HasColumnName("fecha_carga")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fecha_ingreso")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdStro).HasColumnName("id_stro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.SnActaDeCierre).HasColumnName("sn_acta_de_cierre");

                entity.Property(e => e.SnCerradaConAcuerdo).HasColumnName("sn_cerrada_con_acuerdo");

                entity.Property(e => e.TxtCaratula)
                    .HasColumnName("txt_caratula")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.TxtLetradoActora)
                    .HasColumnName("txt_letrado_actora")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.TxtLetradoDemanda)
                    .HasColumnName("txt_letrado_demanda")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.TxtMediador)
                    .HasColumnName("txt_mediador")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.TxtNroExpediente)
                    .HasColumnName("txt_nro_expediente")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStroNavigation)
                    .WithMany(p => p.Mediacion)
                    .HasForeignKey(d => d.IdStro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mediacion_siniestro");
            });

            modelBuilder.Entity<MediacionAuditoria>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mediacion_auditoria");

                entity.Property(e => e.FechaCarga)
                    .HasColumnName("fecha_carga")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fecha_ingreso")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdMediacion).HasColumnName("id_mediacion");

                entity.Property(e => e.IdStro).HasColumnName("id_stro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.SnActaDeCierre).HasColumnName("sn_acta_de_cierre");

                entity.Property(e => e.SnCerradaConAcuerdo).HasColumnName("sn_cerrada_con_acuerdo");

                entity.Property(e => e.TxtCaratula)
                    .HasColumnName("txt_caratula")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.TxtLetradoActora)
                    .HasColumnName("txt_letrado_actora")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.TxtLetradoDemanda)
                    .HasColumnName("txt_letrado_demanda")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.TxtMediador)
                    .HasColumnName("txt_mediador")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.TxtNroExpediente)
                    .HasColumnName("txt_nro_expediente")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PK__menu__68A1D9DBA6834E09");

                entity.ToTable("menu");

                entity.Property(e => e.IdMenu).HasColumnName("id_menu");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SnActivo)
                    .HasColumnName("sn_activo")
                    .HasDefaultValueSql("('-1')");
            });

            modelBuilder.Entity<MenuTipoUsuario>(entity =>
            {
                entity.HasKey(e => new { e.IdSubMenu, e.IdTipoUsuario })
                    .HasName("PK__menu_tip__30C5EC6FA0553F76");

                entity.ToTable("menu_tipo_usuario");

                entity.HasIndex(e => e.IdTipoUsuario)
                    .HasName("FK_menu_tipo_usuario_tipo");

                entity.Property(e => e.IdSubMenu).HasColumnName("id_sub_menu");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.HasOne(d => d.IdSubMenuNavigation)
                    .WithMany(p => p.MenuTipoUsuario)
                    .HasForeignKey(d => d.IdSubMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_menu_tipo_usuario_menu");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.MenuTipoUsuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_menu_tipo_usuario_tipo");
            });

            modelBuilder.Entity<Monto>(entity =>
            {
                entity.HasKey(e => e.IdEstimacion)
                    .HasName("PK__monto__AACEB1DEC4F5CF3A");

                entity.ToTable("monto");

                entity.HasIndex(e => e.IdTipoMonto)
                    .HasName("FK_tipo_monto");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("FK_monto_usuario");

                entity.HasIndex(e =>  e.IdConcepto)
                    .HasName("FK_monto_concpeto");

                entity.Property(e => e.IdEstimacion).HasColumnName("id_estimacion");

                entity.Property(e => e.CodEstim).HasColumnName("cod_estim");

                entity.Property(e => e.FechaCarga)
                    .HasColumnName("fecha_carga")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdClasePago).HasColumnName("id_clase_pago");

                entity.Property(e => e.IdConcepto).HasColumnName("id_concepto");

                entity.Property(e => e.IdInstancia).HasColumnName("id_instancia");

                entity.Property(e => e.IdReclamante).HasColumnName("id_reclamante");

                entity.Property(e => e.IdSituacion).HasColumnName("id_situacion");

                entity.Property(e => e.IdTipoMonto).HasColumnName("id_tipo_monto");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Importe).HasColumnName("importe");

                entity.HasOne(d => d.IdClasePagoNavigation)
                    .WithMany(p => p.Monto)
                    .HasForeignKey(d => d.IdClasePago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_monto_clase_pago");

                entity.HasOne(d => d.IdInstanciaNavigation)
                    .WithMany(p => p.Monto)
                    .HasForeignKey(d => d.IdInstancia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_monto_instancia");

                entity.HasOne(d => d.IdTipoMontoNavigation)
                    .WithMany(p => p.Monto)
                    .HasForeignKey(d => d.IdTipoMonto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipo_monto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Monto)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_monto_usuario");

                entity.HasOne(d => d.IdC)
                    .WithMany(p => p.Monto)
                    .HasForeignKey(d =>  d.IdConcepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_monto_concpeto");
            });

            modelBuilder.Entity<Reclamante>(entity =>
            {
                entity.HasKey(e => e.IdReclamante)
                    .HasName("PK__reclaman__96C0C237E452266A");

                entity.ToTable("reclamante");

                entity.HasIndex(e => e.IdStro)
                    .HasName("FK_reclamante_stro");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("FK_reclamante_usuario");

                entity.Property(e => e.IdReclamante).HasColumnName("id_reclamante");

                entity.Property(e => e.FechaCarga)
                    .HasColumnName("fecha_carga")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdStro).HasColumnName("id_stro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NroReclamo).HasColumnName("nro_reclamo");

                entity.Property(e => e.SnActivo).HasColumnName("sn_activo");

                entity.Property(e => e.TxtDanTerceros)
                    .IsRequired()
                    .HasColumnName("txt_dan_terceros")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.TxtDni)
                    .IsRequired()
                    .HasColumnName("txt_dni")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TxtDomicilio)
                    .IsRequired()
                    .HasColumnName("txt_domicilio")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TxtDominio)
                    .IsRequired()
                    .HasColumnName("txt_dominio")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TxtNombre)
                    .IsRequired()
                    .HasColumnName("txt_nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TxtVehiculo)
                    .IsRequired()
                    .HasColumnName("txt_vehiculo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStroNavigation)
                    .WithMany(p => p.Reclamante)
                    .HasForeignKey(d => d.IdStro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reclamante_stro");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reclamante)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reclamante_usuario");
            });

            modelBuilder.Entity<Recupero>(entity =>
            {
                entity.HasKey(e => e.IdRecupero)
                    .HasName("PK__recupero__BD21FB3FA427468F");

                entity.ToTable("recupero");

                entity.Property(e => e.IdRecupero).HasColumnName("id_recupero");

                entity.Property(e => e.CiaSeguro)
                    .IsRequired()
                    .HasColumnName("cia_seguro")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CostoReparacionUnidad).HasColumnName("costo_reparacion_unidad");

                entity.Property(e => e.DiasDetencionUnidad).HasColumnName("dias_detencion_unidad");

                entity.Property(e => e.FecCarga)
                    .HasColumnName("fec_carga")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.FecEstimPago)
                    .HasColumnName("fec_estim_pago")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.FechaReclamo)
                    .HasColumnName("fecha_reclamo")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdStro).HasColumnName("id_stro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.LucroCesante).HasColumnName("lucro_cesante");

                entity.Property(e => e.MontoReclamado).HasColumnName("monto_reclamado");

                entity.Property(e => e.PerdidaValorUnidad).HasColumnName("perdida_valor_unidad");
            });

            modelBuilder.Entity<RecuperoAuditoria>(entity =>
            {
                entity.HasKey(e => e.IdRecupero)
                    .HasName("PK__recupero__BD21FB3F6FEEF6F9");

                entity.ToTable("recupero_auditoria");

                entity.Property(e => e.IdRecupero)
                    .HasColumnName("id_recupero")
                    .ValueGeneratedNever();

                entity.Property(e => e.CiaSeguro)
                    .IsRequired()
                    .HasColumnName("cia_seguro")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CostoReparacionUnidad).HasColumnName("costo_reparacion_unidad");

                entity.Property(e => e.DiasDetencionUnidad).HasColumnName("dias_detencion_unidad");

                entity.Property(e => e.FecCarga)
                    .HasColumnName("fec_carga")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.FecEstimPago)
                    .HasColumnName("fec_estim_pago")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.FechaReclamo)
                    .HasColumnName("fecha_reclamo")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdStro).HasColumnName("id_stro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.LucroCesante).HasColumnName("lucro_cesante");

                entity.Property(e => e.MontoReclamado).HasColumnName("monto_reclamado");

                entity.Property(e => e.PerdidaValorUnidad).HasColumnName("perdida_valor_unidad");
            });

            modelBuilder.Entity<RecuperoGasto>(entity =>
            {
                entity.HasKey(e => e.IdRecuperoGasto)
                    .HasName("PK__recupero__A1E869D0F3F1DF49");

                entity.ToTable("recupero_gasto");

                entity.Property(e => e.IdRecuperoGasto).HasColumnName("id_recupero_gasto");

                entity.Property(e => e.FechaCarga)
                    .HasColumnName("fecha_carga")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdEstim).HasColumnName("id_estim");

                entity.Property(e => e.IdRecupero).HasColumnName("id_recupero");

                entity.Property(e => e.IdTipoGasto).HasColumnName("id_tipo_gasto");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Importe).HasColumnName("importe");
            });

            modelBuilder.Entity<RecuperoNota>(entity =>
            {
                entity.HasKey(e => e.IdRecuperoNota)
                    .HasName("PK__recupero__75F5D12EC5C3574C");

                entity.ToTable("recupero_nota");

                entity.Property(e => e.IdRecuperoNota).HasColumnName("id_recupero_nota");

                entity.Property(e => e.FecCarga)
                    .HasColumnName("fec_carga")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdRecupero).HasColumnName("id_recupero");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.TxtNota)
                    .IsRequired()
                    .HasColumnName("txt_nota")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.TxtTitulo)
                    .IsRequired()
                    .HasColumnName("txt_titulo")
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Representante>(entity =>
            {
                entity.HasKey(e => e.IdRepresentante)
                    .HasName("PK__represen__39352885416CEA31");

                entity.ToTable("representante");

                entity.Property(e => e.IdRepresentante).HasColumnName("id_representante");

                entity.Property(e => e.SnActivo).HasColumnName("sn_activo");

                entity.Property(e => e.TxtMail)
                    .IsRequired()
                    .HasColumnName("txt_mail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TxtNombre)
                    .IsRequired()
                    .HasColumnName("txt_nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TxtTelefono)
                    .IsRequired()
                    .HasColumnName("txt_telefono")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Responsabilidad>(entity =>
            {
                entity.HasKey(e => e.IdResponsabilidad)
                    .HasName("PK__responsa__9FF914B7A64D6F07");

                entity.ToTable("responsabilidad");

                entity.Property(e => e.IdResponsabilidad).HasColumnName("id_responsabilidad");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.SnActivo).HasColumnName("sn_activo");
            });

            modelBuilder.Entity<Siniestro>(entity =>
            {
                entity.HasKey(e => e.IdStro)
                    .HasName("PK__siniestr__42A21CF74FE7E5D0");

                entity.ToTable("siniestro");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("FK_siniestro_empresa");

                entity.HasIndex(e => e.IdRepresentante)
                    .HasName("FK_siniestro_representante");

                entity.HasIndex(e => e.IdTipoSiniestro)
                    .HasName("FK_siniestro_tipo");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("FK_siniestro_usuario");

                entity.Property(e => e.IdStro).HasColumnName("id_stro");

                entity.Property(e => e.DañoAsegurado).HasColumnName("daño_asegurado");

                entity.Property(e => e.DañoTerecero).HasColumnName("daño_terecero");

                entity.Property(e => e.FechaCarga)
                    .HasColumnName("fecha_carga")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.FechaSiniestro)
                    .HasColumnName("fecha_siniestro")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Gestiona)
                    .IsRequired()
                    .HasColumnName("gestiona")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.IdRepresentante).HasColumnName("id_representante");

                entity.Property(e => e.IdResponsabilidad).HasColumnName("id_responsabilidad");

                entity.Property(e => e.IdTipoSiniestro).HasColumnName("id_tipo_siniestro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NroReclamoProteccion).HasColumnName("nro_reclamo_proteccion");

                entity.Property(e => e.NroSiniestroProteccion).HasColumnName("nro_siniestro_proteccion");

                entity.Property(e => e.NroStro).HasColumnName("nro_stro");

                entity.Property(e => e.TxtConductor)
                    .IsRequired()
                    .HasColumnName("txt_conductor")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TxtDeclaracion)
                    .IsRequired()
                    .HasColumnName("txt_declaracion")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.TxtDominio)
                    .IsRequired()
                    .HasColumnName("txt_dominio")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TxtHora)
                    .HasColumnName("txt_hora")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TxtInterno)
                    .IsRequired()
                    .HasColumnName("txt_interno")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TxtLugar)
                    .IsRequired()
                    .HasColumnName("txt_lugar")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.TxtObservaciones)
                    .IsRequired()
                    .HasColumnName("txt_observaciones")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Siniestro)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siniestro_empresa");

                entity.HasOne(d => d.IdRepresentanteNavigation)
                    .WithMany(p => p.Siniestro)
                    .HasForeignKey(d => d.IdRepresentante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siniestro_representante");

                entity.HasOne(d => d.IdTipoSiniestroNavigation)
                    .WithMany(p => p.Siniestro)
                    .HasForeignKey(d => d.IdTipoSiniestro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siniestro_tipo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Siniestro)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siniestro_usuario");
            });

            modelBuilder.Entity<SiniestroAuditoria>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("siniestro_auditoria");

                entity.Property(e => e.DañoAsegurado).HasColumnName("daño_asegurado");

                entity.Property(e => e.DañoTerecero).HasColumnName("daño_terecero");

                entity.Property(e => e.FechaCarga)
                    .HasColumnName("fecha_carga")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.FechaSiniestro)
                    .HasColumnName("fecha_siniestro")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Gestiona)
                    .IsRequired()
                    .HasColumnName("gestiona")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.IdRepresentante).HasColumnName("id_representante");

                entity.Property(e => e.IdResponsabilidad).HasColumnName("id_responsabilidad");

                entity.Property(e => e.IdStro).HasColumnName("id_stro");

                entity.Property(e => e.IdTipoSiniestro).HasColumnName("id_tipo_siniestro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NroReclamoProteccion)
                    .HasColumnName("nro_reclamo_proteccion")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NroSiniestroProteccion)
                    .HasColumnName("nro_siniestro_proteccion")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TxtConductor)
                    .IsRequired()
                    .HasColumnName("txt_conductor")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TxtDeclaracion)
                    .IsRequired()
                    .HasColumnName("txt_declaracion")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.TxtDominio)
                    .IsRequired()
                    .HasColumnName("txt_dominio")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TxtHora)
                    .HasColumnName("txt_hora")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TxtInterno)
                    .IsRequired()
                    .HasColumnName("txt_interno")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TxtLugar)
                    .IsRequired()
                    .HasColumnName("txt_lugar")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.TxtObservaciones)
                    .IsRequired()
                    .HasColumnName("txt_observaciones")
                    .HasMaxLength(450)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SiniestroEstado>(entity =>
            {
                entity.HasKey(e => e.IdSiniestroEstado)
                    .HasName("PK__siniestr__88DD7F83BD0A0722");

                entity.ToTable("siniestro_estado");

                entity.Property(e => e.IdSiniestroEstado).HasColumnName("id_siniestro_estado");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.IdInstancia).HasColumnName("id_instancia");

                entity.Property(e => e.IdSituacion).HasColumnName("id_situacion");

                entity.Property(e => e.IdStro).HasColumnName("id_stro");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            });

            modelBuilder.Entity<Submenu>(entity =>
            {
                entity.HasKey(e => e.IdSubMenu)
                    .HasName("PK__submenu__ABD23BE34C14450E");

                entity.ToTable("submenu");

                entity.HasIndex(e => e.IdMenu)
                    .HasName("FK_submenu_menu");

                entity.Property(e => e.IdSubMenu).HasColumnName("id_sub_menu");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdMenu).HasColumnName("id_menu");

                entity.Property(e => e.Pagina)
                    .IsRequired()
                    .HasColumnName("pagina")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SnActivo).HasColumnName("sn_activo");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.Submenu)
                    .HasForeignKey(d => d.IdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_submenu_menu");
            });

            modelBuilder.Entity<TipoBusqueda>(entity =>
            {
                entity.HasKey(e => e.IdTipoBusqueda)
                    .HasName("PK__tipo_bus__ECCFEF69C8F7B669");

                entity.ToTable("tipo_busqueda");

                entity.Property(e => e.IdTipoBusqueda).HasColumnName("id_tipo_busqueda");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(145)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEstadoNotaRecupero>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__tipo_est__86989FB24B897818");

                entity.ToTable("tipo_estado_nota_recupero");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.SnActivo).HasColumnName("sn_activo");

                entity.Property(e => e.TxtDescripcion)
                    .IsRequired()
                    .HasColumnName("txt_descripcion")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoGastoRecupero>(entity =>
            {
                entity.HasKey(e => e.IdTipoGastoRecupero)
                    .HasName("PK__tipo_gas__1C5A38D3841DEA07");

                entity.ToTable("tipo_gasto_recupero");

                entity.Property(e => e.IdTipoGastoRecupero).HasColumnName("id_tipo_gasto_recupero");

                entity.Property(e => e.SnActivo).HasColumnName("sn_activo");

                entity.Property(e => e.TxtDescripcion)
                    .IsRequired()
                    .HasColumnName("txt_descripcion")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoInstancia>(entity =>
            {
                entity.HasKey(e => e.IdInstancia)
                    .HasName("PK__tipo_ins__0FB6ABCDE09959D4");

                entity.ToTable("tipo_instancia");

                entity.Property(e => e.IdInstancia).HasColumnName("id_instancia");

                entity.Property(e => e.TxtDescripcion)
                    .IsRequired()
                    .HasColumnName("txt_descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoMonto>(entity =>
            {
                entity.HasKey(e => e.IdTipoMonto)
                    .HasName("PK__tipo_mon__E55D822099BBA985");

                entity.ToTable("tipo_monto");

                entity.Property(e => e.IdTipoMonto).HasColumnName("id_tipo_monto");

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.Property(e => e.TxtDescripcion)
                    .IsRequired()
                    .HasColumnName("txt_descripcion")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoProceso>(entity =>
            {
                entity.HasKey(e => e.IdTipoProceso)
                    .HasName("PK__tipo_pro__BF7574D122F72B2A");

                entity.ToTable("tipo_proceso");

                entity.Property(e => e.IdTipoProceso).HasColumnName("id_tipo_proceso");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SnActivo).HasColumnName("sn_activo");
            });

            modelBuilder.Entity<TipoSiniestro>(entity =>
            {
                entity.HasKey(e => e.IdTipoSiniestro)
                    .HasName("PK__tipo_sin__3109328F93FB5EED");

                entity.ToTable("tipo_siniestro");

                entity.Property(e => e.IdTipoSiniestro).HasColumnName("id_tipo_siniestro");

                entity.Property(e => e.TxtDescripcion)
                    .IsRequired()
                    .HasColumnName("txt_descripcion")
                    .HasMaxLength(145)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoSituacion>(entity =>
            {
                entity.ToTable("tipo_situacion");

                entity.HasIndex(e => e.IdInstancia)
                    .HasName("FK_tipo_situacion_instancia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdInstancia).HasColumnName("id_instancia");

                entity.Property(e => e.IdSituacion).HasColumnName("id_situacion");

                entity.Property(e => e.SnCargaMonto)
                    .HasColumnName("sn_carga_monto")
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.TxtDescripcion)
                    .IsRequired()
                    .HasColumnName("txt_descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstanciaNavigation)
                    .WithMany(p => p.TipoSituacion)
                    .HasForeignKey(d => d.IdInstancia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipo_situacion_instancia");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipo_usu__B17D78C80BE63223");

                entity.ToTable("tipo_usuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__4E3E04AD0F2C3FA7");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.IdTipoUsuario)
                    .HasName("FK_usuario_tipo");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.CodUsuario)
                    .IsRequired()
                    .HasColumnName("cod_usuario")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.SnActivo).HasColumnName("sn_activo");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuario_tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
