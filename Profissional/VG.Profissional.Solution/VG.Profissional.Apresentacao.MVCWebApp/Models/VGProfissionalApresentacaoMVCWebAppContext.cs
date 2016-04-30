using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VG.Profissional.Apresentacao.MVCWebApp.Models
{
    public class VGProfissionalApresentacaoMVCWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VGProfissionalApresentacaoMVCWebAppContext() : base("name=VGProfissionalApresentacaoMVCWebAppContext")
        {
        }

        public System.Data.Entity.DbSet<VG.Profissional.Aplicacao.ViewModels.CursoViewModel> CursoViewModels { get; set; }

        public System.Data.Entity.DbSet<VG.Profissional.Aplicacao.ViewModels.ExperienciaViewModel> ExperienciaViewModels { get; set; }

        public System.Data.Entity.DbSet<VG.Profissional.Aplicacao.ViewModels.FerramentaViewModel> FerramentaViewModels { get; set; }

        public System.Data.Entity.DbSet<VG.Profissional.Aplicacao.ViewModels.ContatoViewModel> ContatoViewModels { get; set; }

        public System.Data.Entity.DbSet<VG.Profissional.Aplicacao.ViewModels.CurriculoContatoViewModel> CurriculoContatoViewModels { get; set; }
    }
}
