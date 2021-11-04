﻿const eOuvApi = {
    async obterDespachos() {
        let ret = await fetchData.fetchGetJson(`/Despacho/index`);
        return ret;
    },

    async ObterDespachosPorManifestacao(id) {
        let ret = await fetchData.fetchGetJson(`/Despacho/ObterDespachosPorManifestacao/` + id);
        return ret;
    },

    async obterDadosCompletosManifestacao(id) {
        let ret = await fetchData.fetchGetJson(`/Despacho/ObterDadosCompletosManifestacao/` + id);
        return ret;
    },

    async obterManifestacaoPorId(id) {
        let ret = await fetchData.fetchGetJson(`/Resposta/ObterManifestacaoPorId/` + id);
        return ret;
    },

    async despachar(entry) {
        let ret = await fetchData.fetchPostJson(`/Despacho/Despachar`, entry);
        return ret;
    },

    async EncerrarDespachoManualmente(id) {
        let ret = await fetchData.fetchPostJson(`/Despacho/EncerrarDespachoManualmente/` + id);
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

    async RastreioEncaminhamento() {
        let ret = await fetchData.fetchGetJson(`/edocs/BuscarRastreio`);
        return ret;
    },

    async ObterDocumentosEncaminhamentoEDocs(id) {
        let ret = await fetchData.fetchGetJson(`/resposta/ObterDocumentosEncaminhamentoEDocs/` + id);
        return ret;
    },

    async ObterResultadosRespostaPorTipologia(id) {
        let ret = await fetchData.fetchGetJson(`/resposta/ObterResultadosRespostaPorTipologia/` + id);
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