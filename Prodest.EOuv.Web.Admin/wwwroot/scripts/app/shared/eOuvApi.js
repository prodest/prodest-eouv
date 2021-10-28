const eOuvApi = {
    async obterDespachos() {
        let ret = await fetchData.fetchGetJson(`/despacho/index`);
        return ret;
    },

    async obterDadosManifestacao() {
        let ret = await fetchData.fetchGetJson(`/despacho/ObterDadosManifestacao`);
        return ret;
    },

    async despachar(entry) {
        let ret = await fetchData.fetchPostJson(`/despacho/Despachar`, entry);
        return ret;
    },

    async OrgaoseDocs() {
        let ret = await fetchData.fetchGetJson(`/edocs/BuscarOrganizacoes`);
        return ret;
    },

    async SetoreseDocs() {
        let ret = await fetchData.fetchGetJson(`/edocs/BuscarSetores`);
        return ret;
    },

    async GruposeDocs() {
        let ret = await fetchData.fetchGetJson(`/edocs/BuscarGrupoTrabalho`);
        return ret;
    },

    async PapeisUsuarioEDocs() {
        let ret = await fetchData.fetchGetJson(`/edocs/BuscarPapeis`);
        return ret;
    },

    async DocumentosEncaminhamentoEDocs() {
        let ret = await fetchData.fetchGetJson(`/edocs/GetDocumentoEncaminhamento`);
        return ret;
    },

    async RastreioEncaminhamento() {
        let ret = await fetchData.fetchGetJson(`/edocs/BuscarRastreio`);
        return ret;
    },

    async ObterResultadosRespostaPorTipologia() {
        let ret = await fetchData.fetchGetJson(`/resposta/ObterResultadosRespostaPorTipologia`);
        return ret;
    },

    async ObterOrgaosCompetenciaFato() {
        let ret = await fetchData.fetchGetJson(`/resposta/ObterOrgaosCompetenciaFato`);
        return ret;
    },

    async Responder(entry) {
        let ret = await fetchData.fetchPostJson(`/resposta/Responder`, entry);
        return ret;
    },
    
}