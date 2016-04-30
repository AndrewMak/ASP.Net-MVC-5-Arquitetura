using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Dominio.Interfaces.Servicos;

namespace VG.Profissional.Dominio.Servicos
{
    public class CursoServico : ICursoServico
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public CursoServico(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public Curso Adicionar(Curso curso)
        {
            //TODO: Executa as validacoes
            if (!curso.IsValid())
                return curso;

            return _cursoRepositorio.Adicionar(curso);
        }

        public Curso Atualizar(Curso curso)
        {
            return _cursoRepositorio.Atualizar(curso);
        }
        
        public Curso ObterPorId(Guid id)
        {
            return _cursoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Curso> ObterTodos()
        {
            return _cursoRepositorio.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _cursoRepositorio.Remover(id);
        }

        public void Dispose()
        {
            _cursoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
