using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VG.Profissional.Aplicacao.ViewModels
{
    public class CurriculoViewModel
    {
        public CurriculoViewModel()
        {
            CurriculoId = Guid.NewGuid();
        }

        [Key]
        public Guid CurriculoId { get; set; }

        [Required(ErrorMessage = "Informe o seu nome.")]
        [MaxLength(40, ErrorMessage = "Máximo 40 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe a localização.")]
        [MaxLength(80, ErrorMessage = "Máximo 80 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Localização")]
        public string Localizacao { get; set; }

        public virtual ContatoViewModel Contato { get; set; }

        public virtual ICollection<ApresentacaoViewModel> Apresentacoes { get; set; }

        public virtual ICollection<CompetenciaViewModel> Competencias { get; set; }

        public virtual ICollection<ExperienciaViewModel> Experiencias { get; set; }

        public virtual ICollection<CursoViewModel> Cursos { get; set; }

        public virtual ICollection<FerramentaViewModel> Ferramentas { get; set; }
    }
}