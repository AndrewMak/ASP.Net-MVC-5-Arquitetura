
using System.Data.Entity.ModelConfiguration;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Infra.Data.EntityConfig
{
    public class CompetenciaConfiguracao : EntityTypeConfiguration<Competencia>
    {
        public CompetenciaConfiguracao()
        {
            HasKey(c => c.CompetenciaId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(80);

            Property(c => c.NivelMaturidade)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.AnosExperiencia)
                .IsRequired();

            Property(c => c.UltimaUtilizacao)
                .IsRequired()
                .HasMaxLength(30);

            HasRequired(c => c.Curriculo)
                .WithMany(c => c.Competencias)
                .HasForeignKey(c => c.CurriculoId);

            ToTable("Competencias");
        }
    }
}
