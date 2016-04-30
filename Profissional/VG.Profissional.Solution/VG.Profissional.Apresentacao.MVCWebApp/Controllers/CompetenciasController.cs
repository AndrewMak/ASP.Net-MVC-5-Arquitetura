using System;
using System.Net;
using System.Web.Mvc;
using VG.Profissional.Aplicacao.Interfaces;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Apresentacao.MVCWebApp.Controllers
{
    [Authorize]
    public class CompetenciasController : Controller
    {
        private readonly ICompetenciaAppServicos _competenciaAppServicos;
        private readonly ICurriculoAppServicos _curriculoAppServicos;

        public CompetenciasController(ICompetenciaAppServicos competenciaAppServicos, ICurriculoAppServicos curriculoAppServicos)
        {
            _competenciaAppServicos = competenciaAppServicos;
            _curriculoAppServicos = curriculoAppServicos;
        }

        // GET: Competencias
        public ActionResult Index()
        {
            return View(_competenciaAppServicos.ObterTodos());
        }

        // GET: Competencias/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetenciaViewModel competenciaViewModel = _competenciaAppServicos.ObterPorId(id.Value);
            if (competenciaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(competenciaViewModel);
        }

        // GET: Competencias/Create
        public ActionResult Create()
        {
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome");
            return View();
        }

        // POST: Competencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetenciaId,Nome,NivelMaturidade,AnosExperiencia,UltimaUtilizacao,CurriculoId")] CompetenciaViewModel competenciaViewModel)
        {
            if (ModelState.IsValid)
            {
                _competenciaAppServicos.Adicionar(competenciaViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", competenciaViewModel.CurriculoId);
            return View(competenciaViewModel);
        }

        // GET: Competencias/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetenciaViewModel competenciaViewModel = _competenciaAppServicos.ObterPorId(id.Value);
            if (competenciaViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", competenciaViewModel.CurriculoId);
            return View(competenciaViewModel);
        }

        // POST: Competencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetenciaId,Nome,NivelMaturidade,AnosExperiencia,UltimaUtilizacao,CurriculoId")] CompetenciaViewModel competenciaViewModel)
        {
            if (ModelState.IsValid)
            {
                _competenciaAppServicos.Atualizar(competenciaViewModel);
                return RedirectToAction("Index");
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", competenciaViewModel.CurriculoId);
            return View(competenciaViewModel);
        }

        // GET: Competencias/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetenciaViewModel competenciaViewModel = _competenciaAppServicos.ObterPorId(id.Value);
            if (competenciaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(competenciaViewModel);
        }

        // POST: Competencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _competenciaAppServicos.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _competenciaAppServicos.Dispose();
                _curriculoAppServicos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
