using System;
namespace sintransa_api_restful.DTO.Requests.Eventos
{
    public class RegistrarEventoRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Fecha { get; set; }
        public string Enlace { get; set; }
        public bool Activo { get; set; }
    }
}
