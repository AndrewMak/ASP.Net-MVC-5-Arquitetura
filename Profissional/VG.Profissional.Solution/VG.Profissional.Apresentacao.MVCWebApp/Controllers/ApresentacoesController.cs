using System;
using System.Net;
using System.Web.Mvc;
using VG.Profissional.Aplicacao.Interfaces;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Apresentacao.MVCWebApp.Controllers
{
    [Authorize]
    public class ApresentacoesController : Controller
    {
        private readonly IApresentacaoAppServicos _apresentacaoAppServicos;
        private readonly ICurriculoAppServicos _curriculoAppServicos;

        public ApresentacoesController(IApresentacaoAppServicos apresentacaoAppServicos, ICurriculoAppServicos curriculoAppServicos)
        {
            _apresentacaoAppServicos = apresentacaoAppServicos;
            _curriculoAppServicos = curriculoAppServicos;
        }

        // GET: Apresentacoes
        public ActionResult Index()
        {
            return View(_apresentacaoAppServicos.ObterTodos());
        }

        // GET: Apresentacoes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApresentacaoViewModel apresentacaoViewModel = _apresentacaoAppServicos.ObterPorId(id.Value);
            if (apresentacaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(apresentacaoViewModel);
        }

        // GET: Apresentacoes/Create
        public ActionResult Create()
        {
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", String.Empty);
            return View();
        }

        // POST: Apresentacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApresentacaoId,Texto,CurriculoId")] ApresentacaoViewModel apresentacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                _apresentacaoAppServicos.Adicionar(apresentacaoViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", apresentacaoViewModel.CurriculoId);
            return View(apresentacaoViewModel);
        }

        // GET: Apresentacoes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApresentacaoViewModel apresentacaoViewModel = _apresentacaoAppServicos.ObterPorId(id.Value);
            if (apresentacaoViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", apresentacaoViewModel.CurriculoId);
            return View(apresentacaoViewModel);
        }

        // POST: Apresentacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApresentacaoId,Texto,CurriculoId")] ApresentacaoViewModel apresentacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                _apresentacaoAppServicos.Atualizar(apresentacaoViewModel);
                return RedirectToAction("Index");
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", apresentacaoViewModel.CurriculoId);
            return View(apresentacaoViewModel);
        }

        // GET: Apresentacoes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApresentacaoViewModel apresentacaoViewModel = _apresentacaoAppServicos.ObterPorId(id.Value);
            if (apresentacaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(apresentacaoViewModel);
        }

        // POST: Apresentacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _apresentacaoAppServicos.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _apresentacaoAppServicos.Dispose();
                _curriculoAppServicos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
