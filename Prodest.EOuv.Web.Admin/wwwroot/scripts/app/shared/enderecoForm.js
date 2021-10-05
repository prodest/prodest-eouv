const EnderecoForm = {

    name: 'EnderecoForm',
    template: '#template-endereco-form',
    emits: ['endereco-change'],

    data() {
        return {
            endereco: {},
            listaMunicipios: []
        }
    },

    props: {
        valorInicial: {},
        readOnly: false
    },

    async mounted() {
        await this.obterMunicipios();
    },

    watch: {
        valorInicial(val, oldVal) {
            this.endereco = (val ? val : {});
        }
    },

    methods: {

        async obterMunicipios() {

            let ret = await sharedApi.obterMunicipios();
            if (ret.ok) {
                this.listaMunicipios = ret.retorno;
            }
            else {
                mensagemSistema.showMensagemErro(ret.mensagem);
            }
        },

        emitirMudanca() {
            this.$emit('endereco-change', this.endereco);
        }
    }
}