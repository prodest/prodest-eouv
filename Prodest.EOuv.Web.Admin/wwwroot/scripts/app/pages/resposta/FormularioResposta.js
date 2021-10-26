const RespostaForm = {
    name: 'RespostaForm',
    template: '#template-resposta-form',
    data() {
        return {
            textoResposta: '',
            idManifestacao: null,
            documentosSelecionados: [],
            documentosEncaminhamento: [],
            resultadosRespostaPorTipologia: [],
            idResultadosRespostaPorTipologia: null,
            orgaosCompetenciaFato: [],
            idOrgaosCompetenciaFato: null
        }
    },

    mounted() {
        this.CarregarDocumentosEDocs();
        this.ObterResultadosRespostaPorTipologia();
        this.ObterOrgaosCompetenciaFato();
    },

    methods: {
        async CarregarDocumentosEDocs() {
            let ret = await eOuvApi.DocumentosEncaminhamentoEDocs();
            this.documentosEncaminhamento = ret;

            console.log(this.documentosEncaminhamento);
        },

        async ObterResultadosRespostaPorTipologia() {
            let ret = await eOuvApi.ObterResultadosRespostaPorTipologia();
            this.resultadosRespostaPorTipologia = ret;
            console.log(this.resultadosRespostaPorTipologia);
        },

        async ObterOrgaosCompetenciaFato() {
            let ret = await eOuvApi.ObterOrgaosCompetenciaFato();
            this.orgaosCompetenciaFato = ret;
            console.log(this.orgaosCompetenciaFato);
        },


    }
};