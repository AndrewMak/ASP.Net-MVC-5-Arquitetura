using System;

namespace VG.Profissional.Dominio.Entidades
{
    public class Ferramenta
    {
        public Ferramenta()
        {
            FerramentaId = Guid.NewGuid();
        }

        public Guid FerramentaId { get; set; }
        public string Nome { get; set; }
        public Guid CurriculoId { get; set; }
        public virtual Curriculo Curriculo { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}