using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class UctIniciativainvestigacion
{
    public int IdUctIniciativaInvestigacion { get; set; }

    public int? IdUct { get; set; }

    public int? IdIniciativainvestigacion { get; set; }

    public virtual IniciativaInvestigacion? IdIniciativainvestigacionNavigation { get; set; }

    public virtual Uct? IdUctNavigation { get; set; }
}
