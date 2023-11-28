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

        public int? IdUniversidad { get; set; }

        public int? IdTipoPid { get; set; }

        public string? Director { get; set; }

        public string? Programa { get; set; } // SE AGREGA ESTE

        public int? IdUCT { get; set; }

        public UCTDTO Uct { get; set; }

        public UniversidadDTO Universidad { get; set; }

        public TipoPidDTO TipoPid { get; set; }

    }
}

