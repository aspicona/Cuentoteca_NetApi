using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class NivelesLector
{
    public int IdNivel { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Avatar { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
