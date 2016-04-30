using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VG.Profissional.Aplicacao.ViewModels
{
    public class CursoViewModel
    {
        public CursoViewModel()
        {
            CursoId = Guid.NewGuid();
        }

        [Key]
        public Guid CursoId { get; set; }

        [Required(ErrorMessage = "O campo Instituição não pode ficar vazio.")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [DisplayName("Instituição")]
        public string Instituicao { get; set; }

        [Required(ErrorMessage = "O campo Nome não pode ficar vazio.")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [MaxLength(4000, ErrorMessage = "Máximo 1500 caracteres")]
        [MinLength(50, ErrorMessage = "Mínimo 50 caracteres")]
        public string Ementa { get; set; }

        [Required(ErrorMessage = "Selecione o Currículo.")]
        [DisplayName("Currículo")]
        public Guid CurriculoId { get; set; }
        public virtual CurriculoViewModel Curriculo { get; set; }
    }
}