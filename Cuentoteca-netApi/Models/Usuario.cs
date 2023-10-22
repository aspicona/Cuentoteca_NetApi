using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string Email { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public int? IdRol { get; set; }

    public int? IdNivelLector { get; set; }

    public virtual ICollection<Autorizacione> Autorizaciones { get; set; } = new List<Autorizacione>();

    public virtual ICollection<Calificacionesyresenia> Calificacionesyresenia { get; set; } = new List<Calificacionesyresenia>();

    public virtual NivelesLector? IdNivelLectorNavigation { get; set; }

    public virtual Role? IdRolNavigation { get; set; }

    public virtual ICollection<Notificacione> NotificacioneIdEmisorNavigations { get; set; } = new List<Notificacione>();

    public virtual ICollection<Notificacione> NotificacioneIdReceptorNavigations { get; set; } = new List<Notificacione>();

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
