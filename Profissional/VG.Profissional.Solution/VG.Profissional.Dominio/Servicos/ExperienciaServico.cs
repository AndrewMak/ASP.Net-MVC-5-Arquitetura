using System;
using System.Collections.Generic;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Dominio.Interfaces.Servicos;

namespace VG.Profissional.Dominio.Servicos
{
    public class ExperienciaServico : IExperienciaServico
    {
        private readonly IExperienciaRepositorio _experienciaRepositorio;

        public ExperienciaServico(IExperienciaRepositorio experienciaRepositorio)
        {
            _experienciaRepositorio = experienciaRepositorio;
        }

        public Experiencia Adicionar(Experiencia experiencia)
        {
            //TODO: Executa as validacoes
            if (!experiencia.IsValid())
                return experiencia;

            return _experienciaRepositorio.Adicionar(experiencia);
        }

        public Experiencia Atualizar(Experiencia experiencia)
        {
            return _experienciaRepositorio.Atualizar(experiencia);
        }

        public Experiencia ObterPorId(Guid id)
        {
            return _experienciaRepositorio.ObterPorId(id);
        }

        public IEnumerable<Experiencia> ObterTodos()
        {
            return _experienciaRepositorio.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _experienciaRepositorio.Remover(id);
        }

        public void Dispose()
        {
            _experienciaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
