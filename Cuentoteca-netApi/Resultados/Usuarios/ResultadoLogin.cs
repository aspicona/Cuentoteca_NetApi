using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuentoteca_netApi.Resultados.Usuarios
{
    public class ResultadoLogin : ResultadoBase
    {
        public int IdUsuario { get; set; }

        public string Email { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string? Token { get; set; }
    }
}
