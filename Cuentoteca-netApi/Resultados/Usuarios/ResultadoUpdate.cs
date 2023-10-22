using Cuentoteca_netApi.Models;

namespace Cuentoteca_netApi.Resultados.Usuarios
{
    public class ResultadoUpdate : ResultadoBase
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Clave { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int IdRol { get; set; }

        public int IdNivelLector { get; set; }

    }
}
