using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class TiposNotific
{
    public int IdTipoNotif { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();
}
