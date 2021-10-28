const ListaDespachos = {
    name: 'ListaDespachos',
    template: '#template-lista-despachos',    
    data() {
        return {
            idManifestacao:null,
            listaDespachos: null,
        }
    },

    mounted() {
        this.CarregarListaDespachos();
    },

    methods: {
        async CarregarListaDespachos() {
            let ret = await eOuvApi.ObterAcompanharDespachos();
            this.listaDespachos = ret;// JSON.parse(JSON.stringify(ret));
            console.log(this.listaDespachos);

            if (this.listaDespachos != null) {
                this.idManifestacao = this.listaDespachos[0].idManifestacao;
            }
        },
    }
};