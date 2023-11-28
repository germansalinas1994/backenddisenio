using System;
using DataAccess.Entities;

namespace BussinessLogic.DTO
{
    public class IniciativaDTO
    {
        public int? IdIniciativaInvestigacion { get; set; } //CAMBIE ESTE

        public string? Denominacion { get; set; }

        public DateTime? FechaDesde { get; set; }

        public DateTime? FechaHasta { get; set; }

        public int? Universidad { get; set; }

        public int? TipoPid { get; set; }

        public string? Director { get; set; }

        public string? Programa { get; set; } // SE AGREGA ESTE

        public int? IdUCT { get; set; }

        public UCTDTO Uct { get; set; }


    }
}

