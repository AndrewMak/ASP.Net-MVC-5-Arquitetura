using System;
using System.Collections.Generic;
using VG.Profissional.Aplicacao.ViewModels;
using VG.Profissional.Dominio.Entidades;

namespace VG.Profissional.Aplicacao.Interfaces
{
    public interface IUsuarioAppServicos : IDisposable
    {
        UsuarioViewModel ObterPorId(string id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        void DesativarLock(string id);
    }
}
