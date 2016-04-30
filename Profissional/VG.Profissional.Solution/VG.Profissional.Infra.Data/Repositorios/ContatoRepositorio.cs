using System;
using System.Linq;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Dominio.Interfaces.Repositorios;
using VG.Profissional.Infra.Data.Context;

namespace VG.Profissional.Infra.Data.Repositorios
{
    public class ContatoRepositorio : Repositorio<Contato>, IContatoRepositorio
    {
        public ContatoRepositorio(ProfissionalContext context)
            :base(context)
        {

        }

        public void RemoverPorCurriculoId(Guid id)
        {
            DbSet.Remove(DbSet.FirstOrDefault(c => c.CurriculoId == id));
            SaveChanges();
        }

        public Contato ObterPorCurriculoId(Guid id)
        {
            return Db.Contatos.Where(c => c.CurriculoId == id).FirstOrDefault();
        }
    }
}
