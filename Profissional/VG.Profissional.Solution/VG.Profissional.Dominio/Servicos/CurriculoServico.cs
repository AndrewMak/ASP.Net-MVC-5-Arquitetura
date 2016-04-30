using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Dominio.Interfaces.Servicos;

namespace VG.Profissional.Dominio.Servicos
{
    public class CurriculoServico : ICurriculoServico
    {
        private readonly ICurriculoRepositorio _curriculoRepositorio;

        public CurriculoServico(ICurriculoRepositorio curriculoRepositorio)
        {
            _curriculoRepositorio = curriculoRepositorio;
        }

        public Curriculo Adicionar(Curriculo curriculo)
        {
            //TODO: Executa as validacoes
            if (!curriculo.IsValid())
                return curriculo;

            //TODO: Padrão Specification para validar as regras

            return _curriculoRepositorio.Adicionar(curriculo);
        }

        public Curriculo Atualizar(Curriculo curriculo)
        {
            return _curriculoRepositorio.Atualizar(curriculo);
        }

        public void Remover(Guid id)
        {
            _curriculoRepositorio.Remover(id);
        }

        public Curriculo ObterPorId(Guid id)
        {
            return _curriculoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Curriculo> ObterTodos()
        {
            return _curriculoRepositorio.ObterTodos();
        }

        public Curriculo ObterCompleto(string nome)
        {
            return _curriculoRepositorio.ObterCompleto(nome);
        }

        public void Dispose()
        {
            _curriculoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
