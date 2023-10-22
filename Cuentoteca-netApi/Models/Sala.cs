using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class Sala
{
    public int IdSala { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Autorizacione> Autorizaciones { get; set; } = new List<Autorizacione>();
}
