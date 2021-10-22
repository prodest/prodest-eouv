using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo
{
    public interface IDespachoBLL
    {
        Task<List<DespachoManifestacaoModel>> ObterDespachosPorManifestacao(int idManifestacao);

        Task AdicionarDespacho(DespachoManifestacaoModel despacho);
        Task ResponderDespacho(int idDespacho, AgenteManifestacaoModel atorResposta);

        Task Despachar(DespachoManifestacaoModel despachoModel, string destinatarios, string papelResponsavel, FiltroDadosManifestacaoModel listaDadosSelecionados);
        Task<SetorModel> BuscaSetor(string idSetor);
        Task<List<int>> ObterDespachosEmAberto();
        Task AdicionarAgenteResposta(AgenteManifestacaoModel agenteResposta);
        Task<AgenteManifestacaoModel> montaAgente(string idAgente, int tipoAgente);
        Task<DespachoManifestacaoModel> ObterDespacho(int IdDespachoManifestacao);
        Task<DespachoManifestacaoModel> ObterDespachoEDestinatario(int IdDespachoManifestacao);
    }
}