using System.Data.Entity.ModelConfiguration;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Infra.Data.EntityConfig
{
    public class FerramentaConfiguracao : EntityTypeConfiguration<Ferramenta>
    {
        public FerramentaConfiguracao()
        {
            HasKey(f => f.FerramentaId);

            Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(f => f.Curriculo)
                .WithMany(c => c.Ferramentas)
                .HasForeignKey(f => f.CurriculoId);

            ToTable("Ferramentas");
        }
    }
}
