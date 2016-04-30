using System;

namespace VG.Profissional.Dominio.Entidades
{
    public class Apresentacao
    {
        public Apresentacao()
        {
            ApresentacaoId = Guid.NewGuid();
        }

        public Guid ApresentacaoId { get; set; }
        public string Texto { get; set; }
        public Guid CurriculoId { get; set; }
        public virtual Curriculo Curriculo { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}