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
            liberarResposta: false
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
            this.urlResponderManifestacao = "Resposta?id=" + this.idManifestacao;
        },
        async CarregarListaDespachos() {
            utils.LoadingDefaultOpen();
            let ret = await eOuvApi.ObterDespachosPorManifestacao(this.idManifestacao);
            this.listaDespachos = ret;
            this.VerificarLiberarResposta(this.listaDespachos);                     
            utils.LoadingDefaultClose();
        },
        Detalhar() {
        },
        async EncerrarDespachoManualmente(id) {
            utils.LoadingDefaultOpen();
            await eOuvApi.EncerrarDespachoManualmente(id);
            this.CarregarListaDespachos();
            //window.location.href = "/Despacho?id=" + this.idManifestacao;
            utils.LoadingDefaultClose();
        },
        VerificarLiberarResposta(listaDespachos) {
            //this.listaDespachos[7].dataRespostaDespachoFormat = "";
            let novalista = this.listaDespachos.filter(this.DespachosEncerrados);
            this.liberarResposta = novalista.length > 0 ? false : true;            
        },
        DespachosEncerrados(item) {            
            return utils.isNullOrEmpty(item.dataRespostaDespachoFormat);
        },
    }
};