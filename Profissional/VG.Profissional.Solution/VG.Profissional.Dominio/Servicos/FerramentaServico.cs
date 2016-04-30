using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Dominio.Interfaces.Servicos;

namespace VG.Profissional.Dominio.Servicos
{
    public class FerramentaServico : IFerramentaServico
    {
        private readonly IFerramentaRepositorio _ferramentaRepositorio;

        public FerramentaServico(IFerramentaRepositorio ferramentaRepositorio)
        {
            _ferramentaRepositorio = ferramentaRepositorio;
        }

        public Ferramenta Adicionar(Ferramenta ferramenta)
        {
            //TODO: Executa as validacoes
            if (!ferramenta.IsValid())
                return ferramenta;

            return _ferramentaRepositorio.Adicionar(ferramenta);
        }

        public Ferramenta Atualizar(Ferramenta ferramenta)
        {
            return _ferramentaRepositorio.Atualizar(ferramenta);
        }

        public Ferramenta ObterPorId(Guid id)
        {
            return _ferramentaRepositorio.ObterPorId(id);
        }

        public IEnumerable<Ferramenta> ObterTodos()
        {
            return _ferramentaRepositorio.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _ferramentaRepositorio.Remover(id);
        }

        public void Dispose()
        {
            _ferramentaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
