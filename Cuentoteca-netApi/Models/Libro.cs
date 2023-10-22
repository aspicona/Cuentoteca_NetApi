using System;
using System.Collections.Generic;

namespace Cuentoteca_netApi.Models;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? Titulo { get; set; }

    public string? Autor { get; set; }

    public string? Isbn { get; set; }

    public string? Descripcion { get; set; }

    public int? AnioPublicacion { get; set; }

    public int? IdColeccion { get; set; }

    public string? CodInterno { get; set; }

    public DateTime? FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public string? MotivoBaja { get; set; }

    public virtual ICollection<Calificacionesyresenia> Calificacionesyresenia { get; set; } = new List<Calificacionesyresenia>();

    public virtual Coleccione? IdColeccionNavigation { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
