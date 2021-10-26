using Hangfire;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
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
        private string retorno;

        public HangfireService(IDespachoBLL despachoBLL)
        {
            _despachoBLL = despachoBLL;
        }

        [Queue("Edocs")]
        public void BuscaRespostaDespachosAbertos()
        {
            try
            {
                retorno = "Executado em " + DateTime.Now.ToString();
                //Busca Despachos abertos
                Task<List<int>> task = _despachoBLL.ObterDespachosEmAberto();
                Task.WaitAll(task);

                List<int> despachos = task.Result;

                //busca a situação de cada despacho
                retorno += "\n Despachos encontrados:" + despachos.Count;
                foreach (var despacho in despachos)
                {
                    BackgroundJob.Enqueue(() => EncontraDestinatarioHangFire(despacho));
                    //teste
                    //BackgroundJob.Enqueue(() => EncontraDestinatarioHangFire(despacho, "89565801-9382-4785-94f8-cd35d4ab39d2", new[] { "43ccc355-87e9-4f14-8812-6469f8f0c81b", new Guid().ToString() }));
                }
            }
            catch (Exception e)
            {
                throw (new Exception(retorno + "\n" + e.StackTrace));
            }
        }

        public void EncontraDestinatarioHangFire(int idDespacho)
        {
            Task.WaitAll(_despachoBLL.ResponderDespacho(idDespacho));
        }

        //public void EncontraDestinatarioHangFire(int  idDespacho)
        //{
        //    try
        //    {
        //        //busca destinatario
        //        Task<DespachoManifestacaoModel>taskDespacho = _despachoBLL.ObterDespachoEDestinatario(idDespacho);
        //        Task.WaitAll(taskDespacho);
        //        DespachoManifestacaoModel despacho = taskDespacho.Result;

        //        //busca se o encaminhamento foi respondido pelo destinatario, retorna quem respondeu
        //        Task<EncaminhamentoRastreioDestinoModel> task = _edocsBLL.ResponsavelPorResponderAoDestinatario(despacho.IdEncaminhamento.ToString(), new[] { despacho.AgenteDestinatario.GuidUsuario });
        //        Task.WaitAll(task);

        //        EncaminhamentoRastreioDestinoModel responsavel = task.Result;
        //        if (responsavel != null)//encontrado
        //        {
        //            retorno += $"\n o responsavel{responsavel.Id} - {responsavel.Nome} respondeu pelo encaminhamento {despacho.IdEncaminhamento.ToString()}";
        //            //verificar se o despacho já foi respondido
        //            if (despacho.Situacao == nameof(Enums.SituacaoDespacho.Aberto)){
        //                retorno += $"\n o encaminhamento {despacho.IdEncaminhamento.ToString()} esta {despacho.Situacao}";
        //                Task<AgenteManifestacaoModel> taskAgente =  _despachoBLL.montaAgente(responsavel.Id, responsavel.TipoAgente);
        //                AgenteManifestacaoModel agenteResposta = taskAgente.Result;
        //                //salva quem respondeu e marca como respondido
        //                _despachoBLL.ResponderDespacho(despacho.IdDespachoManifestacao, agenteResposta);
        //                //Task taskResponderDespacho = _despachoBLL.AdicionarDespacho(despacho.IdDespachoManifestacao, agenteResposta);
        //                //Task.WaitAll(taskResponderDespacho);
        //                retorno += $"\n o Despacho {despacho.IdDespachoManifestacao} foi alterado";
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw (new Exception(retorno + "\n" + e.StackTrace));
        //    }
        //}
    }
}