using System;
namespace sintransa_api_restful.Models
{
    public class Afiliados : IIdAutogenerado<long>
    {
        public long Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Cargo { get; set; }
        public string Area { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }
}
