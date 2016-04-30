using AutoMapper;
using VG.Profissional.Aplicacao.ViewModels;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Aplicacao.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<CurriculoViewModel, Curriculo>();
            CreateMap<CurriculoCompletoViewModel, Curriculo>();
            CreateMap<CurriculoContatoViewModel, Curriculo>();
            CreateMap<ApresentacaoViewModel, Apresentacao>();
            CreateMap<CompetenciaViewModel, Competencia>();
            CreateMap<ContatoViewModel, Contato>();
            CreateMap<CurriculoContatoViewModel, Contato>();
            CreateMap<CursoViewModel, Curso>();
            CreateMap<ExperienciaViewModel, Experiencia>();
            CreateMap<FerramentaViewModel, Ferramenta>();
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
