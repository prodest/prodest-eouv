using Prodest.EOuv.Dominio.Modelo.Model.Edocs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.Service
{
    public interface IEDocsService
    {
        Task<GerarUrlModel> GetGerarUrl(int dataLength);
        Task<EventoModel> GetEvento(string id);
        Task<string> GetProtocoloEncaminhamento(string idEncaminhamento);
        Task<EncaminhamentoModel> GetEncaminhamentoPorProtocolo(string protocolo);
        Task<List<PatriarcaModel>> GetPatriarca();
        Task<List<PatriarcaModel>> GetOrganizacoes(string idPatriarca);
        Task<List<PatriarcaSetorModel>> GetSetores(string idOrgao);
        Task<List<PatriarcaSetorModel>> GetGrupoTrabalho(string idOrgao);
        Task<List<PatriarcaSetorModel>> GetComissoes(string idOrgao);
        Task<List<PapelModel>> GetPapeis();
        Task<DocumentoModel> GetDocumento(string id);
        Task<DocumentoControladoModel[]> GetDocumentoEncaminhamento(string idEncaminhamento);
        Task<EncaminhamentoRastreioModel> GetRastreio(string idEncaminhamento);
        Task<EncaminhamentoRastreioModel> GetRastreioCompleto(string idEncaminhamento);
        Task<bool> EncontraDestinatario(string idEncaminhamentoRaiz, string[] idDestinatario);
        Task<EncaminhamentoModel> GetEncaminhamento(string id);
        Task<string> GetDocumentoDownloadUrl(string id);
        Task<PapelModel[]> GetUsuarioPapeisEncaminhamento(string id);
        Task<PlanoModel[]> GetPlanosAtivos(string id);
        Task<ClasseModel[]> GetClassesAtivas(string id);
        Task<FundamentoLegalModel[]> GetFundamentosLegais(string id);
        Task<string> GetDocumentoFaseAssinaturaAssinar(string id);
        Task<string> PostProcessoAutuar(ProcessoAutuarRequestModel parameters);
        Task<string> PostProcessoDespachar(ProcessoDespacharRequestModel parameters);
        Task<string> PostProcessoEntranhar(ProcessoEntranharRequestModel parameters);
        Task<string> PostProcessoDesentranhar(ProcessoDesentranharRequestModel parameters);
        Task<string> PostProcessoEncerrar(ProcessoEncerrarRequestModel parameters);
        Task<string> PostEncaminhamentoNovo(EncaminhamentoRequestModel parameters);
        Task<string> PostEncaminhamentoReencaminhar(EncaminhamentoRequestModel parameters);
        Task<string> PostDocumentoCapturarNatoDigitalIcpBrasilServidor(DocumentoRequestModel parameters);
        Task<string> PostDocumentoCapturarNatoDigitalIcpBrasilCidadao(DocumentoRequestModel parameters);
        Task<string> PostDocumentoCapturarNatoDigitalCopiaServidor(DocumentoRequestModel parameters);
        Task<string> PostDocumentoCapturarNatoDigitalCopiaCidadao(DocumentoRequestModel parameters);
        Task<string> PostDocumentoCapturarNatoDigitalAutoAssinadoServidor(DocumentoRequestModel parameters);
        Task<string> PostDocumentoCapturarNatoDigitalAutoAssinadoCidadao(DocumentoRequestModel parameters);
        Task<string> PostDocumentoCapturarDigitalizadoServidor(DocumentoRequestModel parameters);
        Task<string> PostDocumentoCapturarDigitalizadoCidadao(DocumentoRequestModel parameters);
        Task<string> PostTempUrlMinio(GerarUrlModel gerarUrl, byte[] data);
        Task<AssinaturaDigitalValidaModel> PostAssinaturaDigitalValida(AssinaturaDigitalValidaModel parameters);
        #region[v1]
        Task<EncaminhamentoModel> PostEncaminhamento(EncaminhamentoRequestModel parameters);
        Task<DocumentoModel> PostDocumento(DocumentoRequestModel parameters);
        #endregion
    }
}
