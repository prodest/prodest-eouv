const RespostaForm = {
    name: 'RespostaForm',
    template: '#template-resposta-form',
    data() {
        return {            
            textoResposta: '',
            idManifestacao: null,            
            documentosSelecionados: [],
            documentosEncaminhamento: []
        }
    },

    mounted() {
        this.CarregarDocumentosEDocs();        
    },

    methods: {
        async CarregarDocumentosEDocs() {
            let ret = await eOuvApi.DocumentosEncaminhamentoEDocs();
            this.documentosEncaminhamento = ret;

            console.log(this.documentosEncaminhamento);
        }
    }
};