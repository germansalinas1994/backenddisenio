using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class PidUct
{
    public int IdPidUct { get; set; }

    public int? IdPid { get; set; }

    public int? IdUct { get; set; }

    public virtual Pid? IdP { get; set; }

    public virtual Uct? IdUctNavigation { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }
}
