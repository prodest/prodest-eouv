using Prodest.EOuv.Dominio.Modelo.Model.Entries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface IRespostaBLL
    {
        Task<List<ResultadoRespostaModel>> ObterResultadosRespostaPorTipologia(int idTipoManifestacao);

        Task<List<OrgaoModel>> ObterOrgaosCompetenciaFato();
        Task ResponderManifestacao(RespostaManifestacaoEntryModel respostaEntryModel);
    }
}