using System.Data.Entity.ModelConfiguration;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Infra.Data.EntityConfig
{
    public class ContatoConfiguracao : EntityTypeConfiguration<Contato>
    {
        public ContatoConfiguracao()
        {
            HasKey(c => c.ContatoId);

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(80);

            Property(c => c.Facebook)
                .HasMaxLength(300);

            Property(c => c.LinkedIn)
                .HasMaxLength(300);

            HasRequired(c => c.Curriculo)
                .WithRequiredPrincipal(c => c.Contato);

            ToTable("Contatos");
        }
    }
}
