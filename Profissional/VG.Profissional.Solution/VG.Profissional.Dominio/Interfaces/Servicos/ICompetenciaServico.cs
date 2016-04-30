using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Dominio.Interfaces.Servicos
{
    public interface ICompetenciaServico : IDisposable
    {
        Competencia Adicionar(Competencia competencia);
        Competencia Atualizar(Competencia competencia);
        void Remover(Guid id);
        Competencia ObterPorId(Guid id);
        IEnumerable<Competencia> ObterTodos();
    }
}
