using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class Notificacione
{
    public int IdNotificacion { get; set; }

    public int? IdEmisor { get; set; }

    public int? IdReceptor { get; set; }

    public int? IdMensaje { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public string? Estado { get; set; }

    public int? IdTipoNotif { get; set; }

    public virtual Usuario? IdEmisorNavigation { get; set; }

    public virtual Usuario? IdReceptorNavigation { get; set; }

    public virtual TiposNotific? IdTipoNotifNavigation { get; set; }
}
