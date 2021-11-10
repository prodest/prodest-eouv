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




    }
}