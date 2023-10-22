using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Cuentoteca_netApi.Models;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Cuentoteca_netApi.Services.Usuarios;
using Cuentoteca_netApi.Resultados.Usuarios;
using Cuentoteca_netApi.DTO.Comandos.Usuarios;

namespace Cuentoteca_netApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //private readonly string secretKey;

        private readonly CuentotecaContext _context;
        private readonly IUsuarioService _service;
        public UsuarioController(CuentotecaContext context, IUsuarioService service)
        {
            _context = context;
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResultadoLogin>> Login([FromBody] ComandoLogin comando)
        {
            return await _service.Login(comando);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ResultadoRegistrar>> RegistrarUsuario([FromBody] ComandoRegistrar comando)
        {
            return await _service.RegistrarUsuario(comando);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<ResultadoGetAllUsuarios>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("getById/{id}")]

        public async Task<ActionResult<ResultadoGetUsuario>> GetUsuario(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ResultadoUpdate>> Update(int id, [FromBody] ComandoUpdateUsuario comando)
        {
            return await _service.Update(id, comando);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ResultadoDelete>> Delete(int id)
        {
            return await _service.Delete(id);
        }

        //public AutenticacionController(IConfiguration config)
        //{
        //    secretKey= config.GetSection("Settings").GetSection("SecretKey").ToString();
        //}

        //[HttpPost]
        //[Route("Validar")]
        //public IActionResult Validar([FromBody] Usuario request)
        //{

        //}
    }
}
