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
    public class FerramentaAppServicos : AppService, IFerramentaAppServicos
    {
        private readonly IFerramentaServico _ferramentaServico;

        public FerramentaAppServicos(IFerramentaServico ferramentaServico, IUnitofWork uow)
            : base(uow)
        {
            _ferramentaServico = ferramentaServico;
        }

        public FerramentaViewModel Adicionar(FerramentaViewModel ferramentaViewModel)
        {
            var Ferramenta = Mapper.Map<FerramentaViewModel, Ferramenta>(ferramentaViewModel);
            var ferramentaReturn = _ferramentaServico.Adicionar(Ferramenta);

            if (ferramentaReturn.IsValid())
                Commit();

            return ferramentaViewModel;
        }

        public FerramentaViewModel Atualizar(FerramentaViewModel ferramentaViewModel)
        {
            var Ferramenta = Mapper.Map<FerramentaViewModel, Ferramenta>(ferramentaViewModel);
            var ferramentaReturn = _ferramentaServico.Atualizar(Ferramenta);

            if (ferramentaReturn.IsValid())
                Commit();

            return ferramentaViewModel;
        }

        public void Remover(Guid id)
        {
            _ferramentaServico.Remover(id);
            Commit();
        }

        public FerramentaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Ferramenta, FerramentaViewModel>(_ferramentaServico.ObterPorId(id));
        }

        public IEnumerable<FerramentaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Ferramenta>, IEnumerable<FerramentaViewModel>>(_ferramentaServico.ObterTodos());
        }

        public void Dispose()
        {
            _ferramentaServico.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
