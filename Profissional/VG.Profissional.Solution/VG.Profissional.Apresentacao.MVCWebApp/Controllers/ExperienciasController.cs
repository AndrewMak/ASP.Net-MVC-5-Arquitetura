using System;
using System.Net;
using System.Web.Mvc;
using VG.Profissional.Aplicacao.Interfaces;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Apresentacao.MVCWebApp.Controllers
{
    [Authorize]
    public class ExperienciasController : Controller
    {
        private readonly IExperienciaAppServicos _experienciaAppServicos;
        private readonly ICurriculoAppServicos _curriculoAppServicos;

        public ExperienciasController(IExperienciaAppServicos experienciaAppServicos, ICurriculoAppServicos curriculoAppServicos)
        {
            _experienciaAppServicos = experienciaAppServicos;
            _curriculoAppServicos = curriculoAppServicos;
        }

        // GET: Experiencias
        public ActionResult Index()
        {
            return View(_experienciaAppServicos.ObterTodos());
        }

        // GET: Experiencias/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienciaViewModel experienciaViewModel = _experienciaAppServicos.ObterPorId(id.Value);
            if (experienciaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(experienciaViewModel);
        }

        // GET: Experiencias/Create
        public ActionResult Create()
        {
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome");
            return View();
        }

        // POST: Experiencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExperienciaId,NomeEmpresa,Cargo,Anos,CurriculoId")] ExperienciaViewModel experienciaViewModel)
        {
            if (ModelState.IsValid)
            {
                _experienciaAppServicos.Adicionar(experienciaViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", experienciaViewModel.CurriculoId);
            return View(experienciaViewModel);
        }

        // GET: Experiencias/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienciaViewModel experienciaViewModel = _experienciaAppServicos.ObterPorId(id.Value);
            if (experienciaViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", experienciaViewModel.CurriculoId);
            return View(experienciaViewModel);
        }

        // POST: Experiencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExperienciaId,NomeEmpresa,Cargo,Anos,CurriculoId")] ExperienciaViewModel experienciaViewModel)
        {
            if (ModelState.IsValid)
            {
                _experienciaAppServicos.Atualizar(experienciaViewModel);
                return RedirectToAction("Index");
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", experienciaViewModel.CurriculoId);
            return View(experienciaViewModel);
        }

        // GET: Experiencias/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienciaViewModel experienciaViewModel = _experienciaAppServicos.ObterPorId(id.Value);
            if (experienciaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(experienciaViewModel);
        }

        // POST: Experiencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _experienciaAppServicos.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _experienciaAppServicos.Dispose();
                _curriculoAppServicos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
