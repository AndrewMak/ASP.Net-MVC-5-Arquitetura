using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Aplicacao.ViewModels
{
    public class ApresentacaoViewModel
    {
        public ApresentacaoViewModel()
        {
            ApresentacaoId = Guid.NewGuid();
        }

        [Key]
        public Guid ApresentacaoId { get; set; }

        [Required(ErrorMessage = "O campo texto não pode ficar vazio.")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "Selecione o Currículo.")]
        [DisplayName("Currículo")]
        public Guid CurriculoId { get; set; }
        public virtual CurriculoViewModel Curriculo { get; set; }
    }
}