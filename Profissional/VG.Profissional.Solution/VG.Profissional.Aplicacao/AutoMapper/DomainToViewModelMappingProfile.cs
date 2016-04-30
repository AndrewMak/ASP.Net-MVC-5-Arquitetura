using AutoMapper;
using VG.Profissional.Aplicacao.ViewModels;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Aplicacao.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Curriculo, CurriculoViewModel>();
            CreateMap<Curriculo, CurriculoCompletoViewModel>();
            CreateMap<Curriculo, CurriculoContatoViewModel>();
            CreateMap<Apresentacao, ApresentacaoViewModel>();
            CreateMap<Competencia, CompetenciaViewModel>();
            CreateMap<Contato, ContatoViewModel>();
            CreateMap<Contato, CurriculoContatoViewModel>();
            CreateMap<Curso, CursoViewModel>();
            CreateMap<Experiencia, ExperienciaViewModel>();
            CreateMap<Ferramenta, FerramentaViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
