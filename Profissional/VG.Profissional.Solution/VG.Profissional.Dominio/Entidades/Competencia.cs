using System;

namespace VG.Profissional.Dominio.Entidades
{
    public class Competencia
    {
        public Competencia()
        {
            CompetenciaId = Guid.NewGuid();
        }

        public Guid CompetenciaId { get; set; }
        public string Nome { get; set; }
        public string NivelMaturidade { get; set; }
        public int AnosExperiencia { get; set; }
        public string UltimaUtilizacao { get; set; }
        public Guid CurriculoId { get; set; }
        public virtual Curriculo Curriculo { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}