using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class Calificacionesyresenia
{
    public int IdCyr { get; set; }

    public int? IdLibro { get; set; }

    public int? IdLector { get; set; }

    public int? Calificacion { get; set; }

    public string? Comentario { get; set; }

    public DateTime? FechaCyr { get; set; }

    public virtual Usuario? IdLectorNavigation { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }
}
