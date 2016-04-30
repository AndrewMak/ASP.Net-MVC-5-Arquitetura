using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Infra.Data.Context;

namespace VG.Profissional.Infra.Data.Repositorios
{
    public class CurriculoRepositorio : Repositorio<Curriculo>, ICurriculoRepositorio
    {
        public CurriculoRepositorio(ProfissionalContext context)
            :base(context)
        {

        }

        public Curriculo ObterCompleto(string nome)
        {
            var conn = Db.Database.Connection;
            var query = @"select * " +
                        "from Curriculos c " +
                        "inner join Apresentacoes a " +
                        "on c.CurriculoId = a.CurriculoId " +
                        "inner join Experiencias e " +
                        "on c.CurriculoId = e.CurriculoId " +
                        "inner join Competencias co " +
                        "on c.CurriculoId = co.CurriculoId " +
                        "inner join Cursos cur " +
                        "on c.CurriculoId = cur.CurriculoId " +
                        "inner join Ferramentas f " +
                        "on c.CurriculoId = f.CurriculoId " +
                        "inner join Contatos cont " +
                        "on c.CurriculoId = co.CurriculoId " +
                        "where c.Nome = @snome ";

            var lookup = new Dictionary<Guid, Curriculo>();
            var listaApresentacao = new List<Guid>();
            var listaExperiencia = new List<Guid>();
            var listaCompetencia = new List<Guid>();
            var listaCurso = new List<Guid>();
            var listaFerramenta = new List<Guid>();
            var curriculoCompleto = conn.Query<Curriculo, Apresentacao, Experiencia, Competencia, Curso, Ferramenta, Contato, Curriculo>(query,
                (c, a, e, co, cur, f, cont) =>
                {
                    Curriculo curriculo;

                    //Reutilizando a instancia anterior de Curriculo
                    if (!lookup.TryGetValue(c.CurriculoId, out curriculo))
                        lookup.Add(c.CurriculoId, curriculo = c);

                    //Tratamento para não duplicar linhas
                    if (!listaApresentacao.Contains(a.ApresentacaoId))
                    {
                        listaApresentacao.Add(a.ApresentacaoId);
                        curriculo.Apresentacoes.Add(a);
                    }

                    if (!listaExperiencia.Contains(e.ExperienciaId))
                    {
                        listaExperiencia.Add(e.ExperienciaId);
                        curriculo.Experiencias.Add(e);
                    }

                    if (!listaCompetencia.Contains(co.CompetenciaId))
                    {
                        listaCompetencia.Add(co.CompetenciaId);
                        curriculo.Competencias.Add(co);
                    }

                    if (!listaCurso.Contains(cur.CursoId))
                    {
                        listaCurso.Add(cur.CursoId);
                        curriculo.Cursos.Add(cur);
                    }

                    if (!listaFerramenta.Contains(f.FerramentaId))
                    {
                        listaFerramenta.Add(f.FerramentaId);
                        curriculo.Ferramentas.Add(f);
                    }

                    curriculo.Contato = cont;

                    return curriculo;
                }, new {snome = nome}, splitOn: "CurriculoId, ApresentacaoId, ExperienciaId, CompetenciaId, CursoId, FerramentaId, ContatoId");

            return curriculoCompleto.FirstOrDefault();
        }
    }
}
