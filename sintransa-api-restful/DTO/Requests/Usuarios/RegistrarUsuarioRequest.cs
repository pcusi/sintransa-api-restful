using System;
namespace sintransa_api_restful.DTO.Requests.Usuarios
{
    public class RegistrarUsuarioRequest
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public long IdAfiliado { get; set; }
    }
}
