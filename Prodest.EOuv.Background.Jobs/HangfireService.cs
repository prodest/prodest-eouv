using Hangfire;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Shared.Util;
using Prodest.EOuv.UI.Apresentacao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Background.Jobs
{
    public interface IHangfireService
    {
        void BuscaRespostaDespachosAbertos();
    }

    public class HangfireService : IHangfireService
    {

        private readonly IDespachoBLL _despachoBLL;
        private readonly IEDocsBLL _edocsBLL;

        public HangfireService(IEDocsBLL edocsBLL, IDespachoBLL  despachoBLL)
        {
            _edocsBLL = edocsBLL;
            _despachoBLL = despachoBLL;
        }
        [Queue("Edocs")]
        public void BuscaRespostaDespachosAbertos()
        {

            //Busca Despachos abertos
            Task<List<DespachoManifestacaoModel>> task =  _despachoBLL.ObterDespachosEmAberto();
            Task.WaitAll(task);

            List<DespachoManifestacaoModel> despachos = task.Result;

            //busca a situação de cada despacho
            foreach (var despacho in despachos)
            {
                BackgroundJob.Enqueue(() => EncontraDestinatarioHangFire(despacho ,despacho.IdEncaminhamento.ToString(),new[] { new Guid().ToString(), new Guid().ToString() }));
            }
        }

        public void EncontraDestinatarioHangFire(DespachoManifestacaoModel despacho, string idEncaminhamentoRaiz, string[] idDestinatario)
        {
            Task<EncaminhamentoRastreioDestinoModel> task = _edocsBLL.ResponsavelPorResponderAoDestinatario(idEncaminhamentoRaiz, idDestinatario);// Encaminhamento, grupo
            //System.Threading.Tasks.Task<bool> task = _edocsBLL.EncontraDestinatario("89565801-9382-4785-94f8-cd35d4ab39d2", new[]{ new Guid().ToString(), new Guid().ToString()});// Encaminhamento, grupo
            Task.WaitAll(task);

            EncaminhamentoRastreioDestinoModel responsavel = task.Result;
            if (responsavel != null)//encontrado
            {
                //verificar se o despacho já foi respondido
                if (despacho.Situacao == nameof(Enums.SituacaoDespacho.Aberto)){
                    //marca como respondido, salva quem respondeu
                    _despachoBLL.ResponderDespacho(despacho.IdDespachoManifestacao, responsavel /*atorResposta*/);
                }
            }
        }
    }
}