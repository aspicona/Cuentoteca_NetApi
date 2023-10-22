using Cuentoteca_netApi.DTO;
using Cuentoteca_netApi.DTO.Comandos.Usuarios;
using Cuentoteca_netApi.Models;
using Cuentoteca_netApi.Resultados;
using Cuentoteca_netApi.Resultados.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuentoteca_netApi.Services.Usuarios
{
    public interface IUsuarioService
    {
        Task<ResultadoRegistrar> RegistrarUsuario(ComandoRegistrar datos);
        Task<ActionResult<ResultadoLogin>> Login(ComandoLogin datos);
        Task<ResultadoGetAllUsuarios> GetAll();
        Task<ResultadoGetUsuario> GetById(int id);
        Task<ResultadoUpdate> Update(int id, ComandoUpdateUsuario datos);
        Task<ResultadoDelete> Delete(int id);

    }
}
