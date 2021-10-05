const tipoUnidadeCadastroApi = {

    async obterTiposUnidade() {
        let ret = await fetchData.fetchGetJson(`/tipoUnidade/obter/`);
        return ret;
    },

    async obterTipoUnidade(id) {
        let ret = await fetchData.fetchGetJson(`/tipoUnidade/obter/${id}`);
        let tipo = ret.retorno;
        return tipo;
    },

    async inserirTipoUnidade(tipo) {
        let ret = await fetchData.fetchPostJson('/tipoUnidade/inserir', tipo);
        return ret;
    },

    async alterarTipoUnidade(tipo) {
        let ret = await fetchData.fetchPostJson('/tipoUnidade/alterar', tipo);
        return ret;
    },

    async excluirTipoUnidade(id) {
        let ret = await fetchData.fetchPostJson('/tipoUnidade/excluir', id);
        return ret;
    }

}

const TipoUnidadeForm = {

    name: 'TipoUnidadeForm',
    template: '#template-tipo-unidade-form',
    mixins: [BaseMixin],
    emits: ['tipo-unidade-salvo'],

    data() {
        return {
            tipo: {},
            modal: null
        }
    },

    computed: {

        titulo() {
            return (this.tipo.id ? "Alterar Tipo de Unidade" : "Nova Tipo de Unidade");
        },
    },

    methods: {

        fechar() {
            bootstrapHelper.closeModal(this.modal);
        },

        async carregar(id) {

            if (id)
                this.tipo = await tipoUnidadeCadastroApi.obterTipoUnidade(id);
            else
                this.tipo = {};

            this.modal = bootstrapHelper.openModal(this.$refs.modalForm);
        },

        async salvar() {

            let isValido = this.validarForm(this.$refs.form);

            if (isValido) {

                let ret = null;

                await this.setLoadingAndExecute(async () => {

                    try {

                        if (this.tipo.id)
                            ret = await tipoUnidadeCadastroApi.alterarTipoUnidade(this.tipo);
                        else
                            ret = await tipoUnidadeCadastroApi.inserirTipoUnidade(this.tipo);

                        if (ret.ok) {
                            mensagemSistema.showMensagemSucesso(ret.mensagem);
                            this.$emit('tipo-unidade-salvo');
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

const TipoUnidadeList = {

    name: 'TipoUnidadeList',
    template: '#template-tipo-unidade-list',
    mixins: [BaseMixin],
    components: [TipoUnidadeForm, ConfirmationDialog],

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

                let ret = await tipoUnidadeCadastroApi.obterTiposUnidade();
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

        async excluir(tipo) {

            const confirma = await this.$refs.confirmaExclusao.aguardarConfirmacao({
                titulo: 'Exclusão de Tipo de Unidade',
                mensagem: `Deseja excluir o tipo ${tipo.descricao} ?`,
                okLabel: 'Excluir',
            });

            if (confirma) {

                await this.setLoadingAndExecute(async () => {

                    let ret = await tipoUnidadeCadastroApi.excluirTipoUnidade(tipo.id);

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
app.component('tipo-unidade-list', TipoUnidadeList)
app.component('tipo-unidade-form', TipoUnidadeForm)
app.mount('#app');