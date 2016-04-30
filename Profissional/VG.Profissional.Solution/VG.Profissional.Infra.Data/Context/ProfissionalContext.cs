using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Infra.Data.EntityConfig;

namespace VG.Profissional.Infra.Data.Context
{
    public class ProfissionalContext : DbContext
    {
        public DbSet<Curriculo> Curriculos { get; set; }
        public DbSet<Apresentacao> Apresentacoes { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<Ferramenta> Ferramentas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Retirando algumas convencoes
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Configurando as chaves primarias
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Caso nao seja informado um tipo especifico em propriedades string, sera considerado como varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //Caso nao seja informado um tamanho maximo em propriedades string, sera considerado como 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //Adicionando classes de configuração dos modelos FLUENT API
            modelBuilder.Configurations.Add(new ApresentacaoConfiguracao());
            modelBuilder.Configurations.Add(new CompetenciaConfiguracao());
            modelBuilder.Configurations.Add(new ContatoConfiguracao());
            modelBuilder.Configurations.Add(new CurriculoConfiguracao());
            modelBuilder.Configurations.Add(new CursoConfiguracao());
            modelBuilder.Configurations.Add(new ExperienciaConfiguracao());
            modelBuilder.Configurations.Add(new FerramentaConfiguracao());

            base.OnModelCreating(modelBuilder);
        }

        
        //Sobrescrevendo o metodo SaveChanges
        public override int SaveChanges()
        {
            //Caso exista uma propriedade chamada DataCadastro, sera automaticamente considerado DateTime.Now
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
