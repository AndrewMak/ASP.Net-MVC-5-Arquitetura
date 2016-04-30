using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Dominio.Interfaces.Servicos;

namespace VG.Profissional.Dominio.Servicos
{
    public class ContatoServico : IContatoServico
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoServico(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public Contato Adicionar(Contato contato)
        {
            //TODO: Executa as validacoes
            if (!contato.IsValid())
                return contato;

            return _contatoRepositorio.Adicionar(contato);
        }

        public Contato Atualizar(Contato contato)
        {
            return _contatoRepositorio.Atualizar(contato);
        }
        
        public Contato ObterPorCurriculo(Guid id)
        {
            return _contatoRepositorio.ObterPorCurriculoId(id);
        }

        public Contato ObterPorId(Guid id)
        {
            return _contatoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Contato> ObterTodos()
        {
            return _contatoRepositorio.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _contatoRepositorio.Remover(id);
        }

        public void RemoverPorCurriculoId(Guid id)
        {
            _contatoRepositorio.RemoverPorCurriculoId(id);
        }

        public void Dispose()
        {
            _contatoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
