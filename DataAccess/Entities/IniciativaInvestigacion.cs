using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class IniciativaInvestigacion
{
    public int IdIniciativaInvestigacion { get; set; }

    public int? IdUniversidad { get; set; }

    public int? IdTipoPid { get; set; }

    public string? Director { get; set; }

    public string? Denominacion { get; set; }

    public DateTime? FechaDesde { get; set; }

    public DateTime? FechaHasta { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public string? Programa { get; set; }

    public virtual Tipopid? TipoPid { get; set; }

    public virtual Universidad? Universidad { get; set; }

    public virtual ICollection<UctIniciativainvestigacion> UctIniciativainvestigacion { get; set; } = new List<UctIniciativainvestigacion>();
}
