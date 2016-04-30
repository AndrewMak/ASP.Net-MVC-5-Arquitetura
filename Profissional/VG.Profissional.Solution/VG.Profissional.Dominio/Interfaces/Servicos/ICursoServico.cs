using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Dominio.Interfaces.Servicos
{
    public interface ICursoServico : IDisposable
    {
        Curso Adicionar(Curso curso);
        Curso Atualizar(Curso curso);
        void Remover(Guid id);
        Curso ObterPorId(Guid id);
        IEnumerable<Curso> ObterTodos();
    }
}
