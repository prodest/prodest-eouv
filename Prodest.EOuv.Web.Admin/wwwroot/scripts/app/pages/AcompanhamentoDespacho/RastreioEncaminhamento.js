const RastreioEncaminhamento = {
    name: 'RastreioEncaminhamento',
    template: '#template-rastreio-encaminhamento',
    data() {
        return {
            rastreioEncaminhamento:null,
        }
    },

    mounted() {        
    },

    methods: {
        async CarregarRastreioEncaminhamentoEDocs() {
            let ret = await eOuvApi.RastreioEncaminhamento();
            this.rastreioEncaminhamento = ret;
            console.log(this.rastreioEncaminhamento);
        },
    }
};