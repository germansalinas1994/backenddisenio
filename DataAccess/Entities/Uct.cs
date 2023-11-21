using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Uct
{
    public int IdUct { get; set; }

    public string? Codigo { get; set; }

    public string? Denominacion { get; set; }

    public string? Localidad { get; set; }

    public string? Regional { get; set; }

    public int? Tipo { get; set; }

    public virtual ICollection<PidUct> PidUct { get; set; } = new List<PidUct>();

    public virtual ICollection<UctIniciativainvestigacion> UctIniciativainvestigacion { get; set; } = new List<UctIniciativainvestigacion>();
}
