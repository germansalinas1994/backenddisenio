using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Universidad
{
    public int IdUniversidad { get; set; }

    public string? Direccion { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<IniciativaInvestigacion> IniciativaInvestigacion { get; set; } = new List<IniciativaInvestigacion>();

    public virtual ICollection<Pid> Pid { get; set; } = new List<Pid>();
}
