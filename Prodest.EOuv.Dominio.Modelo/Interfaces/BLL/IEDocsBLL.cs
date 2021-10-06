using Prodest.EOuv.Dominio.Modelo.Model.Edocs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface IEDocsBLL
    {
        Task<List<PapelModel>> GetPapeis();
        Task<EncaminhamentoModel> GetEncaminhamento(Guid id);
        Task<string> GetDocumentoDownloadUrl(Guid id);
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
        Task<string> GetEncaminhamentoProtocolo(string idEncaminhamento);
        Task<string> PostEncaminhamentoNovo(EncaminhamentoRequestModel parameters);
        Task<PapelModel[]> GetUsuarioPapeisEncaminhamento(Guid id);
        Task<PlanoModel[]> GetPlanosAtivos(Guid id);
        Task<ClasseModel[]> GetClassesAtivas(Guid id);
        Task<FundamentoLegalModel[]> GetFundamentosLegais(Guid id);
        Task<GerarUrlModel> GetGerarUrl(int dataLength);
        Task<AssinaturaDigitalValidaModel> PostAssinaturaDigitalValida(AssinaturaDigitalValidaModel model);
    }
}
