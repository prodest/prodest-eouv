using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Model.Edocs;
using Prodest.EOuv.Shared.Util;
using Prodest.EOuv.Shared.Utils.Exceptions;

namespace Prodest.EOuv.Infra.Service
{
   
    public class EDocsService : IEDocsService
    {
        private readonly string _baseUrl;
        private readonly int _cacheExpirationHours;
        private readonly IMemoryCache _memoryCache;
        private readonly IApiContext _apiContext;

        public EDocsService(
            IConfiguration configuration,
            IMemoryCache memoryCache,
            IApiContext apiContext
        )
        {
            _baseUrl = configuration.GetValue<string>("ApiUrls:EDocs");
            _cacheExpirationHours = configuration.GetValue<int>("CacheExpirationHours:ApiEDocs");
            _memoryCache = memoryCache;
            _apiContext = apiContext;
        }

        // =========================
        // public methods
        // =========================

        public async Task<GerarUrlModel> GetGerarUrl(int dataLength)
        {
            return await GetRequest<GerarUrlModel>($"{_baseUrl}/v2/documentos/upload-arquivo/gerar-url/{dataLength}");
        }

        public async Task<EventoModel> GetEvento(string id)
        {
            return await GetRequest<EventoModel>($"{_baseUrl}/v2/eventos/{id}");
        }

        public async Task<string> GetEncaminhamentoProtocolo(string idEncaminhamento)
        {
            return await GetRequest<string>($"{_baseUrl}/v2/encaminhamento/{idEncaminhamento}/inicial/protocolo");
        }

        public async Task<List<PatriarcaModel>> GetPatriarca()
        {
            return await GetRequest<List<PatriarcaModel>>($"{_baseUrl}/v2/agente/patriarcas");
        }

        public async Task<List<PatriarcaModel>> GetOrganizacoes(string idPatriarca)
        {
            return await GetRequest<List<PatriarcaModel>>($"{_baseUrl}​/v2/agente/{idPatriarca}/organizacoes");
        }

        public async Task<List<PatriarcaSetorModel>> GetSetores(string idOrgao)
        {
            return await GetRequest<List<PatriarcaSetorModel>>($"{_baseUrl}​/v2/agente/{idOrgao}/setores");
        }

        public async Task<List<PatriarcaSetorModel>> GetGrupoTrabalho(string idOrgao)
        {
            return await GetRequest<List<PatriarcaSetorModel>>($"{_baseUrl}​/v2/agente/{idOrgao}/grupos-trabalho");
        }

        public async Task<List<PatriarcaSetorModel>> GetComissoes(string idOrgao)
        {
            return await GetRequest<List<PatriarcaSetorModel>>($"{_baseUrl}​/v2/agente/{idOrgao}/comissoes");
        }

        public async Task<List<PapelModel>> GetPapeis()
        {
            return await GetRequest<List<PapelModel>>($"{_baseUrl}/v2/usuario/papeis");
        }

        public async Task<List<PapelModel>> GetRastreio()
        {
            return await GetRequest<List<PapelModel>>($"{_baseUrl}/v2/usuario/papeis");
        }


        public async Task<DocumentoModel> GetDocumento(string id)
        {
            return await GetRequest<DocumentoModel>($"{_baseUrl}/v2/documentos/{id}");
        }

        public async Task<EncaminhamentoModel> GetEncaminhamento(string id)
        {
            //return await GetRequest<EncaminhamentoModel>($"{_baseUrl}/v2/encaminhamento/{id}");
            return await GetRequest<EncaminhamentoModel>($"{_baseUrl}/encaminhamentos/{id}");
        }

        public async Task<string> GetDocumentoDownloadUrl(string id)
        {
            return await GetRequest<string>($"{_baseUrl}/v2/documentos/{id}/url-para-download-arquivo");
        }

        public async Task<PapelModel[]> GetUsuarioPapeisEncaminhamento(string id)
        {
            return await GetRequest<PapelModel[]>($"{_baseUrl}/v2/usuario/papeis/encaminhamento/{id}");
        }

