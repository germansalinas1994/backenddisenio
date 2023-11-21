﻿using System;
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

    public string? Programa { get; set; }

    public virtual Tipopid? IdTipoP { get; set; }

    public virtual Universidad? IdUniversidadNavigation { get; set; }

    public virtual ICollection<UctIniciativainvestigacion> UctIniciativainvestigacion { get; set; } = new List<UctIniciativainvestigacion>();
}