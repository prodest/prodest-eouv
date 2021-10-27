const RastreioEncaminhamento = {
    name: 'RastreioEncaminhamento',
    template: '#template-rastreio-encaminhamento',    
    data() {
        return {
            rastreioEncaminhamento:null,
        }
    },

    mounted() {
        this.CarregarRastreioEncaminhamentoEDocs();
    },

    methods: {
        async CarregarRastreioEncaminhamentoEDocs() {
            let ret = await eOuvApi.RastreioEncaminhamento();
            this.rastreioEncaminhamento = ret;// JSON.parse(JSON.stringify(ret));
            console.log(this.rastreioEncaminhamento);
        },
    }
};

const Rastreio = {
    name: 'Rastreio',
    template: '#template-rastreio',
    props: ['encaminhamentos'],
    data() {
        return {
        }
    },
    mounted() { },
    methods: {

    }
};