using System;
using System.Collections.Generic;
using AutoMapper;
using VG.Profissional.Aplicacao.Interfaces;
using VG.Profissional.Aplicacao.ViewModels;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Infra.Data.Interfaces;
using VG.Profissional.Dominio.Interfaces.Servicos;

namespace VG.Profissional.Aplicacao.Servicos
{
    public class CursoAppServicos : AppService, ICursoAppServicos
    {
        private readonly ICursoServico _cursoServico;

        public CursoAppServicos(ICursoServico cursoServico, IUnitofWork uow)
            : base(uow)
        {
            _cursoServico = cursoServico;
        }

        public CursoViewModel Adicionar(CursoViewModel cursoViewModel)
        {
            var curso = Mapper.Map<CursoViewModel, Curso>(cursoViewModel);
            var cursoReturn = _cursoServico.Adicionar(curso);

            if (cursoReturn.IsValid())
                Commit();

            return cursoViewModel;
        }

        public CursoViewModel Atualizar(CursoViewModel cursoViewModel)
        {
            var curso = Mapper.Map<CursoViewModel, Curso>(cursoViewModel);
            var cursoReturn = _cursoServico.Atualizar(curso);

            if (cursoReturn.IsValid())
                Commit();

            return cursoViewModel;
        }

        public void Remover(Guid id)
        {
            _cursoServico.Remover(id);
            Commit();
        }

        public CursoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Curso, CursoViewModel>(_cursoServico.ObterPorId(id));
        }

        public IEnumerable<CursoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Curso>, IEnumerable<CursoViewModel>>(_cursoServico.ObterTodos());
        }

        public void Dispose()
        {
            _cursoServico.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
