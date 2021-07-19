using System;
namespace sintransa_api_restful.Models
{
    public class Eventos : IIdAutogenerado<long>
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Fecha { get; set; }
        public string Enlace { get; set; }
        public bool Activo { get; set; }
    }
}
