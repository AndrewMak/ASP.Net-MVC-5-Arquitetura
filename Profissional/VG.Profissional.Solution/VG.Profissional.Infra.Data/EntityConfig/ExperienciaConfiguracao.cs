using System.Data.Entity.ModelConfiguration;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Infra.Data.EntityConfig
{
    public class ExperienciaConfiguracao : EntityTypeConfiguration<Experiencia>
    {
        public ExperienciaConfiguracao()
        {
            HasKey(e => e.ExperienciaId);

            Property(e => e.NomeEmpresa)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Cargo)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Anos)
                .IsRequired();

            HasRequired(e => e.Curriculo)
                .WithMany(c => c.Experiencias)
                .HasForeignKey(e => e.CurriculoId);

            ToTable("Experiencias");
        }
    }
}
