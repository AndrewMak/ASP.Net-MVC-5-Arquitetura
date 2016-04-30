using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Aplicacao.ViewModels
{
    public class ContatoViewModel
    {
        public ContatoViewModel()
        {
            ContatoId = Guid.NewGuid();
        }
        
        [Key]
        public Guid ContatoId { get; set; }

        [Required(ErrorMessage = "O campo telefone não pode ficar vazio.")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo 8 caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo E-mail não pode ficar vazio.")]
        [MaxLength(80, ErrorMessage = "Máximo 80 caracteres")]
        [MinLength(9, ErrorMessage = "Mínimo 9 caracteres")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        public string Facebook { get; set; }

        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        public string LinkedIn { get; set; }

        //[Required(ErrorMessage = "Selecione o Currículo.")]
        //[DisplayName("Currículo")]
        [ScaffoldColumn(false)]
        public Guid CurriculoId { get; set; }
        //public virtual CurriculoViewModel Curriculo { get; set; }
    }
}