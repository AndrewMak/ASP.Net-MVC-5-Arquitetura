using System;

namespace VG.Profissional.Dominio.Entidades
{
    public class Contato
    {
        public Contato()
        {
            ContatoId = Guid.NewGuid();
        }

        public Guid ContatoId { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public Guid CurriculoId { get; set; }
        public virtual Curriculo Curriculo { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}