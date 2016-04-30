using System;
using System.Net;
using System.Web.Mvc;
using VG.Profissional.Aplicacao.Interfaces;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Apresentacao.MVCWebApp.Controllers
{
    [Authorize]
    public class FerramentasController : Controller
    {
        private readonly IFerramentaAppServicos _ferramentaAppServicos;
        private readonly ICurriculoAppServicos _curriculoAppServicos;

        public FerramentasController(IFerramentaAppServicos ferramentaAppServicos, ICurriculoAppServicos curriculoAppServicos)
        {
            _ferramentaAppServicos = ferramentaAppServicos;
            _curriculoAppServicos = curriculoAppServicos;
        }

        // GET: Ferramentas
        public ActionResult Index()
        {
            return View(_ferramentaAppServicos.ObterTodos());
        }

        // GET: Ferramentas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FerramentaViewModel ferramentaViewModel = _ferramentaAppServicos.ObterPorId(id.Value);
            if (ferramentaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ferramentaViewModel);
        }

        // GET: Ferramentas/Create
        public ActionResult Create()
        {
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome");
            return View();
        }

        // POST: Ferramentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FerramentaId,Nome,CurriculoId")] FerramentaViewModel ferramentaViewModel)
        {
            if (ModelState.IsValid)
            {
                _ferramentaAppServicos.Adicionar(ferramentaViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", ferramentaViewModel.CurriculoId);
            return View(ferramentaViewModel);
        }

        // GET: Ferramentas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FerramentaViewModel ferramentaViewModel = _ferramentaAppServicos.ObterPorId(id.Value);
            if (ferramentaViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", ferramentaViewModel.CurriculoId);
            return View(ferramentaViewModel);
        }

        // POST: Ferramentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FerramentaId,Nome,CurriculoId")] FerramentaViewModel ferramentaViewModel)
        {
            if (ModelState.IsValid)
            {
                _ferramentaAppServicos.Atualizar(ferramentaViewModel);
                return RedirectToAction("Index");
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", ferramentaViewModel.CurriculoId);
            return View(ferramentaViewModel);
        }

        // GET: Ferramentas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FerramentaViewModel ferramentaViewModel = _ferramentaAppServicos.ObterPorId(id.Value);
            if (ferramentaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ferramentaViewModel);
        }

        // POST: Ferramentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _ferramentaAppServicos.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ferramentaAppServicos.Dispose();
                _curriculoAppServicos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
