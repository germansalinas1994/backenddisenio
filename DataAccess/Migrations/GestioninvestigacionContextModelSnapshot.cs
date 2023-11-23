﻿// <auto-generated />
using System;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(GestioninvestigacionContext))]
    partial class GestioninvestigacionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataAccess.Entities.IniciativaInvestigacion", b =>
                {
                    b.Property<int>("IdIniciativaInvestigacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idIniciativa_Investigacion");

                    b.Property<string>("Denominacion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("denominacion");

                    b.Property<string>("Director")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("director");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaDesde")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_desde");

                    b.Property<DateTime?>("FechaHasta")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_hasta");

                    b.Property<int?>("IdTipoPid")
                        .HasColumnType("int")
                        .HasColumnName("id_tipoPID");

                    b.Property<int?>("IdUniversidad")
                        .HasColumnType("int")
                        .HasColumnName("id_universidad");

                    b.Property<string>("Programa")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("programa");

                    b.HasKey("IdIniciativaInvestigacion")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdTipoPid" }, "id_tipoPID_idx");

                    b.HasIndex(new[] { "IdUniversidad" }, "id_universidad_idx");

                    b.ToTable("iniciativa_investigacion", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Pid", b =>
                {
                    b.Property<int>("IdPid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPID");

                    b.Property<string>("Denominacion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("denominacion");

                    b.Property<string>("Director")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("director");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaDesde")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_desde");

                    b.Property<DateTime>("FechaHasta")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_hasta");

                    b.Property<int?>("IdTipoPid")
                        .HasColumnType("int")
                        .HasColumnName("id_tipoPID");

                    b.Property<int?>("IdUniversidad")
                        .HasColumnType("int")
                        .HasColumnName("id_universidad");

                    b.HasKey("IdPid")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdTipoPid" }, "id_tipoPID_FK_P_idx");

                    b.HasIndex(new[] { "IdUniversidad" }, "id_universidad_FK_P_idx");

                    b.ToTable("pid", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.PidUct", b =>
                {
                    b.Property<int>("IdPidUct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPID_UCT");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("IdPid")
                        .HasColumnType("int")
                        .HasColumnName("id_PID");

                    b.Property<int?>("IdUct")
                        .HasColumnType("int")
                        .HasColumnName("id_UCT");

                    b.HasKey("IdPidUct")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdPid" }, "id_PID_FK_U_idx");

                    b.HasIndex(new[] { "IdUct" }, "id_UCT_FK_U_idx");

                    b.ToTable("pid_uct", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Tipopid", b =>
                {
                    b.Property<int>("IdTipoPid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTipoPID");

                    b.Property<string>("Codigo")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("codigo");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("descripcion");

                    b.HasKey("IdTipoPid")
                        .HasName("PRIMARY");

                    b.ToTable("tipopid", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Uct", b =>
                {
                    b.Property<int>("IdUct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUCT");

                    b.Property<string>("Codigo")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("codigo");

                    b.Property<string>("Denominacion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("denominacion");

                    b.Property<string>("Localidad")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("localidad");

                    b.Property<string>("Regional")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("regional");

                    b.Property<int?>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("tipo");

                    b.HasKey("IdUct")
                        .HasName("PRIMARY");

                    b.ToTable("uct", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.UctIniciativainvestigacion", b =>
                {
                    b.Property<int>("IdUctIniciativaInvestigacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUCT_IniciativaInvestigacion");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaBaja")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("IdIniciativainvestigacion")
                        .HasColumnType("int")
                        .HasColumnName("id_iniciativainvestigacion");

                    b.Property<int?>("IdUct")
                        .HasColumnType("int")
                        .HasColumnName("id_UCT");

                    b.HasKey("IdUctIniciativaInvestigacion")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdUct" }, "id_UCT_FK_UI_idx");

                    b.HasIndex(new[] { "IdIniciativainvestigacion" }, "id_iniciativainvestigacion_FK_UI_idx");

                    b.ToTable("uct_iniciativainvestigacion", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Universidad", b =>
                {
                    b.Property<int>("IdUniversidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUniversidad");

                    b.Property<string>("Direccion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("direccion");

                    b.Property<string>("Nombre")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nombre");

                    b.HasKey("IdUniversidad")
                        .HasName("PRIMARY");

                    b.ToTable("universidad", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.IniciativaInvestigacion", b =>
                {
                    b.HasOne("DataAccess.Entities.Tipopid", "IdTipoP")
                        .WithMany("IniciativaInvestigacion")
                        .HasForeignKey("IdTipoPid")
                        .HasConstraintName("id_tipoPID");

                    b.HasOne("DataAccess.Entities.Universidad", "IdUniversidadNavigation")
                        .WithMany("IniciativaInvestigacion")
                        .HasForeignKey("IdUniversidad")
                        .HasConstraintName("id_universidad");

                    b.Navigation("IdTipoP");

                    b.Navigation("IdUniversidadNavigation");
                });

            modelBuilder.Entity("DataAccess.Entities.Pid", b =>
                {
                    b.HasOne("DataAccess.Entities.Tipopid", "IdTipoP")
                        .WithMany("Pid")
                        .HasForeignKey("IdTipoPid")
                        .HasConstraintName("id_tipoPID_FK_P");

                    b.HasOne("DataAccess.Entities.Universidad", "IdUniversidadNavigation")
                        .WithMany("Pid")
                        .HasForeignKey("IdUniversidad")
                        .HasConstraintName("id_universidad_FK_P");

                    b.Navigation("IdTipoP");

                    b.Navigation("IdUniversidadNavigation");
                });

            modelBuilder.Entity("DataAccess.Entities.PidUct", b =>
                {
                    b.HasOne("DataAccess.Entities.Pid", "IdP")
                        .WithMany("PidUct")
                        .HasForeignKey("IdPid")
                        .HasConstraintName("id_PID_FK_U");

                    b.HasOne("DataAccess.Entities.Uct", "IdUctNavigation")
                        .WithMany("PidUct")
                        .HasForeignKey("IdUct")
                        .HasConstraintName("id_UCT_FK_U");

                    b.Navigation("IdP");

                    b.Navigation("IdUctNavigation");
                });

            modelBuilder.Entity("DataAccess.Entities.UctIniciativainvestigacion", b =>
                {
                    b.HasOne("DataAccess.Entities.IniciativaInvestigacion", "IdIniciativainvestigacionNavigation")
                        .WithMany("UctIniciativainvestigacion")
                        .HasForeignKey("IdIniciativainvestigacion")
                        .HasConstraintName("id_iniciativainvestigacion_FK_UI");

                    b.HasOne("DataAccess.Entities.Uct", "IdUctNavigation")
                        .WithMany("UctIniciativainvestigacion")
                        .HasForeignKey("IdUct")
                        .HasConstraintName("id_UCT_FK_UI");

                    b.Navigation("IdIniciativainvestigacionNavigation");

                    b.Navigation("IdUctNavigation");
                });

            modelBuilder.Entity("DataAccess.Entities.IniciativaInvestigacion", b =>
                {
                    b.Navigation("UctIniciativainvestigacion");
                });

            modelBuilder.Entity("DataAccess.Entities.Pid", b =>
                {
                    b.Navigation("PidUct");
                });

            modelBuilder.Entity("DataAccess.Entities.Tipopid", b =>
                {
                    b.Navigation("IniciativaInvestigacion");

                    b.Navigation("Pid");
                });

            modelBuilder.Entity("DataAccess.Entities.Uct", b =>
                {
                    b.Navigation("PidUct");

                    b.Navigation("UctIniciativainvestigacion");
                });

            modelBuilder.Entity("DataAccess.Entities.Universidad", b =>
                {
                    b.Navigation("IniciativaInvestigacion");

                    b.Navigation("Pid");
                });
#pragma warning restore 612, 618
        }
    }
}
