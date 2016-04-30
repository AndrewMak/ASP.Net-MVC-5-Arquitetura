using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using VG.Profissional.Aplicacao.Interfaces;
using VG.Profissional.Aplicacao.Servicos;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Dominio.Interfaces.Servicos;
using VG.Profissional.Dominio.Servicos;
using VG.Profissional.Infra.CrossCutting.Identity.Configuration;
using VG.Profissional.Infra.CrossCutting.Identity.Context;
using VG.Profissional.Infra.CrossCutting.Identity.Model;
using VG.Profissional.Infra.Data.Context;
using VG.Profissional.Infra.Data.Interfaces;
using VG.Profissional.Infra.Data.Repositorios;
using VG.Profissional.Infra.Data.UnitofWork;

namespace VG.Profissional.Infra.CrossCutting.IoC
{

    public class Bootstrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<ICurriculoRepositorio, CurriculoRepositorio>(Lifestyle.Scoped);
            container.Register<ICurriculoAppServicos, CurriculoAppServicos>(Lifestyle.Scoped);
            container.Register<IApresentacaoRepositorio, ApresentacaoRepositorio>(Lifestyle.Scoped);
            container.Register<IApresentacaoAppServicos, ApresentacaoAppServicos>(Lifestyle.Scoped);
            container.Register<ICompetenciaRepositorio, CompetenciaRepositorio>(Lifestyle.Scoped);
            container.Register<ICompetenciaAppServicos, CompetenciaAppServicos>(Lifestyle.Scoped);
            container.Register<IContatoRepositorio, ContatoRepositorio>(Lifestyle.Scoped);
            container.Register<IContatoAppServicos, ContatoAppServicos>(Lifestyle.Scoped);
            container.Register<ICursoRepositorio, CursoRepositorio>(Lifestyle.Scoped);
            container.Register<ICursoAppServicos, CursoAppServicos>(Lifestyle.Scoped);
            container.Register<IExperienciaRepositorio, ExperienciaRepositorio>(Lifestyle.Scoped);
            container.Register<IExperienciaAppServicos, ExperienciaAppServicos>(Lifestyle.Scoped);
            container.Register<IFerramentaRepositorio, FerramentaRepositorio>(Lifestyle.Scoped);
            container.Register<IFerramentaAppServicos, FerramentaAppServicos>(Lifestyle.Scoped);
            container.Register<ProfissionalContext>(Lifestyle.Scoped);
            container.Register<IUnitofWork, UnitofWork>(Lifestyle.Scoped);
            container.Register<ICurriculoServico, CurriculoServico>(Lifestyle.Scoped);
            container.Register<IApresentacaoServico, ApresentacaoServico>(Lifestyle.Scoped);
            container.Register<ICompetenciaServico, CompetenciaServico>(Lifestyle.Scoped);
            container.Register<IContatoServico, ContatoServico>(Lifestyle.Scoped);
            container.Register<ICursoServico, CursoServico>(Lifestyle.Scoped);
            container.Register<IExperienciaServico, ExperienciaServico>(Lifestyle.Scoped);
            container.Register<IFerramentaServico, FerramentaServico>(Lifestyle.Scoped);
            container.Register<IUsuarioServico, UsuarioServico>(Lifestyle.Scoped);
            
            //Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            container.RegisterPerWebRequest<IUsuarioRepositorio, UsuarioRepositorio>();
            container.Register<IUsuarioAppServicos, UsuarioAppServicos>(Lifestyle.Scoped);
        }
    }
}
