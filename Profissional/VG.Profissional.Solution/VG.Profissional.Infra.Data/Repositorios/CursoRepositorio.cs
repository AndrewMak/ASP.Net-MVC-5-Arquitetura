using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Infra.Data.Context;

namespace VG.Profissional.Infra.Data.Repositorios
{
    public class CursoRepositorio : Repositorio<Curso>, ICursoRepositorio
    {
        public CursoRepositorio(ProfissionalContext context)
            :base(context)
        {

        }
    }
}
