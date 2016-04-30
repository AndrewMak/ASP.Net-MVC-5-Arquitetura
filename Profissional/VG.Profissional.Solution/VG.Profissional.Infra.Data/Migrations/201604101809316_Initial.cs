namespace VG.Profissional.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apresentacoes",
                c => new
                    {
                        ApresentacaoId = c.Guid(nullable: false),
                        Texto = c.String(nullable: false, maxLength: 200, unicode: false),
                        CurriculoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ApresentacaoId)
                .ForeignKey("dbo.Curriculos", t => t.CurriculoId)
                .Index(t => t.CurriculoId);
            
            CreateTable(
                "dbo.Curriculos",
                c => new
                    {
                        CurriculoId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 40, unicode: false),
                        DataNascimento = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        Localizacao = c.String(nullable: false, maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.CurriculoId);
            
            CreateTable(
                "dbo.Competencias",
                c => new
                    {
                        CompetenciaId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 80, unicode: false),
                        NivelMaturidade = c.String(nullable: false, maxLength: 30, unicode: false),
                        AnosExperiencia = c.Int(nullable: false),
                        UltimaUtilizacao = c.String(nullable: false, maxLength: 30, unicode: false),
                        CurriculoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CompetenciaId)
                .ForeignKey("dbo.Curriculos", t => t.CurriculoId)
                .Index(t => t.CurriculoId);
            
            CreateTable(
                "dbo.Contatos",
                c => new
                    {
                        ContatoId = c.Guid(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 30, unicode: false),
                        Email = c.String(nullable: false, maxLength: 80, unicode: false),
                        Facebook = c.String(maxLength: 300, unicode: false),
                        LinkedIn = c.String(maxLength: 300, unicode: false),
                        CurriculoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ContatoId)
                .ForeignKey("dbo.Curriculos", t => t.CurriculoId)
                .Index(t => t.CurriculoId);
            
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        CursoId = c.Guid(nullable: false),
                        Instituicao = c.String(nullable: false, maxLength: 150, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Ementa = c.String(maxLength: 1500, unicode: false),
                        CurriculoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CursoId)
                .ForeignKey("dbo.Curriculos", t => t.CurriculoId)
                .Index(t => t.CurriculoId);
            
            CreateTable(
                "dbo.Experiencias",
                c => new
                    {
                        ExperienciaId = c.Guid(nullable: false),
                        NomeEmpresa = c.String(nullable: false, maxLength: 200, unicode: false),
                        Cargo = c.String(nullable: false, maxLength: 100, unicode: false),
                        Anos = c.Int(nullable: false),
                        CurriculoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienciaId)
                .ForeignKey("dbo.Curriculos", t => t.CurriculoId)
                .Index(t => t.CurriculoId);
            
            CreateTable(
                "dbo.Ferramentas",
                c => new
                    {
                        FerramentaId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        CurriculoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FerramentaId)
                .ForeignKey("dbo.Curriculos", t => t.CurriculoId)
                .Index(t => t.CurriculoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Apresentacoes", "CurriculoId", "dbo.Curriculos");
            DropForeignKey("dbo.Ferramentas", "CurriculoId", "dbo.Curriculos");
            DropForeignKey("dbo.Experiencias", "CurriculoId", "dbo.Curriculos");
            DropForeignKey("dbo.Cursos", "CurriculoId", "dbo.Curriculos");
            DropForeignKey("dbo.Contatos", "CurriculoId", "dbo.Curriculos");
            DropForeignKey("dbo.Competencias", "CurriculoId", "dbo.Curriculos");
            DropIndex("dbo.Ferramentas", new[] { "CurriculoId" });
            DropIndex("dbo.Experiencias", new[] { "CurriculoId" });
            DropIndex("dbo.Cursos", new[] { "CurriculoId" });
            DropIndex("dbo.Contatos", new[] { "CurriculoId" });
            DropIndex("dbo.Competencias", new[] { "CurriculoId" });
            DropIndex("dbo.Apresentacoes", new[] { "CurriculoId" });
            DropTable("dbo.Ferramentas");
            DropTable("dbo.Experiencias");
            DropTable("dbo.Cursos");
            DropTable("dbo.Contatos");
            DropTable("dbo.Competencias");
            DropTable("dbo.Curriculos");
            DropTable("dbo.Apresentacoes");
        }
    }
}
