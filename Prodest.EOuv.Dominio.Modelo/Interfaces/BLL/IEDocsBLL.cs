using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo
{
    public interface IEDocsBLL
    {
        Task<List<PapelModel>> GetPapeis();

        Task<EncaminhamentoModel> GetEncaminhamento(Guid id);

        Task<string> GetDocumentoDownloadUrl(Guid id);

        Task<DocumentoControladoModel[]> GetDocumentoEncaminhamento(string idEncaminhamento);

        Task<EncaminhamentoRastreioModel> GetRastreio(string idEncaminhamento);

        Task<EncaminhamentoRastreioModel> GetRastreioCompleto(string idEncaminhamento);

        Task<bool> EncontraDestinatario(string idEncaminhamentoRaiz, string[] idDestinatario);

        Task<DocumentoModel> GetDocumento(string id);

        Task<string> PostTempUrlMinio(GerarUrlModel gerarUrl, byte[] data);

        Task<PlanoModel[]> GetPlanosAtivos(string id);

        Task<ClasseModel[]> GetClassesAtivas(string id);

        Task<FundamentoLegalModel[]> GetFundamentosLegais(string id);

        Task<string> PostDocumentoCapturarNatoDigitalCopiaServidor(DocumentoRequestModel parameters);

        Task<List<PatriarcaModel>> GetPatriarca();

        Task<List<PatriarcaModel>> GetOrganizacoes(string idPatriarca);

        Task<List<PatriarcaSetorModel>> GetSetores(string idOrgao);

        Task<List<PatriarcaSetorModel>> GetGrupoTrabalho(string idOrgao);

        Task<List<PatriarcaSetorModel>> GetComissoes(string idOrgao);

        Task<EventoModel> GetEvento(string id);

        Task<string> GetProtocoloEncaminhamento(string idEncaminhamento);

        Task<EncaminhamentoModel> GetEncaminhamentoPorProtocolo(string protocolo);

        Task<string> PostEncaminhamentoNovo(EncaminhamentoRequestModel parameters);

        Task<PapelModel[]> GetUsuarioPapeisEncaminhamento(Guid id);

        Task<PlanoModel[]> GetPlanosAtivos(Guid id);

        Task<ClasseModel[]> GetClassesAtivas(Guid id);

        Task<FundamentoLegalModel[]> GetFundamentosLegais(Guid id);

        Task<GerarUrlModel> GetGerarUrl(int dataLength);

        Task<AssinaturaDigitalValidaModel> PostAssinaturaDigitalValida(AssinaturaDigitalValidaModel model);

        Task<string> CapturarDocumento(byte[] arquivo, string papelResponsavel, string nomeArquivo);

        Task<string> EncaminharDocumento(string idDocumento, string assunto, string mensagem, string papelResponsavel, string papelDestinatario);
    }
}