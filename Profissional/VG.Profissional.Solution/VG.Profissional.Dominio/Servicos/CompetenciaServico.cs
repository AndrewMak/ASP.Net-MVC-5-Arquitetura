using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Dominio.Interfaces.Servicos;

namespace VG.Profissional.Dominio.Servicos
{
    public class CompetenciaServico : ICompetenciaServico
    {
        private readonly ICompetenciaRepositorio _competenciaRepositorio;

        public CompetenciaServico(ICompetenciaRepositorio competenciaRepositorio)
        {
            _competenciaRepositorio = competenciaRepositorio;
        }

        public Competencia Adicionar(Competencia competencia)
        {
            //TODO: Executa as validacoes
            if (!competencia.IsValid())
                return competencia;

            return _competenciaRepositorio.Adicionar(competencia);
        }

        public Competencia Atualizar(Competencia competencia)
        {
            return _competenciaRepositorio.Atualizar(competencia);
        }

        public Competencia ObterPorId(Guid id)
        {
            return _competenciaRepositorio.ObterPorId(id);
        }

        public IEnumerable<Competencia> ObterTodos()
        {
            return _competenciaRepositorio.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _competenciaRepositorio.Remover(id);
        }

        public void Dispose()
        {
            _competenciaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
