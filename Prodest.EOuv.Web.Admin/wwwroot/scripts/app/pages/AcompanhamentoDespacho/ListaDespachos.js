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
        ObterParametrosQueryString() {
            this.idManifestacao = utils.obterRequestParameter('id')
        },
        MontarURLRedirecionamento() {
            this.urlNovoDespacho = "Despacho/NovoDespacho?id=" + this.idManifestacao;
            this.urlResponderManifestacao = "Resposta/NovaResposta?id=" + this.idManifestacao;
        },
        async CarregarListaDespachos() {
            let ret = await eOuvApi.ObterDespachosPorManifestacao(this.idManifestacao);
            this.listaDespachos = ret;
            console.log(this.listaDespachos);

            //if (this.listaDespachos != null) {
            //    this.idManifestacao = this.listaDespachos[0].idManifestacao;
            //}
        },
        Detalhar() {
        },
        async EncerrarDespachoManualmente(id) {
            await eOuvApi.EncerrarDespachoManualmente(id);
            window.location.href = "/Despacho?id=" + this.idManifestacao;
        },
    }
};