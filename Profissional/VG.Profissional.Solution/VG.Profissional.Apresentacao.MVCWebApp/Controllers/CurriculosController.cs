using System;
using System.Net;
using System.Web.Mvc;
using VG.Profissional.Aplicacao.Interfaces;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Apresentacao.MVCWebApp.Controllers
{
    //[RoutePrefix("Admin/Config/Curriculos")]
    //[Route("{action=Index}")]
    [Authorize]
    public class CurriculosController : Controller
    {
        private readonly ICurriculoAppServicos _curriculoAppServicos;
        private readonly IContatoAppServicos _contatoAppServicos;

        public CurriculosController(ICurriculoAppServicos curriculoAppServicos, IContatoAppServicos contatoAppServicos)
        {
            _curriculoAppServicos = curriculoAppServicos;
            _contatoAppServicos = contatoAppServicos;
        }

        // GET: Curriculos
       //[Route("Admin/Config/Index")]
        public ActionResult Index()
        {
            return View(_curriculoAppServicos.ObterTodos());
        }

        // GET: Curriculos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurriculoViewModel curriculoViewModel = _curriculoAppServicos.ObterPorId(id.Value);
            if (curriculoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(curriculoViewModel); 
        }

        // GET: Curriculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curriculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurriculoId,Nome,DataNascimento,Localizacao, Telefone, Email, Facebook, LinkedIn")] CurriculoContatoViewModel curriculoViewModel)
        {
            if (ModelState.IsValid)
            {
                _curriculoAppServicos.Adicionar(curriculoViewModel);
                return RedirectToAction("Index");
            }

            return View(curriculoViewModel);
        }

        // GET: Curriculos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurriculoViewModel curriculoViewModel = _curriculoAppServicos.ObterPorId(id.Value);
            if (curriculoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(curriculoViewModel);
        }

        // POST: Curriculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurriculoId,Nome,DataNascimento,Localizacao")] CurriculoViewModel curriculoViewModel)
        {
            if (ModelState.IsValid)
            {
                _curriculoAppServicos.Atualizar(curriculoViewModel);
                return RedirectToAction("Index");
            }
            return View(curriculoViewModel);
        }

        // GET: Curriculos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurriculoViewModel curriculoViewModel = _curriculoAppServicos.ObterPorId(id.Value);
            if (curriculoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(curriculoViewModel);
        }

        // POST: Curriculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _curriculoAppServicos.Remover(id);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("~/")]
        public ActionResult Completo()
        {
            return View(_curriculoAppServicos.ObterCompleto("Vinicius Grund"));
        }

        public ActionResult AtualizarContatos(Guid id)
        {
            return PartialView("_AtualizarContatos", _contatoAppServicos.ObterPorCurriculo(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarContatos(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _contatoAppServicos.Atualizar(contatoViewModel);

                string url = Url.Action("AtualizarContatos", "Curriculos", new { id = contatoViewModel.CurriculoId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AtualizarContatos", contatoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _curriculoAppServicos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
