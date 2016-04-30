using VG.Profissional.Infra.Data.Interfaces;

namespace VG.Profissional.Aplicacao.Servicos
{
    public class AppService
    {
        public readonly IUnitofWork _uow;

        public AppService(IUnitofWork uow)
        {
            _uow = uow;
        }

        public void Commit()
        {
            _uow.Commit();
        }

    }
}
