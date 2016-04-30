using System;
using System.Net;
using System.Web.Mvc;
using VG.Profissional.Aplicacao.Interfaces;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Apresentacao.MVCWebApp.Controllers
{
    [Authorize]
    public class ContatosController : Controller
    {
        private readonly IContatoAppServicos _contatoAppServicos;
        private readonly ICurriculoAppServicos _curriculoAppServicos;

        public ContatosController(IContatoAppServicos contatoAppServicos, ICurriculoAppServicos curriculoAppServicos)
        {
            _contatoAppServicos = contatoAppServicos;
            _curriculoAppServicos = curriculoAppServicos;
        }

        // GET: Contatos
        public ActionResult Index()
        {
            return View(_contatoAppServicos.ObterTodos());
        }

        // GET: Contatos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoViewModel contatoViewModel = _contatoAppServicos.ObterPorId(id.Value);
            if (contatoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contatoViewModel);
        }

        // GET: Contatos/Create
        public ActionResult Create()
        {
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome");
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContatoId,Telefone,Email,Facebook,LinkedIn,CurriculoId")] ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                contatoViewModel.ContatoId = Guid.NewGuid();
                _contatoAppServicos.Adicionar(contatoViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", contatoViewModel.CurriculoId);
            return View(contatoViewModel);
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoViewModel contatoViewModel = _contatoAppServicos.ObterPorId(id.Value);
            if (contatoViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", contatoViewModel.CurriculoId);
            return View(contatoViewModel);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContatoId,Telefone,Email,Facebook,LinkedIn,CurriculoId")] ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _contatoAppServicos.Atualizar(contatoViewModel);
                return RedirectToAction("Index");
            }
            ViewBag.CurriculoId = new SelectList(_curriculoAppServicos.ObterTodos(), "CurriculoId", "Nome", contatoViewModel.CurriculoId);
            return View(contatoViewModel);
        }

        // GET: Contatos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoViewModel contatoViewModel = _contatoAppServicos.ObterPorId(id.Value);
            if (contatoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contatoViewModel);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _contatoAppServicos.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contatoAppServicos.Dispose();
                _curriculoAppServicos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
