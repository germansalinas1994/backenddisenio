using System;
using DataAccess.Entities;

namespace BussinessLogic.DTO
{
    public class UCTDTO
    {
        public int IdUct { get; set; }

        public string? Codigo { get; set; }

        public string? Denominacion { get; set; }

        public string? Localidad { get; set; }

        public string? Regional { get; set; }

        public int? Tipo { get; set; }



    }
}

