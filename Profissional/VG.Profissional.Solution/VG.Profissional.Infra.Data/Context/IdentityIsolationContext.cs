using System.Data.Entity;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Infra.Data.EntityConfig;

namespace VG.Profissional.Infra.Data.Context
{
    public class IdentityIsolationContext : DbContext
    {
        public IdentityIsolationContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
