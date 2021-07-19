using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using sintransa_api_restful.DTO.Requests.Usuarios;
using sintransa_api_restful.Models;
using sintransa_api_restful.Resources;

namespace sintransa_api_restful.Controllers
{
    public class UsuarioController : AppController
    {
        public UsuarioController(SintransaDbContext db, IConfiguration config, IStringLocalizer<SharedResource> stringLocalizer) : base(db, config, stringLocalizer) { }

        [HttpPost("agregar")]
        public async Task<IActionResult> AgregarUsuario([FromBody] RegistrarUsuarioRequest request)
        {

            var hashClave = BCrypt.Net.BCrypt.HashPassword(request.Clave);

            var usuario = new Usuarios
            {
                Usuario = request.Usuario,
                Clave = hashClave,
                Rol = request.Rol,
                IdAfiliado = request.IdAfiliado
            };

            _db.Usuarios.Add(usuario);

            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
