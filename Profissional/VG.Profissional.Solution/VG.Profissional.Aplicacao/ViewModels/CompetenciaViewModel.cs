using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VG.Profissional.Aplicacao.ViewModels
{
    public class CompetenciaViewModel
    {
        public CompetenciaViewModel()
        {
            CompetenciaId = Guid.NewGuid();
        }

        [Key]
        public Guid CompetenciaId { get; set; }

        [Required(ErrorMessage = "O campo Nome não pode ficar vazio.")]
        [MaxLength(80, ErrorMessage = "Máximo 80 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Nível de Maturidade não pode ficar vazio.")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Nível de Maturidade")]
        public string NivelMaturidade { get; set; }

        [Required(ErrorMessage = "O campo Anos de Experiência não pode ficar vazio.")]
        [DisplayName("Anos de Experiência")]
        public int AnosExperiencia { get; set; }

        [Required(ErrorMessage = "O campo Última Utilização não pode ficar vazio.")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Última Utilização")]
        public string UltimaUtilizacao { get; set; }

        [Required(ErrorMessage = "Selecione o Currículo.")]
        [DisplayName("Currículo")]
        public Guid CurriculoId { get; set; }
        public virtual CurriculoViewModel Curriculo { get; set; }
    }
}