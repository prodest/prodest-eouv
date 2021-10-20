using Prodest.EOuv.Dominio.Modelo;

namespace Prodest.EOuv.Background.Jobs
{
    public interface IHangfireService
    {
        void BuscaRespostaDespachosAbertos();
    }

    public class HangfireService : IHangfireService
    {
        private readonly IEDocsBLL _edocsBLL;

        public HangfireService(IEDocsBLL edocsBLL)
        {
            _edocsBLL = edocsBLL;
        }

        public void BuscaRespostaDespachosAbertos()
        {
            var teste = 1;
        }

        //public void EncontraDestinatarioHangFire()
        //{
        //    System.Threading.Tasks.Task<bool> task = _edocsBLL.EncontraDestinatario("89565801-9382-4785-94f8-cd35d4ab39d2", new[] { "43ccc355-87e9-4f14-8812-6469f8f0c81b", new Guid().ToString(), new Guid().ToString() });// Encaminhamento, grupo
        //    //System.Threading.Tasks.Task<bool> task = _edocsBLL.EncontraDestinatario("89565801-9382-4785-94f8-cd35d4ab39d2", new[]{ new Guid().ToString(), new Guid().ToString()});// Encaminhamento, grupo

        //    Task.WaitAll(task);

        //    bool encontrado = task.Result;
        //}
    }
}