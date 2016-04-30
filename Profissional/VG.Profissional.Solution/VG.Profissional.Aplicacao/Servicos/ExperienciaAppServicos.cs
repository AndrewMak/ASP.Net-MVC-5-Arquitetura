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
    public class ExperienciaAppServicos : AppService, IExperienciaAppServicos
    {
        private readonly IExperienciaServico _experienciaServico;

        public ExperienciaAppServicos(IExperienciaServico experienciaServico, IUnitofWork uow)
            : base(uow)
        {
            _experienciaServico = experienciaServico;
        }

        public ExperienciaViewModel Adicionar(ExperienciaViewModel experienciaViewModel)
        {
            var experiencia = Mapper.Map<ExperienciaViewModel, Experiencia>(experienciaViewModel);
            var experienciaReturn = _experienciaServico.Adicionar(experiencia);

            if (experienciaReturn.IsValid())
                Commit();

            return experienciaViewModel;
        }

        public ExperienciaViewModel Atualizar(ExperienciaViewModel experienciaViewModel)
        {
            var experiencia = Mapper.Map<ExperienciaViewModel, Experiencia>(experienciaViewModel);
            var experienciaReturn = _experienciaServico.Atualizar(experiencia);

            if (experienciaReturn.IsValid())
                Commit();

            return experienciaViewModel;
        }

        public void Remover(Guid id)
        {
            _experienciaServico.Remover(id);
            Commit();
        }

        public ExperienciaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Experiencia, ExperienciaViewModel>(_experienciaServico.ObterPorId(id));
        }

        public IEnumerable<ExperienciaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Experiencia>, IEnumerable<ExperienciaViewModel>>(_experienciaServico.ObterTodos());
        }

        public void Dispose()
        {
            _experienciaServico.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
