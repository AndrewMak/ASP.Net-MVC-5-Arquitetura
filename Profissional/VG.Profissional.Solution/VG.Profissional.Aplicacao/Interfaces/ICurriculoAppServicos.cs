using System;
using System.Collections.Generic;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Aplicacao.Interfaces
{
    public interface ICurriculoAppServicos : IDisposable
    {
        CurriculoContatoViewModel Adicionar(CurriculoContatoViewModel curriculoViewModel);
        CurriculoViewModel Atualizar(CurriculoViewModel curriculoContatoViewModel);
        void Remover(Guid id);
        CurriculoViewModel ObterPorId(Guid id);
        IEnumerable<CurriculoContatoViewModel> ObterTodos();
        CurriculoViewModel ObterCompleto(string nome);
    }
}
