using Microsoft.Owin;
using Owin;
using VG.Profissional.Apresentacao.MVCWebApp;

[assembly: OwinStartup(typeof(Startup))]
namespace VG.Profissional.Apresentacao.MVCWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}