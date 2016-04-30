using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Dominio.Interfaces.Servicos
{
    public interface ICurriculoServico : IDisposable
    {
        Curriculo Adicionar(Curriculo curriculo);
        Curriculo Atualizar(Curriculo curriculo);
        void Remover(Guid id);
        Curriculo ObterPorId(Guid id);
        IEnumerable<Curriculo> ObterTodos();
        Curriculo ObterCompleto(string nome);
    }
}
