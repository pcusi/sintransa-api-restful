using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using sintransa_api_restful.DTO.Requests.Eventos;
using sintransa_api_restful.Models;
using sintransa_api_restful.Resources;

namespace sintransa_api_restful.Controllers
{
    [Authorize]
    public class EventoController : AppController
    {
        public EventoController(SintransaDbContext db, IConfiguration config, IStringLocalizer<SharedResource> stringLocalizer) : base(db, config, stringLocalizer) { }

        [HttpPost("agregar")]
        public async Task<IActionResult> AgregarEvento([FromBody] RegistrarEventoRequest request)
        {

            var evento = new Eventos
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Fecha = request.Fecha,
                Enlace = request.Enlace,
                Activo = true
            };

            _db.Eventos.Add(evento);

            await _db.SaveChangesAsync();

            return Ok(); 
        }
    }
}
