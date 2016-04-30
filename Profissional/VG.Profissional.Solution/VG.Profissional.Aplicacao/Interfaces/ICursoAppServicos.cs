using System;
using System.Collections.Generic;
using VG.Profissional.Aplicacao.ViewModels;

namespace VG.Profissional.Aplicacao.Interfaces
{
    public interface ICursoAppServicos : IDisposable
    {
        CursoViewModel Adicionar(CursoViewModel cursoViewModel);
        CursoViewModel Atualizar(CursoViewModel cursoViewModel);
        void Remover(Guid id);
        CursoViewModel ObterPorId(Guid id);
        IEnumerable<CursoViewModel> ObterTodos();
    }
}
