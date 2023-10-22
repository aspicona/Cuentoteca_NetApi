using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class Coleccione
{
    public int IdColeccion { get; set; }

    public string? Nombre { get; set; }

    public string? Editorial { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
