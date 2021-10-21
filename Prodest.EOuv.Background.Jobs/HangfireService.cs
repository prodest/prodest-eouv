using Hangfire;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Model;
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
        private readonly IAcessoCidadaoBLL _AcessoCidadaoBLL;

        public HangfireService(IEDocsBLL edocsBLL, IDespachoBLL  despachoBLL, IAcessoCidadaoBLL acessoCidadaoBLL)
        {
            _edocsBLL = edocsBLL;
            _despachoBLL = despachoBLL;
            _AcessoCidadaoBLL = acessoCidadaoBLL;
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
                //BackgroundJob.Enqueue(() => EncontraDestinatarioHangFire(despacho ,despacho.IdEncaminhamento.ToString(),new[] { new Guid().ToString(), new Guid().ToString() }));
                //teste
                BackgroundJob.Enqueue(() => EncontraDestinatarioHangFire(despacho, "89565801-9382-4785-94f8-cd35d4ab39d2", new[] { "43ccc355-87e9-4f14-8812-6469f8f0c81b", new Guid().ToString() }));
                
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
                    Task<AgentePublicoPapelModel> taskPapel = _AcessoCidadaoBLL.GetPapel(new Guid(responsavel.Id));
                    Task.WaitAll(taskPapel);
                    AgentePublicoPapelModel encontrado = taskPapel.Result;                    
                    if (encontrado != null && !String.IsNullOrEmpty(encontrado.LotacaoGuid))
                    {
                        Task<SetorModel> taskSetor = _despachoBLL.BuscaSetor(encontrado.LotacaoGuid);
                        Task.WaitAll(taskSetor);
                        SetorModel setor = taskSetor.Result;
                    }
                    AgenteManifestacaoModel AgenteResposta = new AgenteManifestacaoModel
                    {
                        GuidPapel = new Guid(responsavel.Id),
                        //                NomePapel = responsavel.Nome,

                        //                        public int IdAgenteManifestacao { get; set; }
                        //public byte Tipo { get; set; }
                        //public string GuidUsuario { get; set; }
                        //public string NomeUsuario { get; set; }
                        //public Guid? GuidPapel { get; set; }
                        //public string NomePapel { get; set; }
                        //public Guid? GuidSetor { get; set; }
                        //public string NomeSetor { get; set; }
                        //public string SiglaSetor { get; set; }
                        //public Guid? GuidOrgao { get; set; }
                        //public string NomeOrgao { get; set; }
                        //public string SiglaOrgao { get; set; }
                        //public Guid? GuidPatriarca { get; set; }
                        //public string NomePatriarca { get; set; }
                        //public string SiglaPatriarca { get; set; }
                    };


                    _despachoBLL.ResponderDespacho(despacho.IdDespachoManifestacao, AgenteResposta /*atorResposta*/);
                }
            }
        }
    }
}