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
    public class ApresentacaoAppServicos : AppService, IApresentacaoAppServicos
    {
        private readonly IApresentacaoServico _apresentacaoServico;

        public ApresentacaoAppServicos(IApresentacaoServico apresentacaoServico, IUnitofWork uow)
            : base(uow)
        {
            _apresentacaoServico = apresentacaoServico;
        }

        public ApresentacaoViewModel Adicionar(ApresentacaoViewModel apresentacaoViewModel)
        {
            var apresentacao = Mapper.Map<ApresentacaoViewModel, Apresentacao>(apresentacaoViewModel);
            var apresentacaoReturn = _apresentacaoServico.Adicionar(apresentacao);

            if (apresentacaoReturn.IsValid())
                Commit();

            return apresentacaoViewModel;
        }

        public ApresentacaoViewModel Atualizar(ApresentacaoViewModel apresentacaoViewModel)
        {
            var apresentacao = Mapper.Map<ApresentacaoViewModel, Apresentacao>(apresentacaoViewModel);
            var apresentacaoReturn = _apresentacaoServico.Atualizar(apresentacao);

            if (apresentacaoReturn.IsValid())
                Commit();

            return apresentacaoViewModel;
        }

        public void Remover(Guid id)
        {
            _apresentacaoServico.Remover(id);
            Commit();
        }

        public ApresentacaoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Apresentacao, ApresentacaoViewModel>(_apresentacaoServico.ObterPorId(id));
        }

        public IEnumerable<ApresentacaoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Apresentacao>, IEnumerable<ApresentacaoViewModel>>(_apresentacaoServico.ObterTodos());
        }

        public void Dispose()
        {
            _apresentacaoServico.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
