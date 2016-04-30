using System;
using System.Collections.Generic;

namespace VG.Profissional.Dominio.Entidades
{
    public class Curriculo
    {
        public Curriculo()
        {
            CurriculoId = Guid.NewGuid();
            Apresentacoes = new List<Apresentacao>();
            Competencias = new List<Competencia>();
            Experiencias = new List<Experiencia>();
            Cursos = new List<Curso>();
            Ferramentas = new List<Ferramenta>();
        }

        public Guid CurriculoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Localizacao { get; set; }
        public virtual Contato Contato { get; set; }
        public virtual ICollection<Apresentacao> Apresentacoes { get; set; }
        public virtual ICollection<Competencia> Competencias { get; set; }
        public virtual ICollection<Experiencia> Experiencias { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Ferramenta> Ferramentas { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }

}
