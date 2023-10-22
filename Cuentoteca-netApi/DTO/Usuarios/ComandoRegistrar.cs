using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuentoteca_netApi.DTO.Comandos.Usuarios
{
    public class ComandoRegistrar
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int IdRol { get; set; }

        public int? IdNivelLector { get; set; }


    }
}
