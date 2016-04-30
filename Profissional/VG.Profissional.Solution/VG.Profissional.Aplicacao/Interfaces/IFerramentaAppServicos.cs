using System;
using System.Collections.Generic;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Aplicacao.Interfaces
{
    public interface IFerramentaAppServicos : IDisposable
    {
        FerramentaViewModel Adicionar(FerramentaViewModel ferramentaViewModel);
        FerramentaViewModel Atualizar(FerramentaViewModel ferramentaViewModel);
        void Remover(Guid id);
        FerramentaViewModel ObterPorId(Guid id);
        IEnumerable<FerramentaViewModel> ObterTodos();
    }
}
