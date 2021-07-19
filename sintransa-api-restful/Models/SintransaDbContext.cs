using System;
using Microsoft.EntityFrameworkCore;
using sintransa_api_restful.Models.Extensions;

namespace sintransa_api_restful.Models
{
    public class SintransaDbContext : DbContext
    {
        public SintransaDbContext(DbContextOptions<SintransaDbContext> options) : base(options) { }

        public DbSet<Afiliados> Afiliados { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Eventos> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Afiliados>(entity =>
            {
                entity.ToTable(nameof(Afiliados));

                entity.ConfigurarIdentityLongId();

                entity.Property(e => e.Nombres).IsRequiredVariableLengthString(50, false);
                entity.Property(e => e.Apellidos).IsRequiredVariableLengthString(50, false);
                entity.Property(e => e.Direccion).IsRequiredVariableLengthString(250, false);
                entity.Property(e => e.Telefono).IsRequiredVariableLengthString(9, false);
                entity.Property(e => e.Dni).IsRequiredVariableLengthString(8, false);
                entity.Property(e => e.Cargo).IsRequiredVariableLengthString(20, false);
                entity.Property(e => e.Area).IsRequiredVariableLengthString(20, false);

                entity.HasKey(e => e.Id);
            });

            builder.Entity<Usuarios>(entity =>
            {
                entity.ToTable(nameof(Usuarios));

                entity.ConfigurarIdentityLongId();

                entity.Property(e => e.Usuario).IsRequiredVariableLengthString(50, false);
                entity.Property(e => e.Clave).IsRequiredVariableLengthString(250, false);
                entity.Property(e => e.Rol).IsRequiredVariableLengthString(1, false);

                entity.MapearUnoMuchosUnidireccional(e => e.Afiliado, e => e.IdAfiliado);

                entity.HasKey(e => e.Id);
            });

            builder.Entity<Eventos>(entity => {

                entity.ToTable(nameof(Eventos));

                entity.Property(e => e.Nombre).IsRequiredVariableLengthString(50, false);
                entity.Property(e => e.Descripcion).IsRequiredVariableLengthString(100, false);
                entity.Property(e => e.Enlace).IsRequiredVariableLengthString(200, false);

                entity.HasKey(e => e.Id);
            });
        }
    }
}
