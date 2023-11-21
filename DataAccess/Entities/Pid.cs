using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Pid
{
    public int IdPid { get; set; }

    public string? Denominacion { get; set; }

    public DateTime FechaDesde { get; set; }

    public DateTime FechaHasta { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public int? IdUniversidad { get; set; }

    public int? IdTipoPid { get; set; }

    public string? Director { get; set; }

    public virtual Tipopid? IdTipoP { get; set; }

    public virtual Universidad? IdUniversidadNavigation { get; set; }

    public virtual ICollection<PidUct> PidUct { get; set; } = new List<PidUct>();
}
