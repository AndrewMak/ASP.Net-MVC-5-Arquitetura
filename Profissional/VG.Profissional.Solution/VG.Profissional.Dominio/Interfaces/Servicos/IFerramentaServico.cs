using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Dominio.Interfaces.Servicos
{
    public interface IFerramentaServico : IDisposable
    {
        Ferramenta Adicionar(Ferramenta ferramenta);
        Ferramenta Atualizar(Ferramenta ferramenta);
        void Remover(Guid id);
        Ferramenta ObterPorId(Guid id);
        IEnumerable<Ferramenta> ObterTodos();
    }
}
