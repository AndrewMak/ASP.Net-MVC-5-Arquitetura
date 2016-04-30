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
    public class CurriculoAppServicos : AppService, ICurriculoAppServicos
    {
        private readonly ICurriculoServico _curriculoServico;
        private readonly IContatoServico _contatoServico;

        public CurriculoAppServicos(ICurriculoServico curriculoServico, IContatoServico contatoServico, IUnitofWork uow)
            :base(uow)
        {
            _curriculoServico = curriculoServico;
            _contatoServico = contatoServico;
        }

        public CurriculoContatoViewModel Adicionar(CurriculoContatoViewModel curriculoViewModel)
        {
            var curriculo = Mapper.Map<CurriculoContatoViewModel, Curriculo>(curriculoViewModel);
            var contato = Mapper.Map<CurriculoContatoViewModel, Contato>(curriculoViewModel);

            var curriculoReturn = _curriculoServico.Adicionar(curriculo);

            if(curriculoReturn.IsValid())
            {
                var contatoReturn = _contatoServico.Adicionar(contato);

                if(contatoReturn.IsValid())
                {
                    Commit();
                }
            }

            return curriculoViewModel;
        }

        public CurriculoViewModel Atualizar(CurriculoViewModel curriculoViewModel)
        {
            var curriculo = Mapper.Map<CurriculoViewModel, Curriculo>(curriculoViewModel);

            var curriculoReturn = _curriculoServico.Atualizar(curriculo);

            if(curriculoReturn.IsValid())
            {
                Commit();
            }

            return curriculoViewModel;
        }

        public void Remover(Guid id)
        {
            _contatoServico.RemoverPorCurriculoId(id);
            _curriculoServico.Remover(id);
            Commit();
        }

        public CurriculoViewModel ObterPorId(Guid id)
        {
            var curriculo = _curriculoServico.ObterPorId(id);
            curriculo.Contato = _contatoServico.ObterPorCurriculo(id);

            return Mapper.Map<Curriculo, CurriculoViewModel>(curriculo); ;
        }

        public IEnumerable<CurriculoContatoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Curriculo>, IEnumerable<CurriculoContatoViewModel>>(_curriculoServico.ObterTodos());
        }

        public CurriculoViewModel ObterCompleto(string nome)
        {
            return Mapper.Map<Curriculo, CurriculoViewModel>(_curriculoServico.ObterCompleto(nome));
        }

        public void Dispose()
        {
            _curriculoServico.Dispose();
            _contatoServico.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
