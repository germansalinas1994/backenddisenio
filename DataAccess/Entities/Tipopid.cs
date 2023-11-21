using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Tipopid
{
    public int IdTipoPid { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<IniciativaInvestigacion> IniciativaInvestigacion { get; set; } = new List<IniciativaInvestigacion>();

    public virtual ICollection<Pid> Pid { get; set; } = new List<Pid>();
}
