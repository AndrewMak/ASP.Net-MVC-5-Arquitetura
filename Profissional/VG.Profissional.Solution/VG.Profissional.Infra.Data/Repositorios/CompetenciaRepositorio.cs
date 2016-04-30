using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Infra.Data.Context;

namespace VG.Profissional.Infra.Data.Repositorios
{
    public class CompetenciaRepositorio : Repositorio<Competencia>, ICompetenciaRepositorio
    {
        public CompetenciaRepositorio(ProfissionalContext context)
            :base(context)
        {

        }
    }
}
