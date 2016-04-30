using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VG.Profissional.Aplicacao.ViewModels
{
    public class ExperienciaViewModel
    {
        public ExperienciaViewModel()
        {
            ExperienciaId = Guid.NewGuid();
        }

        [Key]
        public Guid ExperienciaId { get; set; }

        [Required(ErrorMessage = "O campo Nome Empresa não pode ficar vazio.")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [DisplayName("Nome Empresa")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "O campo Cargo não pode ficar vazio.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "O campo Anos não pode ficar vazio.")]
        public int Anos { get; set; }

        [Required(ErrorMessage = "Selecione o Currículo.")]
        [DisplayName("Currículo")]
        public Guid CurriculoId { get; set; }
        public virtual CurriculoViewModel Curriculo { get; set; }
    }
}