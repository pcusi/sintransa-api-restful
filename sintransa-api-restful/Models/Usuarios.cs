using System;
namespace sintransa_api_restful.Models
{
    public class Usuarios : IIdAutogenerado<long>
    {
        public long Id { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public long IdAfiliado { get; set; }

        public virtual Afiliados Afiliado { get; set; }
    }
}
