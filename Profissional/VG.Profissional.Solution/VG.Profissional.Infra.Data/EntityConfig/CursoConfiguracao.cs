
using System.Data.Entity.ModelConfiguration;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Infra.Data.EntityConfig
{
    public class CursoConfiguracao : EntityTypeConfiguration<Curso>
    {
        public CursoConfiguracao()
        {
            HasKey(c => c.CursoId);

            Property(c => c.Instituicao)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Ementa)
                .HasMaxLength(4000);

            HasRequired(c => c.Curriculo)
                .WithMany(c => c.Cursos)
                .HasForeignKey(c => c.CurriculoId);

            ToTable("Cursos");
        }
    }
}
