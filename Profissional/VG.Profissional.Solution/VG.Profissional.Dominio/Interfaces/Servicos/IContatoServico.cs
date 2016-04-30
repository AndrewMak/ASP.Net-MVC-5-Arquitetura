using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Dominio.Interfaces.Servicos
{
    public interface IContatoServico : IDisposable
    {
        Contato Adicionar(Contato contato);
        Contato Atualizar(Contato contato);
        void Remover(Guid id);
        void RemoverPorCurriculoId(Guid id);
        Contato ObterPorId(Guid id);
        IEnumerable<Contato> ObterTodos();
        Contato ObterPorCurriculo(Guid id);
    }
}
