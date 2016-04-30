using System;
using System.Net;
using System.Web.Mvc;
using VG.Profissional.Aplicacao.Interfaces;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Apresentacao.MVCWebApp.Controllers
{
    [Authorize]
    public class CursosController : Controller
    {
        private readonly ICursoAppServicos _cursoAppServicos;
        private readonly ICurriculoAppServicos _curriculoAppServicos;

        public CursosController(ICursoAppServicos cursoAppServicos, ICurriculoAppServicos curriculoAppServicos)
        {
            _cursoAppServicos = cursoAppServicos;
            _curriculoAppServicos = curriculoAppServicos;
        }

        // GET: Cursos
        public ActionResult Index()
        {
            return View(_cursoAppServicos.ObterTodos());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoViewModel cursoViewModel = _cursoAppServicos.ObterPorId(id.Value);
            if (cursoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cursoViewModel);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome");
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CursoId,Instituicao,Nome,Ementa,CurriculoId")] CursoViewModel cursoViewModel)
        {
            if (ModelState.IsValid)
            {
                _cursoAppServicos.Adicionar(cursoViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", cursoViewModel.CurriculoId);
            return View(cursoViewModel);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoViewModel cursoViewModel = _cursoAppServicos.ObterPorId(id.Value);
            if (cursoViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", cursoViewModel.CurriculoId);
            return View(cursoViewModel);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CursoId,Instituicao,Nome,Ementa,CurriculoId")] CursoViewModel cursoViewModel)
        {
            if (ModelState.IsValid)
            {
                _cursoAppServicos.Atualizar(cursoViewModel);
                return RedirectToAction("Index");
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", cursoViewModel.CurriculoId);
            return View(cursoViewModel);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoViewModel cursoViewModel = _cursoAppServicos.ObterPorId(id.Value);
            if (cursoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cursoViewModel);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _cursoAppServicos.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cursoAppServicos.Dispose();
                _curriculoAppServicos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