        public async Task<PlanoModel[]> GetPlanosAtivos(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetPlanosAtivos)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<PlanoModel[]>($"{_baseUrl}/v2/classificacao-documental/{id}/planos-ativos");
            });
        }

        public async Task<ClasseModel[]> GetClassesAtivas(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetClassesAtivas)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<ClasseModel[]>($"{_baseUrl}/v2/classificacao-documental/{id}/classes-ativas");
            });
        }

        public async Task<FundamentoLegalModel[]> GetFundamentosLegais(string id)
        {
            return await _memoryCache.GetOrCreateAsync($"{nameof(GetFundamentosLegais)}::{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_cacheExpirationHours);
                return await GetRequest<FundamentoLegalModel[]>($"{_baseUrl}/v2/fundamentos-legais/{id}");
            });
        }

        public async Task<string> GetDocumentoFaseAssinaturaAssinar(string id)
        {
            return await GetRequest<string>($"{_baseUrl}/v2/documentos/fase-assinatura/assinar/{id}");
        }

        public async Task<string> PostProcessoAutuar(ProcessoAutuarRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/processos/autuar", parameters);
        }

        public async Task<string> PostProcessoDespachar(ProcessoDespacharRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/processos/despachar", parameters);
        }

        public async Task<string> PostProcessoEntranhar(ProcessoEntranharRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/processos/entranhar", parameters);
        }

        public async Task<string> PostProcessoDesentranhar(ProcessoDesentranharRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/processos/desentranhar", parameters);
        }

        public async Task<string> PostProcessoEncerrar(ProcessoEncerrarRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/processos/encerrar", parameters);
        }

        public async Task<string> PostEncaminhamentoNovo(EncaminhamentoRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/encaminhamento/novo", parameters);
        }

        public async Task<string> PostEncaminhamentoReencaminhar(EncaminhamentoRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/encaminhamento/reencaminhar", parameters);
        }

        public async Task<string> PostDocumentoCapturarNatoDigitalIcpBrasilServidor(DocumentoRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/documentos/capturar/nato-digital/icp-brasil/servidor", parameters);
        }

        public async Task<string> PostDocumentoCapturarNatoDigitalIcpBrasilCidadao(DocumentoRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/documentos/capturar/nato-digital/icp-brasil/cidadao", parameters);
        }

        public async Task<string> PostDocumentoCapturarNatoDigitalCopiaServidor(DocumentoRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/documentos/capturar/nato-digital/copia/servidor", parameters);
        }

        public async Task<string> PostDocumentoCapturarNatoDigitalCopiaCidadao(DocumentoRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/documentos/capturar/nato-digital/copia/cidadao", parameters);
        }

        public async Task<string> PostDocumentoCapturarNatoDigitalAutoAssinadoServidor(DocumentoRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/documentos/capturar/nato-digital/auto-assinado/servidor", parameters);
        }

        public async Task<string> PostDocumentoCapturarNatoDigitalAutoAssinadoCidadao(DocumentoRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/documentos/capturar/nato-digital/auto-assinado/cidadao", parameters);
        }

        public async Task<string> PostDocumentoCapturarDigitalizadoServidor(DocumentoRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/documentos/capturar/digitalizado/servidor", parameters);
        }

        public async Task<string> PostDocumentoCapturarDigitalizadoCidadao(DocumentoRequestModel parameters)
        {
            return await PostRequest<string>($"{_baseUrl}/v2/documentos/capturar/digitalizado/cidadao", parameters);
        }

        public async Task<AssinaturaDigitalValidaModel> PostAssinaturaDigitalValida(AssinaturaDigitalValidaModel parameters)
        {
            return await PostRequest<AssinaturaDigitalValidaModel>($"{_baseUrl}/v2/documentos/assinatura-digital-valida", parameters);
        }

        public async Task<string> PostTempUrlMinio(GerarUrlModel gerarUrl, byte[] data)
        {
            var streamContent = new StreamContent(new MemoryStream(data, false));
            streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = "file" };
            var httpContent = new MultipartFormDataContent { streamContent };

            gerarUrl.Body.ToList().ForEach(item => httpContent.Add(new StringContent(item.Value), item.Key));

            await PostRequest<Task>(
                url: gerarUrl.Url,
                httpContent: httpContent,
                ignoreResponseData: true,
                authenticationType: Enums.AuthenticationType.None
            );

            return gerarUrl.IdentificadorTemporarioArquivoNaNuvem;
        }

        #region[v1]
        public async Task<EncaminhamentoModel> PostEncaminhamento(EncaminhamentoRequestModel parameters)
        {
            return await PostRequest<EncaminhamentoModel>($"{_baseUrl}/encaminhamentos", parameters);
        }

        public async Task<DocumentoModel> PostDocumento(DocumentoRequestModel parameters)
        {
            var httpContent = new MultipartFormDataContent
        {
            { new StringContent("true"), "Assinar" },
            { new StringContent(parameters.AssinanteId), "AssinantesIds[0]" },
            { new StringContent(parameters.AssinanteId), "CapturadorId" },
            { new StringContent(parameters.DocumentoClasseId), "ClasseId" },
            { new StreamContent(new MemoryStream(parameters.Data, false)), "File", parameters.FileName }
        };

            if (parameters.Publico)
            {
                httpContent.Add(new StringContent("true"), "Publico");
            }

            if (parameters.FundamentosLegaisIds != null && parameters.FundamentosLegaisIds.Length > 0)
            {
                for (var i = 0; i < parameters.FundamentosLegaisIds.Length; i++)
                {
                    httpContent.Add(new StringContent(parameters.FundamentosLegaisIds[i].ToString()), $"FundamentosLegaisIds[{i}]");
                }
            }

            return await PostRequest<DocumentoModel>($"{_baseUrl}/documentos", parameters, httpContent);
        }
        #endregion

        // =========================
        // private methods
        // =========================

        private async Task<T> GetRequest<T>(string url) where T : class
        {
            var (isSuccess, data, errorMessage) = await _apiContext.GetRequest<T>(url, Enums.AuthenticationType.User);

            if (!isSuccess)
            {
                var ex = new EDocsApiException(errorMessage);
                throw ex;
            }

            return data;
        }

        private async Task<T> PostRequest<T>(
            string url,
            object body = null,
            HttpContent httpContent = null,
            bool? ignoreResponseData = false,
            Enums.AuthenticationType? authenticationType = null
        ) where T : class
        {
            var (isSuccess, data, errorMessage) = await _apiContext.PostRequest<T>(
                url,
                authenticationType ?? Enums.AuthenticationType.User,
                body,
                httpContent,
                ignoreResponseData
            );

            if (!isSuccess)
            {
                var ex = new EDocsApiException(errorMessage);                
                throw ex;
            }

            return data;
        }
    }
}
