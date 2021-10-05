const eOuvApi = {
    
    async obterDespachos() {
        let ret = await fetchData.fetchGetJson(`/despacho/index`);
        return ret;
    },

    async novoDespacho() {
        let ret = await fetchData.fetchGetJson(`/despacho/NovoDespacho`);
        return ret;
    }
    
}