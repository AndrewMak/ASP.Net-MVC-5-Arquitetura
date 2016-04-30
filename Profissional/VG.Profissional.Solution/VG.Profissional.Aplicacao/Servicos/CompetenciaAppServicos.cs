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
    public class CompetenciaAppServicos : AppService, ICompetenciaAppServicos
    {
        private readonly ICompetenciaServico _competenciaServico;

        public CompetenciaAppServicos(ICompetenciaServico competenciaServico, IUnitofWork uow)
            : base(uow)
        {
            _competenciaServico = competenciaServico;
        }

        public CompetenciaViewModel Adicionar(CompetenciaViewModel competenciaViewModel)
        {
            var competencia = Mapper.Map<CompetenciaViewModel, Competencia>(competenciaViewModel);
            var competenciaReturn = _competenciaServico.Adicionar(competencia);

            if (competenciaReturn.IsValid())
                Commit();

            return competenciaViewModel;
        }

        public CompetenciaViewModel Atualizar(CompetenciaViewModel competenciaViewModel)
        {
            var competencia = Mapper.Map<CompetenciaViewModel, Competencia>(competenciaViewModel);
            var competenciaReturn = _competenciaServico.Atualizar(competencia);

            if (competenciaReturn.IsValid())
                Commit();

            return competenciaViewModel;
        }

        public void Remover(Guid id)
        {
            _competenciaServico.Remover(id);
            Commit();
        }

        public CompetenciaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Competencia, CompetenciaViewModel>(_competenciaServico.ObterPorId(id));
        }

        public IEnumerable<CompetenciaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Competencia>, IEnumerable<CompetenciaViewModel>>(_competenciaServico.ObterTodos());
        }

        public void Dispose()
        {
            _competenciaServico.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
