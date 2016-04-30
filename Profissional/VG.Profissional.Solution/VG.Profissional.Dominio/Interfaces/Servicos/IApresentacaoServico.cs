using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Dominio.Interfaces.Servicos
{
    public interface IApresentacaoServico : IDisposable
    {
        Apresentacao Adicionar(Apresentacao apresentacao);
        Apresentacao Atualizar(Apresentacao apresentacao);
        void Remover(Guid id);
        Apresentacao ObterPorId(Guid id);
        IEnumerable<Apresentacao> ObterTodos();
    }
}
