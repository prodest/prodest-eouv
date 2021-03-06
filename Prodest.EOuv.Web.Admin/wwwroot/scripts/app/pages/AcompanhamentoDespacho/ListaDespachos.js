const ListaDespachos = {
    name: 'ListaDespachos',
    mixins: [BaseMixin],
    template: '#template-lista-despachos',
    props: ['manifestacao'],
    data() {
        return {
            idManifestacao: null,
            numeroManifestacao: null,
            listaDespachos: null,
            urlNovoDespacho: null,
            urlResponderManifestacao: null,
            liberarResposta: false
        }
    },

    async mounted() {
        this.ObterParametrosQueryString();
        this.MontarURLRedirecionamento();
        await this.CarregarListaDespachos();
    },

    methods: {
        ObterParametrosQueryString() {
            this.idManifestacao = utils.obterRequestParameter('id')
        },
        MontarURLRedirecionamento() {
            this.urlNovoDespacho = "Despacho/NovoDespacho?id=" + this.idManifestacao;
            this.urlResponderManifestacao = "Resposta?id=" + this.idManifestacao;
        },
        async ObterManifestacaoPorId() {
            await this.setLoadingAndExecute(async () => {

                let ret = await eOuvApi.ObterManifestacaoPorId(this.idManifestacao);
                if (ret.ok) {
                    this.numeroManifestacao = ret.retorno.numProtocolo;
                }
                else {
                    window.location.href = "/Error?msg=" + ret.mensagem;
                }
            });
        },
        async CarregarListaDespachos() {

            await this.setLoadingAndExecute(async () => {
                try {
                    let ret = await eOuvApi.ObterManifestacaoPorId(this.idManifestacao);
                    if (ret.ok) {
                        this.numeroManifestacao = ret.retorno.numProtocolo;

                        let ret2 = await eOuvApi.ObterDespachosPorManifestacao(this.idManifestacao);
                        if (ret2.ok) {
                            this.listaDespachos = ret2.retorno;
                            this.VerificarLiberarResposta(this.listaDespachos);
                        }
                        else {
                            mensagemSistema.showMensagemErro(ret2.mensagem);
                        }
                    }
                    else {
                        window.location.href = "/Error?msg=" + ret.mensagem;
                    }

                }
                catch (e) {
                    //window.location.href = "/Error?msg=" + ret.mensagem;
                }
            });


        },
        Detalhar() {
        },
        async EncerrarDespachoManualmente(id) {
            await eOuvApi.EncerrarDespachoManualmente(id);
            this.CarregarListaDespachos();
            //window.location.href = "/Despacho?id=" + this.idManifestacao;
        },
        VerificarLiberarResposta(listaDespachos) {
            console.log(listaDespachos);

            //this.listaDespachos[7].dataRespostaDespachoFormat = "";

            let novalista = this.listaDespachos.filter(this.DespachosEncerrados);
            this.liberarResposta = novalista.length > 0 ? false : true;
            console.log(this.liberarResposta);
        },
        DespachosEncerrados(item) {
            return utils.isNullOrEmpty(item.dataRespostaDespachoFormat);
        },
    }
};