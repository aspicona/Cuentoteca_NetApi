using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuentoteca_netApi.DTO.Comandos.Usuarios
{
    public class ComandoLogin
    {
        public string Email { get; set; }

        public string Clave { get; set; }
    }
}
