using System;
using System.Collections.Generic;
using AutoMapper;
using VG.Profissional.Aplicacao.Interfaces;
using VG.Profissional.Aplicacao.ViewModels;
using VG.Profissional.Dominio.Entidades;
using VG.Profissional.Infra.Data.Interfaces;
using VG.Profissional.Dominio.Interfaces.Servicos;

namespace VG.Profissional.Aplicacao.Servicos
{
    public class UsuarioAppServicos : AppService, IUsuarioAppServicos
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioAppServicos(IUsuarioServico usuarioServico, IUnitofWork uow)
            : base(uow)
        {
            _usuarioServico = usuarioServico;
        }

        public UsuarioViewModel ObterPorId(string id)
        {
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(_usuarioServico.ObterPorId(id));
            return usuarioViewModel;
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioServico.ObterTodos());
            return usuarioViewModel;
        }

        public void DesativarLock(string id)
        {
            _usuarioServico.ObterPorId(id).LockoutEnabled = false;
        }

        public void Dispose()
        {
            _usuarioServico.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
