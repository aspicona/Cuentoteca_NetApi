using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class Mensaje
{
    public int IdMensaje { get; set; }

    public string? Asunto { get; set; }

    public string? Texto { get; set; }
}
