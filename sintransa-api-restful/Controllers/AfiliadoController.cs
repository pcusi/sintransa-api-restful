using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using sintransa_api_restful.DTO.Requests.Afiliados;
using sintransa_api_restful.DTO.Responses.Afiliados;
using sintransa_api_restful.Models;
using sintransa_api_restful.Resources;

namespace sintransa_api_restful.Controllers
{
    public class AfiliadoController : AppController
    {
        public AfiliadoController(SintransaDbContext db, IConfiguration config, IStringLocalizer<SharedResource> stringLocalizer) : base(db, config, stringLocalizer) { }

        [HttpPost("agregar")]
        public async Task<IActionResult> AgregarAfiliado([FromBody] RegistrarAfiliadoRequest request)
        {

            var afiliado = new Afiliados
            {
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                Dni = request.Dni,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                Area = request.Area,
                Cargo = request.Cargo,
                Activo = true
            };

            _db.Afiliados.Add(afiliado);

            await _db.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpGet("listar")]
        public async Task<ListarAfiliadosResponse[]> ListarAfiliados()
        {
            var afiliados = await _db.Afiliados
                .Where(a => a.Activo)
                .Select(a => new ListarAfiliadosResponse {
                    Id = a.Id,
                    Nombres = a.Nombres,
                    Apellidos = a.Apellidos,
                    Direccion = a.Direccion,
                    Dni = a.Dni,
                    Telefono = a.Telefono,
                    Cargo = a.Cargo.Trim(),
                    Area = a.Area.Trim()
                })
                .ToArrayAsync();

            return afiliados;                           
        }

        [Authorize]
        [HttpPost("{IdAfiliado}/editar")]
        public async Task<IActionResult> EditarAfiliado([FromBody] RegistrarAfiliadoRequest request, [FromRoute] long IdAfiliado)
        {

            var afiliado = await _db.Afiliados
                .Where(a => a.Id == IdAfiliado)
                .SingleOrDefaultAsync() ?? throw NotFoundError();

            afiliado.Nombres = request.Nombres;
            afiliado.Apellidos = request.Apellidos;
            afiliado.Direccion = request.Direccion;
            afiliado.Dni = request.Dni;
            afiliado.Telefono = request.Telefono;
            afiliado.Cargo = request.Cargo;
            afiliado.Area = request.Area;

            await _db.SaveChangesAsync();

            return Ok();
        }
     }
}
