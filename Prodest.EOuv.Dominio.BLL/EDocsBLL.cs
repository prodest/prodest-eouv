using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Dominio.Modelo.Model.Edocs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class EDocsBLL : IEDocsBLL
    {
        private readonly IEDocsService _eDocsService;

        public EDocsBLL(IEDocsService eDocsService)
        {
            _eDocsService = eDocsService;
        }

        // ======================
        // public methods
        // ======================

        public async Task<EncaminhamentoModel> GetEncaminhamento(Guid id)
        {
            return await _eDocsService.GetEncaminhamento(id.ToString());
        }

        public async Task<string> GetDocumentoDownloadUrl(Guid id)
        {
            return await _eDocsService.GetDocumentoDownloadUrl(id.ToString());
        }

        public async Task<List<PatriarcaModel>> GetPatriarca()
        {
            return await _eDocsService.GetPatriarca();
        }

        public async Task<List<PatriarcaModel>> GetOrganizacoes(string id)
        {
            return await _eDocsService.GetOrganizacoes(id);
        }
        public async Task<List<PatriarcaSetorModel>> GetSetores(string idOrgao)
        {
            return await _eDocsService.GetSetores(idOrgao);
        }
        public async Task<List<PatriarcaSetorModel>> GetGrupoTrabalho(string idOrgao)
        {
            return await _eDocsService.GetGrupoTrabalho(idOrgao);
        }
        public async Task<List<PatriarcaSetorModel>> GetComissoes(string idOrgao)
        {
            return await _eDocsService.GetComissoes(idOrgao);
        }
        public async Task<List<PapelModel>> GetPapeis()
        {
            return await _eDocsService.GetPapeis();
        }

        public async Task<string> PostEncaminhamentoNovo(EncaminhamentoRequestModel parameters)
        {
            return await _eDocsService.PostEncaminhamentoNovo(parameters);
        }
        public async Task<PapelModel[]> GetUsuarioPapeisEncaminhamento(Guid id)
        {
            return await _eDocsService.GetUsuarioPapeisEncaminhamento(id.ToString());
        }

        public async Task<PlanoModel[]> GetPlanosAtivos(Guid id)
        {
            return await _eDocsService.GetPlanosAtivos(id.ToString());
        }

        public async Task<ClasseModel[]> GetClassesAtivas(Guid id)
        {
            return (await _eDocsService.GetClassesAtivas(id.ToString())).Where(x => x.Ativo).ToArray();
        }

        public async Task<FundamentoLegalModel[]> GetFundamentosLegais(Guid id)
        {
            return await _eDocsService.GetFundamentosLegais(id.ToString());
        }

        public async Task<GerarUrlModel> GetGerarUrl(int dataLength)
        {
            return await _eDocsService.GetGerarUrl(dataLength);
        }

        public async Task<string> PostTempUrlMinio(GerarUrlModel gerarUrl, byte[] data)
        {
            return await _eDocsService.PostTempUrlMinio(gerarUrl,data);
        }

        public async Task<string> PostDocumentoCapturarNatoDigitalCopiaServidor(DocumentoRequestModel parameters)
        {
            return await _eDocsService.PostDocumentoCapturarNatoDigitalCopiaServidor(parameters);
        }

        public async Task<PlanoModel[]> GetPlanosAtivos(string id)
        {
            return await _eDocsService.GetPlanosAtivos(id);
        }

        public async Task<FundamentoLegalModel[]> GetFundamentosLegais(string id)
        {
            return await _eDocsService.GetFundamentosLegais(id);
        }
        

        public async Task<ClasseModel[]> GetClassesAtivas(string id)
        {
            return await _eDocsService.GetClassesAtivas(id);
        }

        public async Task<AssinaturaDigitalValidaModel> PostAssinaturaDigitalValida(AssinaturaDigitalValidaModel model)
        {
            return await _eDocsService.PostAssinaturaDigitalValida(model);
        }

        // ======================
        // private methods
        // ======================
    }
}
