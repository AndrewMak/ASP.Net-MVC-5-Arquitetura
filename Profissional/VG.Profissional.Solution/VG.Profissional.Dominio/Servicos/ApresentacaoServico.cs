using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Dominio.Interfaces.Servicos;

namespace VG.Profissional.Dominio.Servicos
{
    public class ApresentacaoServico : IApresentacaoServico
    {
        private readonly IApresentacaoRepositorio _apresentacaoRepositorio;

        public ApresentacaoServico(IApresentacaoRepositorio apresentacaoRepositorio)
        {
            _apresentacaoRepositorio = apresentacaoRepositorio;
        }

        public Apresentacao Adicionar(Apresentacao apresentacao)
        {
            //TODO: Executa as validacoes
            if (!apresentacao.IsValid())
                return apresentacao;

            return _apresentacaoRepositorio.Adicionar(apresentacao);
        }

        public Apresentacao Atualizar(Apresentacao apresentacao)
        {
            return _apresentacaoRepositorio.Atualizar(apresentacao);
        }

        public Apresentacao ObterPorId(Guid id)
        {
            return _apresentacaoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Apresentacao> ObterTodos()
        {
            return _apresentacaoRepositorio.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _apresentacaoRepositorio.Remover(id);
        }

        public void Dispose()
        {
            _apresentacaoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
