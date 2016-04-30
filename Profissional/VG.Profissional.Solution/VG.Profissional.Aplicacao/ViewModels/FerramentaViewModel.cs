using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VG.Profissional.Aplicacao.ViewModels
{
    public class FerramentaViewModel
    {
        public FerramentaViewModel()
        {
            FerramentaId = Guid.NewGuid();
        }

        [Key]
        public Guid FerramentaId { get; set; }

        [Required(ErrorMessage = "O campo Nome não pode ficar vazio.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione o Currículo.")]
        [DisplayName("Currículo")]
        public Guid CurriculoId { get; set; }
        public virtual CurriculoViewModel Curriculo { get; set; }
    }
}