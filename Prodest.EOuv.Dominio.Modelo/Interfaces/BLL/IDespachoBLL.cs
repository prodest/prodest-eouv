using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.BLL
{
    public interface IDespachoBLL
    {
        Task<List<DespachoManifestacaoModel>> ObterDespachosPorManifestacao(int idManifestacao);

        Task AdicionarDespacho(DespachoManifestacaoModel despacho);

        Task Despachar(DespachoManifestacaoModel despachoModel, string destinatarios, string papelResponsavel, FiltroDadosManifestacaoModel listaDadosSelecionados);

        Task<List<int>> ObterDespachosEmAberto();

        Task<DespachoManifestacaoModel> ObterDespachoPorId(int IdDespachoManifestacao);

        Task<DespachoManifestacaoModel> ObterDespachoEDestinatario(int IdDespachoManifestacao);

        Task ResponderDespacho(int idDespacho);

        Task EncerrarDespachoManualmente(int idDespacho);
    }
}