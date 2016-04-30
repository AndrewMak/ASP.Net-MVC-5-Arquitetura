using System;
using System.ComponentModel.DataAnnotations;

namespace VG.Profissional.Aplicacao.ViewModels
{
    public class CurriculoCompletoViewModel
    {

        [Key]
        public int CurriculoId { get; set; }

        [Required(ErrorMessage = "Informe o seu nome.")]
        [MaxLength(40, ErrorMessage = "Máximo 40 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe a localização.")]
        [MaxLength(80, ErrorMessage = "Máximo 80 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Localizacao { get; set; }

        //Apresentacao

        [Key]
        public int ApresentacaoId { get; set; }

        [Required(ErrorMessage = "O campo texto não pode ficar vazio.")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Texto { get; set; }

    }
}
