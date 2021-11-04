const RespostaForm = {
    name: 'RespostaForm',
    template: '#template-resposta-form',
    props: ['manifestacao'],
    data() {
        return {
            textoResposta: '',
            idManifestacao: 0,
            manifestacao: null,
            documentosSelecionados: [],
            documentosEncaminhamento: [],
            resultadosRespostaPorTipologia: [],
            resultadosRespostaPositiva: [],
            resultadosRespostaNegativa: [],
            idResultadosRespostaPorTipologia: null,
            orgaosCompetenciaFato: [],
            idOrgaosCompetenciaFato: null
        }
    },

    async mounted() {
        this.ObterParametrosQueryString();
        await this.ObterManifestacaoPorId();
        this.CarregarDocumentosEDocs();
        this.ObterResultadosRespostaPorTipologia();
        this.ObterOrgaosCompetenciaFato();
    },

    methods: {
        ObterParametrosQueryString() {
            this.idManifestacao = utils.obterRequestParameter('id')
        },

        async ObterManifestacaoPorId() {
            this.manifestacao = await eOuvApi.obterManifestacaoPorId(this.idManifestacao);
        },

        async CarregarDocumentosEDocs() {
            let ret = await eOuvApi.ObterDocumentosEncaminhamentoEDocs(this.idManifestacao);
            this.documentosEncaminhamento = ret;
            console.log(this.documentosEncaminhamento);
        },

        ApenasPositivo(item) {
            return item.classificacaoResultadoResposta.toLowerCase() == "positivo";
        },

        ApenasNegativo(item) {
            return item.classificacaoResultadoResposta.toLowerCase() == "negativo";
        },

        async ObterResultadosRespostaPorTipologia() {
            let ret = await eOuvApi.ObterResultadosRespostaPorTipologia(this.manifestacao?.idTipoManifestacao);
            this.resultadosRespostaPorTipologia = ret;
            this.resultadosRespostaPositiva = this.resultadosRespostaPorTipologia.filter(this.ApenasPositivo);
            this.resultadosRespostaNegativa = this.resultadosRespostaPorTipologia.filter(this.ApenasNegativo);
        },

        async ObterOrgaosCompetenciaFato() {
            let ret = await eOuvApi.ObterOrgaosCompetenciaFato();
            this.orgaosCompetenciaFato = ret;
            console.log(this.orgaosCompetenciaFato);
        },

        async Cancelar() {
            window.location.href = "/Despacho/AcompanharDespachos/" + this.idManifestacao;
        },

        async Responder() {
            let entry = {
                IdManifestacao: this.manifestacao,
                TextoResposta: this.textoResposta,
                IdResultadoResposta: this.idResultadosRespostaPorTipologia,
                IdOrgaoCompetenciaFato: this.idOrgaosCompetenciaFato,
                Anexos: this.textoResposta
            }
            console.log(entry);
            await eOuvApi.Responder(entry);
        }
    }
};