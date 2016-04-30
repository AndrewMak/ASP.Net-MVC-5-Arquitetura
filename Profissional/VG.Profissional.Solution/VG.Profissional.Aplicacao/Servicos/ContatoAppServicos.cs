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
    public class ContatoAppServicos : AppService, IContatoAppServicos
    {
        private readonly IContatoServico _contatoServico;

        public ContatoAppServicos(IContatoServico contatoServico, IUnitofWork uow)
            : base(uow)
        {
            _contatoServico = contatoServico;
        }

        public ContatoViewModel Adicionar(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<ContatoViewModel, Contato>(contatoViewModel);
            var contatoReturn = _contatoServico.Adicionar(contato);

            if (contatoReturn.IsValid())
                Commit();

            return contatoViewModel;
        }

        public ContatoViewModel Atualizar(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<ContatoViewModel, Contato>(contatoViewModel);
            var contatoReturn = _contatoServico.Atualizar(contato);

            if (contatoReturn.IsValid())
                Commit();

            return contatoViewModel;
        }

        public CurriculoContatoViewModel Atualizar(CurriculoContatoViewModel curriculoContatoViewModel)
        {
            var contato = Mapper.Map<CurriculoContatoViewModel, Contato>(curriculoContatoViewModel);
            _contatoServico.Atualizar(contato);

            return curriculoContatoViewModel;
        }

        public CurriculoContatoViewModel Adicionar(CurriculoContatoViewModel curriculoContatoViewModel)
        {
            var contato = Mapper.Map<CurriculoContatoViewModel, Contato>(curriculoContatoViewModel);
            _contatoServico.Adicionar(contato);

            return curriculoContatoViewModel;
        }

        public void Remover(Guid id)
        {
            _contatoServico.Remover(id);
            Commit();
        }

        public void RemoverPorCurriculoId(Guid id)
        {
            _contatoServico.RemoverPorCurriculoId(id);
        }

        public ContatoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Contato, ContatoViewModel>(_contatoServico.ObterPorId(id));
        }

        public IEnumerable<ContatoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Contato>, IEnumerable<ContatoViewModel>>(_contatoServico.ObterTodos());
        }

        public ContatoViewModel ObterPorCurriculo(Guid id)
        {
            return Mapper.Map<Contato, ContatoViewModel>(_contatoServico.ObterPorCurriculo(id));
        }

        public Contato ObterDominioPorCurriculo(Guid id)
        {
            return _contatoServico.ObterPorCurriculo(id);
        }

        public void Dispose()
        {
            _contatoServico.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
