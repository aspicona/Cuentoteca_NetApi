
using Cuentoteca_netApi.DTO;
using Cuentoteca_netApi.Resultados;
using Cuentoteca_netApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cuentoteca_netApi.Resultados.Usuarios;
using Cuentoteca_netApi.DTO.Comandos.Usuarios;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Cuentoteca_netApi.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly CuentotecaContext _context;
        public UsuarioService(CuentotecaContext context)
        {
            _context = context;
        }


        public async Task<ResultadoGetAllUsuarios> GetAll()
        {
            var usuarios = new List<Usuario>();
            var result = new ResultadoGetAllUsuarios();
            try
            {
                usuarios = await _context.Usuarios.ToListAsync();

                if (usuarios.Count > 0)
                {
                    result.ListaUsuarios = usuarios;
                    result.StatusCode = (int)HttpStatusCode.OK;
                    return result;
                }
                else
                {
                    result.SetError("No se encontraron usuarios");
                    result.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.SetError("Error al obtener usuarios");
                result.StatusCode = (int)HttpStatusCode.NotFound;
                return result;
            }
        }

        public async Task<ResultadoGetUsuario> GetById(int id)
        {
            var result = new ResultadoGetUsuario();
            try
            {
                var usuario = await _context.Usuarios.Where(x =>
                x.IdUsuario.Equals(id)).FirstOrDefaultAsync();

                if (usuario != null)
                {
                    result.Usuario = usuario;
                    result.StatusCode = (int)HttpStatusCode.OK;
                    return result;
                }
                else
                {
                    result.SetError("Usuario no encontrado en la base de datos");
                    result.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.SetError("Error al obtener el usuario");
                result.StatusCode = (int)HttpStatusCode.NotFound;
                return result;
            }
        }

        public async Task<ActionResult<ResultadoLogin>> Login(ComandoLogin comando)
        {
            var result = new ResultadoLogin();
            try
            {
                var usuario = await _context.Usuarios.Where(x =>
                x.Email.Equals(comando.Email) && x.Clave.Equals(comando.Clave)).FirstOrDefaultAsync();

                if (usuario != null)
                {
                    result.IdUsuario = (int)usuario.IdUsuario;
                    result.Nombre = usuario.Nombre;
                    result.Apellido = usuario.Apellido;
                    result.Email = usuario.Email;
                  
                    result.StatusCode = (int)HttpStatusCode.OK;

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(">i>1:6#-[aw/Owpe");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, result.Email)
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    result.Token = tokenHandler.WriteToken(token);
                    
                    return result;
                }
                else
                {
                    result.SetError("Usuario no encontrado en la base de datos");
                    result.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.SetError("Error al obtener el usuario");
                result.StatusCode = (int)HttpStatusCode.NotFound;
                return result;
            }
        }

        public async Task<ResultadoRegistrar> RegistrarUsuario(ComandoRegistrar datos)
        {
            var resultado = new ResultadoRegistrar();

            if (datos == null)
            {
                resultado.SetError("No se han ingresado datos para registrar un usuario.");
                resultado.StatusCode = (int)HttpStatusCode.NotFound;
                return resultado;
            }

            //Valido que el usuario no exista. 
            var validarUsuario = await _context.Usuarios.SingleOrDefaultAsync(x => x.Nombre == datos.Nombre && x.Apellido == datos.Apellido);
            if (validarUsuario != null)
            {
                resultado.SetError("Ya existe un usuario con ese Nombre y Apellido.");
                resultado.StatusCode = (int)HttpStatusCode.NotFound;
                return resultado;
            }

            var usuario = new Usuario
            {
                Nombre = datos.Nombre,
                Apellido= datos.Apellido,
                Clave = datos.Password,
                Email = datos.Email,
                IdRol = (int)datos.IdRol,
                IdNivelLector = datos.IdNivelLector
            };

            await _context.Usuarios.AddAsync(usuario);

            var resultadoInsert = await _context.SaveChangesAsync();

            if (resultadoInsert < 1)
            {
                resultado.SetError("No se ha podido registrar el usuario, ha ocurrido un error.");
                resultado.StatusCode = (int)HttpStatusCode.BadRequest;
                return resultado;

            }
            
            resultado.IdUsuario = (int)usuario.IdUsuario;
            resultado.Nombre = usuario.Nombre;
            resultado.Apellido = usuario.Apellido;
            resultado.Email = usuario.Email;
            resultado.IdRol = (int)usuario.IdRol;
            resultado.IdNivelLector = (int)usuario.IdNivelLector;
            resultado.StatusCode = (int)HttpStatusCode.OK;
            return resultado;

        }

        public async Task<ResultadoUpdate> Update(int id, ComandoUpdateUsuario comando)
        {
            var result = new ResultadoUpdate();

            //Busco el usuario por su ID
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(x => x.IdUsuario == id);

            if (usuario == null)
            {
                result.SetError("No se ha encontrado el usuario especificado.");
                result.StatusCode = (int)HttpStatusCode.NotFound;
                return result;
            }

            //Actualizo los campos necesarios del usuario

            usuario.Nombre = comando.Nombre;
            usuario.Apellido = comando.Apellido;
            usuario.Clave = comando.Clave;
            usuario.Email = comando.Email;
            usuario.IdRol = comando.IdRol;
            usuario.IdNivelLector = comando.IdNivelLector;

            _context.Usuarios.Update(usuario);

            var resultadoUpdate = await _context.SaveChangesAsync();

            if (resultadoUpdate < 1)
            {
                result.SetError("No se ha podido actualizar el usuario, ha ocurrido un error.");
                result.StatusCode = (int)HttpStatusCode.BadRequest;
                return result;

            }

            result.Nombre = usuario.Nombre;
            result.Apellido = usuario.Apellido;
            result.Clave = usuario.Clave;
            result.Email = usuario.Email;
            result.IdRol = (int)usuario.IdRol;
            result.IdNivelLector = (int)usuario.IdNivelLector;
            result.StatusCode = (int)HttpStatusCode.OK;

            return result;

        }

        public async Task<ResultadoDelete> Delete(int id)
        {
            var resultado = new ResultadoDelete();

            // Buscamos el usuario por ID.
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                resultado.SetError($"No se ha encontrado un usuario con el ID {id}.");
                resultado.StatusCode = (int)HttpStatusCode.NotFound;
                return resultado;
            }

            // Si existe, lo eliminamos.
            _context.Usuarios.Remove(usuario);

            var resultadoEliminar = await _context.SaveChangesAsync();

            if (resultadoEliminar < 1)
            {
                resultado.SetError($"No se ha podido eliminar el usuario con el ID {id}, ha ocurrido un error.");
                resultado.StatusCode = (int)HttpStatusCode.BadRequest;
                return resultado;
            }

            resultado.StatusCode = (int)HttpStatusCode.OK;
            resultado.SetMensaje($"Usuario con el ID {id} eliminado correctamente.");

            return resultado;

        }
    }

}
