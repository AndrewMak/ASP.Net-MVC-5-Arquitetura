using System.Data.Entity.ModelConfiguration;using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Infra.Data.EntityConfig
{
    public class ApresentacaoConfiguracao : EntityTypeConfiguration<Apresentacao>
    {
        public ApresentacaoConfiguracao()
        {
            HasKey(a => a.ApresentacaoId);

            Property(a => a.Texto)
                .IsRequired()
                .HasMaxLength(200);

            HasRequired(a => a.Curriculo)
                .WithMany(c => c.Apresentacoes)
                .HasForeignKey(a => a.CurriculoId);

            ToTable("Apresentacoes");
        }
    }
}
