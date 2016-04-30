using System;

namespace VG.Profissional.Dominio.Entidades
{
    public class Experiencia
    {
        public Experiencia()
        {
            ExperienciaId = Guid.NewGuid();
        }

        public Guid ExperienciaId { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cargo { get; set; }
        public int Anos { get; set; }
        public Guid CurriculoId { get; set; }
        public virtual Curriculo Curriculo { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}