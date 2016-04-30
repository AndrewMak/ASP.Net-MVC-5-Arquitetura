using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Dominio.Interfaces.Servicos
{
    public interface IExperienciaServico : IDisposable
    {
        Experiencia Adicionar(Experiencia experiencia);
        Experiencia Atualizar(Experiencia experiencia);
        void Remover(Guid id);
        Experiencia ObterPorId(Guid id);
        IEnumerable<Experiencia> ObterTodos();
    }
}
