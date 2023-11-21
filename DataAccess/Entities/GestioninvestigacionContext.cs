using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public partial class GestioninvestigacionContext : DbContext
{
    public GestioninvestigacionContext()
    {
    }

    public GestioninvestigacionContext(DbContextOptions<GestioninvestigacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<IniciativaInvestigacion> IniciativaInvestigacion { get; set; }

    public virtual DbSet<Pid> Pid { get; set; }

    public virtual DbSet<PidUct> PidUct { get; set; }

    public virtual DbSet<Tipopid> Tipopid { get; set; }

    public virtual DbSet<Uct> Uct { get; set; }

    public virtual DbSet<UctIniciativainvestigacion> UctIniciativainvestigacion { get; set; }

    public virtual DbSet<Universidad> Universidad { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3306;database=gestioninvestigacion;uid=root;password=12345678;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IniciativaInvestigacion>(entity =>
        {
            entity.HasKey(e => e.IdIniciativaInvestigacion).HasName("PRIMARY");

            entity.ToTable("iniciativa_investigacion");

            entity.HasIndex(e => e.IdTipoPid, "id_tipoPID_idx");

            entity.HasIndex(e => e.IdUniversidad, "id_universidad_idx");

            entity.Property(e => e.IdIniciativaInvestigacion).HasColumnName("idIniciativa_Investigacion");
            entity.Property(e => e.Denominacion)
                .HasMaxLength(45)
                .HasColumnName("denominacion");
            entity.Property(e => e.Director)
                .HasMaxLength(45)
                .HasColumnName("director");
            entity.Property(e => e.FechaDesde)
                .HasColumnType("datetime")
                .HasColumnName("fecha_desde");
            entity.Property(e => e.FechaHasta)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hasta");
            entity.Property(e => e.IdTipoPid).HasColumnName("id_tipoPID");
            entity.Property(e => e.IdUniversidad).HasColumnName("id_universidad");
            entity.Property(e => e.Programa)
                .HasMaxLength(45)
                .HasColumnName("programa");

            entity.HasOne(d => d.IdTipoP).WithMany(p => p.IniciativaInvestigacion)
                .HasForeignKey(d => d.IdTipoPid)
                .HasConstraintName("id_tipoPID");

            entity.HasOne(d => d.IdUniversidadNavigation).WithMany(p => p.IniciativaInvestigacion)
                .HasForeignKey(d => d.IdUniversidad)
                .HasConstraintName("id_universidad");
        });

        modelBuilder.Entity<Pid>(entity =>
        {
            entity.HasKey(e => e.IdPid).HasName("PRIMARY");

            entity.ToTable("pid");

            entity.HasIndex(e => e.IdTipoPid, "id_tipoPID_FK_P_idx");

            entity.HasIndex(e => e.IdUniversidad, "id_universidad_FK_P_idx");

            entity.Property(e => e.IdPid).HasColumnName("idPID");
            entity.Property(e => e.Denominacion)
                .HasMaxLength(45)
                .HasColumnName("denominacion");
            entity.Property(e => e.Director)
                .HasMaxLength(45)
                .HasColumnName("director");
            entity.Property(e => e.FechaDesde)
                .HasColumnType("datetime")
                .HasColumnName("fecha_desde");
            entity.Property(e => e.FechaHasta)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hasta");
            entity.Property(e => e.IdTipoPid).HasColumnName("id_tipoPID");
            entity.Property(e => e.IdUniversidad).HasColumnName("id_universidad");

            entity.HasOne(d => d.IdTipoP).WithMany(p => p.Pid)
                .HasForeignKey(d => d.IdTipoPid)
                .HasConstraintName("id_tipoPID_FK_P");

            entity.HasOne(d => d.IdUniversidadNavigation).WithMany(p => p.Pid)
                .HasForeignKey(d => d.IdUniversidad)
                .HasConstraintName("id_universidad_FK_P");
        });

        modelBuilder.Entity<PidUct>(entity =>
        {
            entity.HasKey(e => e.IdPidUct).HasName("PRIMARY");

            entity.ToTable("pid_uct");

            entity.HasIndex(e => e.IdPid, "id_PID_FK_U_idx");

            entity.HasIndex(e => e.IdUct, "id_UCT_FK_U_idx");

            entity.Property(e => e.IdPidUct).HasColumnName("idPID_UCT");
            entity.Property(e => e.IdPid).HasColumnName("id_PID");
            entity.Property(e => e.IdUct).HasColumnName("id_UCT");

            entity.HasOne(d => d.IdP).WithMany(p => p.PidUct)
                .HasForeignKey(d => d.IdPid)
                .HasConstraintName("id_PID_FK_U");

            entity.HasOne(d => d.IdUctNavigation).WithMany(p => p.PidUct)
                .HasForeignKey(d => d.IdUct)
                .HasConstraintName("id_UCT_FK_U");
        });

        modelBuilder.Entity<Tipopid>(entity =>
        {
            entity.HasKey(e => e.IdTipoPid).HasName("PRIMARY");

            entity.ToTable("tipopid");

            entity.Property(e => e.IdTipoPid).HasColumnName("idTipoPID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(45)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Uct>(entity =>
        {
            entity.HasKey(e => e.IdUct).HasName("PRIMARY");

            entity.ToTable("uct");

            entity.Property(e => e.IdUct).HasColumnName("idUCT");
            entity.Property(e => e.Codigo)
                .HasMaxLength(45)
                .HasColumnName("codigo");
            entity.Property(e => e.Denominacion)
                .HasMaxLength(45)
                .HasColumnName("denominacion");
            entity.Property(e => e.Localidad)
                .HasMaxLength(45)
                .HasColumnName("localidad");
            entity.Property(e => e.Regional)
                .HasMaxLength(45)
                .HasColumnName("regional");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
        });

        modelBuilder.Entity<UctIniciativainvestigacion>(entity =>
        {
            entity.HasKey(e => e.IdUctIniciativaInvestigacion).HasName("PRIMARY");

            entity.ToTable("uct_iniciativainvestigacion");

            entity.HasIndex(e => e.IdUct, "id_UCT_FK_UI_idx");

            entity.HasIndex(e => e.IdIniciativainvestigacion, "id_iniciativainvestigacion_FK_UI_idx");

            entity.Property(e => e.IdUctIniciativaInvestigacion).HasColumnName("idUCT_IniciativaInvestigacion");
            entity.Property(e => e.IdIniciativainvestigacion).HasColumnName("id_iniciativainvestigacion");
            entity.Property(e => e.IdUct).HasColumnName("id_UCT");

            entity.HasOne(d => d.IdIniciativainvestigacionNavigation).WithMany(p => p.UctIniciativainvestigacion)
                .HasForeignKey(d => d.IdIniciativainvestigacion)
                .HasConstraintName("id_iniciativainvestigacion_FK_UI");

            entity.HasOne(d => d.IdUctNavigation).WithMany(p => p.UctIniciativainvestigacion)
                .HasForeignKey(d => d.IdUct)
                .HasConstraintName("id_UCT_FK_UI");
        });

        modelBuilder.Entity<Universidad>(entity =>
        {
            entity.HasKey(e => e.IdUniversidad).HasName("PRIMARY");

            entity.ToTable("universidad");

            entity.Property(e => e.IdUniversidad).HasColumnName("idUniversidad");
            entity.Property(e => e.Direccion)
                .HasMaxLength(45)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
