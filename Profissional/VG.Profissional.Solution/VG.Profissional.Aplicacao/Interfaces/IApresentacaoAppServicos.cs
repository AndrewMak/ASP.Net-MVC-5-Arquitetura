using System;
using System.Collections.Generic;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Aplicacao.Interfaces
{
    public interface IApresentacaoAppServicos : IDisposable
    {
        ApresentacaoViewModel Adicionar(ApresentacaoViewModel apresentacaoViewModel);
        ApresentacaoViewModel Atualizar(ApresentacaoViewModel apresentacaoViewModel);
        void Remover(Guid id);
        ApresentacaoViewModel ObterPorId(Guid id);
        IEnumerable<ApresentacaoViewModel> ObterTodos();
    }
}
