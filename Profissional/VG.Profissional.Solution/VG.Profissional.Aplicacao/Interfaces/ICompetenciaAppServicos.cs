using System;
using System.Collections.Generic;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Aplicacao.Interfaces
{
    public interface ICompetenciaAppServicos  : IDisposable
    {
        CompetenciaViewModel Adicionar(CompetenciaViewModel competenciaViewModel);
        CompetenciaViewModel Atualizar(CompetenciaViewModel competenciaViewModel);
        void Remover(Guid id);
        CompetenciaViewModel ObterPorId(Guid id);
        IEnumerable<CompetenciaViewModel> ObterTodos();
    }
}
