using System;
using DataAccess.Entities;

namespace BussinessLogic.DTO
{
   public class RequestPIDDTO
    {

        public int idPid { get; set; }
        public string? denominacion { get; set; }

        public string fechaDesde { get; set; }

        public string fechaHasta { get; set; }

        public int universidad { get; set; }

        public int tipoPid { get; set; }
        public int uct { get; set; }

        public string director { get; set; }



    }
}


