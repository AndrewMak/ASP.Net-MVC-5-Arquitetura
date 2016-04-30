using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VG.Profissional.Aplicacao.ViewModels
{
    public class CurriculoContatoViewModel
    {
        public CurriculoContatoViewModel()
        {
            CurriculoId = Guid.NewGuid();
            //ContatoId = Guid.NewGuid();
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

        //CONTATO
        //[Key]
        //public Guid ContatoId { get; set; }

        [Required(ErrorMessage = "O campo Telefone não pode ficar vazio.")]
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

        public virtual ICollection<ApresentacaoViewModel> Apresentacoes { get; set; }

        public virtual ICollection<CompetenciaViewModel> Competencias { get; set; }

        public virtual ICollection<ExperienciaViewModel> Experiencias { get; set; }

        public virtual ICollection<CursoViewModel> Cursos { get; set; }

        public virtual ICollection<FerramentaViewModel> Ferramentas { get; set; }
    }
}
