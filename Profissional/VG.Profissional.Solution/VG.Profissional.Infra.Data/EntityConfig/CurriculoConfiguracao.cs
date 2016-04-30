using System.Data.Entity.ModelConfiguration;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Infra.Data.EntityConfig
{
    public class CurriculoConfiguracao : EntityTypeConfiguration<Curriculo>
    {
        public CurriculoConfiguracao()
        {
            HasKey(c => c.CurriculoId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(40);

            Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnType("smalldatetime");

            Property(c => c.Localizacao)
                .IsRequired()
                .HasMaxLength(80);

            ToTable("Curriculos");
        }
    }
}
