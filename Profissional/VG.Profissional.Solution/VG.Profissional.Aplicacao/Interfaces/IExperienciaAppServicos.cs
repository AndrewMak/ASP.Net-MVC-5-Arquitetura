using System;
using System.Collections.Generic;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Aplicacao.Interfaces
{
    public interface IExperienciaAppServicos : IDisposable
    {
        ExperienciaViewModel Adicionar(ExperienciaViewModel experienciaViewModel);
        ExperienciaViewModel Atualizar(ExperienciaViewModel experienciaViewModel);
        void Remover(Guid id);
        ExperienciaViewModel ObterPorId(Guid id);
        IEnumerable<ExperienciaViewModel> ObterTodos();
    }
}
