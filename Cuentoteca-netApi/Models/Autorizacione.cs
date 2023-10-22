using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class Autorizacione
{
    public int IdAutorizacion { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? IdSala { get; set; }

    public virtual Sala? IdSalaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
