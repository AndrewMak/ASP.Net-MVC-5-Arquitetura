using System;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Dominio.Interfaces.Repositorios
{
    public interface IContatoRepositorio : IRepositorio<Contato>
    {
        void RemoverPorCurriculoId(Guid id);
        Contato ObterPorCurriculoId(Guid id);
    }
}
