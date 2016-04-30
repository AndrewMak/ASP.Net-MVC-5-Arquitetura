using System.Web.Mvc;
using VG.Profissional.Aplicacao.Interfaces;

namespace VG.Profissional.Apresentacao.MVCWebApp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppServicos _usuarioAppServicos;

        public UsuariosController(IUsuarioAppServicos usuarioAppServicos)
        {
            _usuarioAppServicos = usuarioAppServicos;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(_usuarioAppServicos.ObterTodos());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            return View(_usuarioAppServicos.ObterPorId(id));
        }

        public ActionResult DesativarLock(string id)
        {
            _usuarioAppServicos.DesativarLock(id);
            return RedirectToAction("Index");
        }
    }
}