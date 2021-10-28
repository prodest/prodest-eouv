const RespostaForm = {
    name: 'RespostaForm',
    template: '#template-resposta-form',
    props: ['manifestacao'],
    data() {
        return {
            textoResposta: '',
            idManifestacao: 0,
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

        ApenasPositivo(item) {
            return item.classificacaoResultadoResposta.toLowerCase() == "positivo";
        },

        ApenasNegativo(item) {
            return item.classificacaoResultadoResposta.toLowerCase() == "negativo";
        },

        async ObterResultadosRespostaPorTipologia() {
            let ret = await eOuvApi.ObterResultadosRespostaPorTipologia();
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