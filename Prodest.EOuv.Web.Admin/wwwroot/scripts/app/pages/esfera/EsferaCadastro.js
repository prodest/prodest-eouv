const esferaCadastroApi = {

    async obterEsferas() {
        let ret = await fetchData.fetchGetJson(`/esfera/obter/`);
        return ret;
    },

    async obterEsfera(id) {
        let ret = await fetchData.fetchGetJson(`/esfera/obter/${id}`);
        let esfera = ret.retorno;
        return esfera;
    },

    async inserirEsfera(esfera) {
        let ret = await fetchData.fetchPostJson('/esfera/inserir', esfera);
        return ret;
    },

    async alterarEsfera(esfera) {
        let ret = await fetchData.fetchPostJson('/esfera/alterar', esfera);
        return ret;
    },

    async excluirEsfera(id) {
        let ret = await fetchData.fetchPostJson('/esfera/excluir', id);
        return ret;
    }

}

const EsferaForm = {

    name: 'EsferaForm',
    template: '#template-esfera-form',
    mixins: [BaseMixin],
    emits: ['esfera-salva'],

    data() {
        return {
            esfera: {},
            modal: null
        }
    },

    computed: {

        titulo() {
            return (this.esfera.id ? "Alterar Esfera" : "Nova Esfera");
        },
    },

    methods: {

        fechar() {
            bootstrapHelper.closeModal(this.modal);
        },

        async carregar(id) {

            if (id)
                this.esfera = await esferaCadastroApi.obterEsfera(id);
            else
                this.esfera = {};

            this.modal = bootstrapHelper.openModal(this.$refs.modalForm);
        },

        async salvar() {

            let isValido = this.validarForm(this.$refs.form);

            if (isValido) {

                let ret = null;

                await this.setLoadingAndExecute(async () => {

                    try {

                        if (this.esfera.id)
                            ret = await esferaCadastroApi.alterarEsfera(this.esfera);
                        else
                            ret = await esferaCadastroApi.inserirEsfera(this.esfera);

                        if (ret.ok) {
                            mensagemSistema.showMensagemSucesso(ret.mensagem);
                            this.$emit('esfera-salva');
                            this.fechar();
                        }
                        else {
                            mensagemSistema.showMensagemErro(ret.mensagem);
                        }
                    }
                    catch (e) {
                        mensagemSistema.showMensagemErro(e);
                    }
                });
            }
        }
    }
}

const EsferaList = {

    name: 'EsferaList',
    template: '#template-esfera-list',
    mixins: [BaseMixin],
    components: [EsferaForm, ConfirmationDialog],

    data() {
        return {
            lista: []
        }
    },

    async mounted() {
        this.obterTodos();
    },

    methods: {

        async obterTodos() {

            await this.setLoadingAndExecute(async () => {

                let ret = await esferaCadastroApi.obterEsferas();
                if (ret.ok) {
                    this.lista = ret.retorno;
                }
                else {
                    mensagemSistema.showMensagemErro(ret.mensagem);
                }
            });
        },

        novo() {
            this.$refs.formulario.carregar();
        },

        alterar(id) {
            this.$refs.formulario.carregar(id);
        },

        async excluir(esfera) {

            const confirma = await this.$refs.confirmaExclusao.aguardarConfirmacao({
                titulo: 'Exclusão de Esfera',
                mensagem: `Deseja excluir a esfera ${esfera.descricao} ?`,
                okLabel: 'Excluir',
            });

            if (confirma) {

                await this.setLoadingAndExecute(async () => {

                    let ret = await esferaCadastroApi.excluirEsfera(esfera.id);

                    if (ret.ok) {
                        mensagemSistema.showMensagemSucesso(ret.mensagem);
                        this.obterTodos();
                    }
                    else {
                        mensagemSistema.showMensagemErro(ret.mensagem);
                    }
                });
            }

        }
    }
}

let app = VueFactory.createApp();
app.component('esfera-list', EsferaList)
app.component('esfera-form', EsferaForm)
app.mount('#app');