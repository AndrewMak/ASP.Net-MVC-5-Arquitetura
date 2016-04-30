using System.Web.Mvc;

namespace VG.Profissional.Infra.CrossCutting.MVCFiltros.Filtros
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                // Gravar log, enviar email, etc....
                filterContext.Controller.TempData["CodErro"] = 1010;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
