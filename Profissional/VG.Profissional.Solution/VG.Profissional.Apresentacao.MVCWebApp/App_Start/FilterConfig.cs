using System.Web.Mvc;
using VG.Profissional.Infra.CrossCutting.MVCFiltros.Filtros;

namespace VG.Profissional.Apresentacao.MVCWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
