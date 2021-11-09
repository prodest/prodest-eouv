using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.BLL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using Prodest.EOuv.Dominio.Modelo.Interfaces.Service;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class OrgaoBLL : IOrgaoBLL
    {
        private readonly IOrgaoRepository _orgaoRepository;
        private readonly IManifestacaoBLL _manifestacaoBLL;

        public OrgaoBLL(IOrgaoRepository orgaoRepository, IManifestacaoBLL manifestacaoBLL, IUsuarioProvider usuarioProvider)
        {
            _orgaoRepository = orgaoRepository;
            _manifestacaoBLL = manifestacaoBLL;
        }

        public async Task<List<OrgaoModel>> ObterOrgaosCompetenciaFato()
        {
            return await _orgaoRepository.ObterOrgaosCompetenciaFato();
        }

        public async Task<bool> VerificarPermissaoOrgaoManifestacao(int idManifestacao, int idOrgao)
        {
            ManifestacaoModel manifestacaoModel = await _manifestacaoBLL.ObterManifestacaoPorId(idManifestacao);

            bool possuiPermissao = false;

            //List<int> listaIdOrgaosVinculados = await _orgaoRepository.ObterIdOrgaosVinculadosByOrgaoResponsavel(idOrgao);

            //if (listaIdOrgaosVinculados != null)
            //{
            //    if (manifestacaoModel.IdSituacaoManifestacao == (int)Enums.SituacaoManifestacao.ENCERRADA) //Para Manifestações encerradas, o órgão Interesse passa a ter acesso também
            //    {
            //        possuiPermissao = listaIdOrgaosVinculados.Contains(manifestacaoModel.IdOrgaoInteresse) || listaIdOrgaosVinculados.Contains(manifestacaoModel.IdOrgaoResponsavel);
            //    }
            //    else
            //    {
            //        possuiPermissao = listaIdOrgaosVinculados.Contains(manifestacaoModel.IdOrgaoResponsavel);
            //    }
            //}
            //else
            //{
            //    possuiPermissao = manifestacaoModel.IdOrgaoResponsavel == idOrgao;
            //}

            return possuiPermissao;
        }


    }
}