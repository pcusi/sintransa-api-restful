using System;
namespace sintransa_api_restful.DTO.Responses.Afiliados
{
    public class ListarAfiliadosResponse
    {
        public long Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Cargo { get; set; }
        public string Area { get; set; }
        public string Direccion { get; set; }
    }
}
