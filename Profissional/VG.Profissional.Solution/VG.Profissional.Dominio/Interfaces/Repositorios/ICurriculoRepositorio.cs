using System;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Dominio.Interfaces.Repositorios
{
    public interface ICurriculoRepositorio : IRepositorio<Curriculo>
    {
        Curriculo ObterCompleto(string nome);
    }
}
