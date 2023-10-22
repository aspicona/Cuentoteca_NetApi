﻿using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
