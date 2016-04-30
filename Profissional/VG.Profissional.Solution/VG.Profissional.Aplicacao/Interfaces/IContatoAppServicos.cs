using System;
using System.Collections.Generic;
using VG.Profissional.Aplicacao.ViewModels;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Aplicacao.Interfaces
{
    public interface IContatoAppServicos : IDisposable
    {
        ContatoViewModel Adicionar(ContatoViewModel contatoViewModel);
        ContatoViewModel Atualizar(ContatoViewModel contatoViewModel);
        CurriculoContatoViewModel Atualizar(CurriculoContatoViewModel curriculoContatoViewModel);
        CurriculoContatoViewModel Adicionar(CurriculoContatoViewModel curriculoContatoViewModel);
        void Remover(Guid id);
        void RemoverPorCurriculoId(Guid id);
        ContatoViewModel ObterPorId(Guid id);
        IEnumerable<ContatoViewModel> ObterTodos();
        ContatoViewModel ObterPorCurriculo(Guid id);
        Contato ObterDominioPorCurriculo(Guid id);
    }
}
