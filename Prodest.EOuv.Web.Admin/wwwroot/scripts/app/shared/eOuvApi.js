const eOuvApi = {
    
    async obterDespachos() {
        let ret = await fetchData.fetchGetJson(`/despacho/index`);
        return ret;
    },

    async novoDespacho() {
        let ret = await fetchData.fetchGetJson(`/despacho/NovoDespacho`);
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
    }
    
}