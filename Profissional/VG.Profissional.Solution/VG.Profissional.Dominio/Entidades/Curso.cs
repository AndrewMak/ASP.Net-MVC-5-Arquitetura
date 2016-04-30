using System;

namespace VG.Profissional.Dominio.Entidades
{
    public class Curso
    {
        public Curso()
        {
            CursoId = Guid.NewGuid();
        }

        public Guid CursoId { get; set; }
        public string Instituicao { get; set; }
        public string Nome { get; set; }
        public string Ementa { get; set; }
        public Guid CurriculoId { get; set; }
        public virtual Curriculo Curriculo { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}