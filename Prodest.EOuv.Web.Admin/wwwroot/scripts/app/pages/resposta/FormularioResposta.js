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

        async Responder() {
            let entry = {
                IdManifestacao: this.idManifestacao,
                TextoResposta: this.textoResposta,
                IdResultadoResposta: this.textoResposta,
                IdOrgaoCompetenciaFato: this.textoResposta,
                Anexos: this.textoResposta
            }
            console.log(entry);
            await eOuvApi.Responder(entry);
        }
        async Responder() {
            let entry = {
                idResultadosRespostaPorTipologia: this.idResultadosRespostaPorTipologia,                
                idOrgaosCompetenciaFato: this.idOrgaosCompetenciaFato,
                textoResposta: this.textoResposta
            }
            console.log(entry);
            //await eOuvApi.responder(entry);
            //window.location.href = "/Despacho/AcompanharDespachos/" + this.idManifestacao;
        },

    }
};