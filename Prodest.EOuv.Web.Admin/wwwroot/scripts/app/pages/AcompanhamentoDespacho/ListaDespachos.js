const ListaDespachos = {
    name: 'ListaDespachos',
    template: '#template-lista-despachos',
    props: ['manifestacao'],
    data() {
        return {
            idManifestacao: null,
            listaDespachos: null,
            urlNovoDespacho: null,
            urlResponderManifestacao: null,
        }
    },

    mounted() {
        this.ObterParametrosQueryString();
        this.MontarURLRedirecionamento();
        this.CarregarListaDespachos();
    },

    methods: {
        async ObterParametrosQueryString() {
            this.idManifestacao = utils.obterRequestParameter('id')
        },
        async MontarURLRedirecionamento() {
            this.urlNovoDespacho = "Despacho/NovoDespacho?id=" + this.idManifestacao;
            this.urlResponderManifestacao = "Resposta/NovaResposta?id=" + this.idManifestacao;
        },
        async CarregarListaDespachos() {
            let ret = await eOuvApi.ObterDespachosPorManifestacao(this.idManifestacao);
            this.listaDespachos = ret;// JSON.parse(JSON.stringify(ret));
            console.log(this.listaDespachos);

            //if (this.listaDespachos != null) {
            //    this.idManifestacao = this.listaDespachos[0].idManifestacao;
            //}
        },
    }
};