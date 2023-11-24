using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeders
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<IniciativaInvestigacion>().HasData(
            //     new IniciativaInvestigacion
            //     {
            //         IdIniciativaInvestigacion = 1,
            //         Denominacion = "Iniciativa 1",
            //         Director = "Director 1",
            //         FechaDesde = DateTime.Now,
            //         FechaHasta = DateTime.Now.AddYears(1),
            //         FechaAlta = DateTime.Now,
            //         FechaActualizacion = DateTime.Now,
            //         Programa = "Programa 1",
            //         IdTipoPid = 1,
            //         IdUniversidad = 1,
            //     }
            //     ); 
            // modelBuilder.Entity<Pid>().HasData(
            //     new Pid
            //     {
            //         IdPid = 1,
            //         Denominacion = "PID 1",
            //         FechaDesde = DateTime.Now,
            //         FechaHasta = DateTime.Now.AddYears(1),
            //         FechaActualizacion = DateTime.Now,
            //         FechaAlta = DateTime.Now,
            //         Director = "Director 1",
            //         IdTipoPid = 1,
            //         IdUniversidad = 1,
            //     }
            //     );
            // modelBuilder.Entity<PidUct>().HasData(
            //     new PidUct
            //     {
            //         IdPidUct = 1,
            //         FechaAlta = DateTime.Now,
            //         FechaActualizacion = DateTime.Now,
            //         IdPid = 1,
            //         IdUct = 1,
            //     }
            //     );
            
            modelBuilder.Entity<Tipopid>().HasData(
                new Tipopid
                {
                    IdTipoPid = 1,
                    Codigo = "PIDTC",
                    Descripcion = "PID para Equipos de Trabajo Consolidado"
                },
                new Tipopid
                {
                    IdTipoPid = 2,
                    Codigo = "PIDEC",
                    Descripcion = "PID para Equipos de Trabajo en Consolidación"
                },
                new Tipopid
                {
                    IdTipoPid = 3,
                    Codigo = "PIDPP",
                    Descripcion = "PID de Iniciación a la Investigación o Primer Proyecto"
                },
                new Tipopid
                {
                    IdTipoPid = 4,
                    Codigo = "PIDA",
                    Descripcion = "PID Asociativo"
                }
            );


            modelBuilder.Entity<Uct>().HasData(
                new Uct
                {
                    IdUct = 1,
                    Codigo = "CIDER",
                    Denominacion = "Centro de Investigación y Desarrollo Regional",
                    Localidad = "San Rafael",
                    Regional = "San Rafael",
                    Tipo = 1
                },
                new Uct
                {
                    IdUct = 2,
                    Codigo = "CODAPLI",
                    Denominacion = "Centro de Investigación de Codiseño Aplicado",
                    Localidad = "La Plata",
                    Regional = "La Plata",
                    Tipo = 1
                },
                new Uct
                {
                    IdUct = 3,
                    Codigo = "IEC",
                    Denominacion = "Grupo de Investigación en Enseñanza de las Ciencias",
                    Localidad = "La Plata",
                    Regional = "La Plata",
                    Tipo = 2
                },
                new Uct
                {
                    IdUct = 4,
                    Codigo = "GIDAS",
                    Denominacion = "Grupo de Investigación y Desarrollo Aplicado a Sistemas",
                    Localidad = "La Plata",
                    Regional = "La Plata",
                    Tipo = 2
                }
            );

            modelBuilder.Entity<Universidad>().HasData(
                new Universidad
                {
                    IdUniversidad = 1,
                    Nombre = "UTN FRLP",
                    Direccion = "Calle 60 esq 124"
                },
                new Universidad
                {
                    IdUniversidad = 2,
                    Nombre = "UNLP",
                    Direccion = "Calle 1 esq 47"
                }
            );

            //     modelBuilder.Entity<UctIniciativainvestigacion>().HasData(
            //     new UctIniciativainvestigacion
            //     {
            //         IdUctIniciativaInvestigacion = 1,
            //         FechaAlta = DateTime.Now,
            //         FechaActualizacion = DateTime.Now,
            //         IdIniciativainvestigacion = 1,
            //         IdUct = 1,
            //     }
            //     );



        }
    }
}
