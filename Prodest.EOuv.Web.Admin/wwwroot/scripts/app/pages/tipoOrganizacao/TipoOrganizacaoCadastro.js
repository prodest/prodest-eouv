const tipoOrganizacaoCadastroApi = {

    async obterTiposOrganizacao() {
        let ret = await fetchData.fetchGetJson(`/tipoOrganizacao/obter/`);
        return ret;
    },

    async obterTipoOrganizacao(id) {
        let ret = await fetchData.fetchGetJson(`/tipoOrganizacao/obter/${id}`);
        let tipo = ret.retorno;
        return tipo;
    },

    async inserirTipoOrganizacao(tipo) {
        let ret = await fetchData.fetchPostJson('/tipoOrganizacao/inserir', tipo);
        return ret;
    },

    async alterarTipoOrganizacao(tipo) {
        let ret = await fetchData.fetchPostJson('/tipoOrganizacao/alterar', tipo);
        return ret;
    },

    async excluirTipoOrganizacao(id) {
        let ret = await fetchData.fetchPostJson('/tipoOrganizacao/excluir', id);
        return ret;
    }

}

const TipoOrganizacaoForm = {

    name: 'TipoOrganizacaoForm',
    template: '#template-tipo-organizacao-form',
    mixins: [BaseMixin],
    emits: ['tipo-organizacao-salvo'],

    data() {
        return {
            tipo: {},
            modal: null
        }
    },

    computed: {

        titulo() {
            return (this.tipo.id ? "Alterar Tipo de Organização" : "Novo Tipo de Organização");
        },
    },

    methods: {

        fechar() {
            bootstrapHelper.closeModal(this.modal);
        },

        async carregar(id) {

            if (id)
                this.tipo = await tipoOrganizacaoCadastroApi.obterTipoOrganizacao(id);
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
                            ret = await tipoOrganizacaoCadastroApi.alterarTipoOrganizacao(this.tipo);
                        else
                            ret = await tipoOrganizacaoCadastroApi.inserirTipoOrganizacao(this.tipo);

                        if (ret.ok) {
                            mensagemSistema.showMensagemSucesso(ret.mensagem);
                            this.$emit('tipo-organizacao-salvo');
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

const TipoOrganizacaoList = {

    name: 'TipoOrganizacaoList',
    template: '#template-tipo-organizacao-list',
    mixins: [BaseMixin],
    components: [TipoOrganizacaoForm, ConfirmationDialog],

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

                let ret = await tipoOrganizacaoCadastroApi.obterTiposOrganizacao();
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
                titulo: 'Exclusão de Tipo de Organização',
                mensagem: `Deseja excluir o tipo ${tipo.descricao} ?`,
                okLabel: 'Excluir',
            });

            if (confirma) {

                await this.setLoadingAndExecute(async () => {

                    let ret = await tipoOrganizacaoCadastroApi.excluirTipoOrganizacao(tipo.id);

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
app.component('tipo-organizacao-list', TipoOrganizacaoList)
app.component('tipo-organizacao-form', TipoOrganizacaoForm)
app.mount('#app');