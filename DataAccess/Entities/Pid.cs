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

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public int? IdUniversidad { get; set; }

    public int? IdTipoPid { get; set; }

    public string? Director { get; set; }

    public virtual Tipopid? TipoPid { get; set; }

    public virtual Universidad? Universidad { get; set; }

    public virtual ICollection<PidUct> PidUct { get; set; } = new List<PidUct>();
}
