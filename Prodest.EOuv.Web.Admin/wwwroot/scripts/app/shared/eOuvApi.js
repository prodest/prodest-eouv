const eOuvApi = {
    //Métodos Controller Manifestacao ------------------------------------------------------------
    async ObterDadosCompletosManifestacao(id) {
        let ret = await fetchData.fetchGetJson(`/Manifestacao/ObterDadosCompletosManifestacao/` + id);
        return ret;
    },

    async ObterManifestacaoPorId(id) {
        let ret = await fetchData.fetchGetJson(`/Manifestacao/ObterManifestacaoPorId/` + id);
        return ret;
    },

    //Métodos Controller Despacho ----------------------------------------------------------------
    async ObterDespachosPorManifestacao(id) {
        let ret = await fetchData.fetchGetJson(`/Despacho/ObterDespachosPorManifestacao/` + id);
        return ret;
    },

    async Despachar(entry) {
        let ret = await fetchData.fetchPostJson(`/Despacho/Despachar`, entry);
        return ret;
    },

    async EncerrarDespachoManualmente(id) {
        let ret = await fetchData.fetchPostJson(`/Despacho/EncerrarDespachoManualmente/` + id);
        return ret;
    },

    //Métodos Controller Resposta ----------------------------------------------------------------

    async ObterDocumentosEncaminhamentoEDocs(id) {
        let ret = await fetchData.fetchGetJson(`/Resposta/ObterDocumentosEncaminhamentoEDocs/` + id);
        return ret;
    },

    async ObterResultadosRespostaPorTipologia(id) {
        let ret = await fetchData.fetchGetJson(`/Resposta/ObterResultadosRespostaPorTipologia/` + id);
        return ret;
    },

    async ObterOrgaosCompetenciaFato() {
        let ret = await fetchData.fetchGetJson(`/Resposta/ObterOrgaosCompetenciaFato`);
        return ret;
    },

    async Responder(entry) {
        let ret = await fetchData.fetchPostJson(`/Resposta/Responder`, entry);
        return ret;
    },

    //Métodos Controller Edocs ----------------------------------------------------------------

    async OrgaoseDocs() {
        let ret = await fetchData.fetchGetJson(`/Edocs/BuscarOrganizacoes`);
        return ret;
    },

    async SetoreseDocs() {
        let ret = await fetchData.fetchGetJson(`/Edocs/BuscarSetores`);
        return ret;
    },

    async GruposeDocs() {
        let ret = await fetchData.fetchGetJson(`/Edocs/BuscarGrupoTrabalho`);
        return ret;
    },

    async ComissoeseDocs() {
        let ret = await fetchData.fetchGetJson(`/Edocs/BuscarComissoes`);
        return ret;
    },

    async AgentesDocs(nome) {
        let ret = await fetchData.fetchGetJson(`/Edocs/BuscarAgentes?nome=${nome}`);
        return ret;
    },

    async PapeisUsuarioEDocs() {
        let ret = await fetchData.fetchGetJson(`/Edocs/BuscarPapeis`);
        return ret;
    },

    async RastreioEncaminhamento() {
        let ret = await fetchData.fetchGetJson(`/Edocs/BuscarRastreio`);
        return ret;
    },
}