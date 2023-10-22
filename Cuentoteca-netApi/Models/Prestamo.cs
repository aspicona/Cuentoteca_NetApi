using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class Prestamo
{
    public int IdPrestamo { get; set; }

    public int? IdLibro { get; set; }

    public int? IdLector { get; set; }

    public DateTime? FechaPrestamo { get; set; }

    public DateTime? PlazoDevolucion { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public string? Comentario { get; set; }

    public virtual Usuario? IdLectorNavigation { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }
}
