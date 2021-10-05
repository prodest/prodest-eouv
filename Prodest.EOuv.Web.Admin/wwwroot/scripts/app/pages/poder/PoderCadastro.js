const poderCadastroApi = {

    async obterPoderes() {
        let ret = await fetchData.fetchGetJson(`/poder/obter/`);
        return ret;
    },

    async obterPoder(id) {
        let ret = await fetchData.fetchGetJson(`/poder/obter/${id}`);
        let poder = ret.retorno;
        return poder;
    },

    async inserirPoder(poder) {
        let ret = await fetchData.fetchPostJson('/poder/inserir', poder);
        return ret;
    },

    async alterarPoder(poder) {
        let ret = await fetchData.fetchPostJson('/poder/alterar', poder);
        return ret;
    },

    async excluirPoder(id) {
        let ret = await fetchData.fetchPostJson('/poder/excluir', id);
        return ret;
    }
}

const PoderForm = {

    name: 'PoderForm',
    template: '#template-poder-form',
    mixins: [BaseMixin],
    emits: ['poder-salvo'],

    data() {
        return {
            poder: {},
            modal: null
        }
    },

    computed: {

        titulo() {
            return (this.poder.id ? "Alterar Poder" : "Novo Poder");
        },
    },

    methods: {

        fechar() {
            bootstrapHelper.closeModal(this.modal);
        },

        async carregar(id) {

            if (id)
                this.poder = await poderCadastroApi.obterPoder(id);
            else
                this.poder = {};

            this.modal = bootstrapHelper.openModal(this.$refs.modalForm);
        },

        async salvar() {

            let isValido = this.validarForm(this.$refs.form);

            if (isValido) {

                let ret = null;

                await this.setLoadingAndExecute(async () => {

                    try {

                        if (this.poder.id)
                            ret = await poderCadastroApi.alterarPoder(this.poder);
                        else
                            ret = await poderCadastroApi.inserirPoder(this.poder);

                        if (ret.ok) {
                            mensagemSistema.showMensagemSucesso(ret.mensagem);
                            this.$emit('poder-salvo');
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

const PoderList = {

    name: 'PoderList',
    template: '#template-poder-list',
    mixins: [BaseMixin],
    components: [PoderForm, ConfirmationDialog],

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

                let ret = await poderCadastroApi.obterPoderes();
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

        async excluir(poder) {

            const confirma = await this.$refs.confirmaExclusao.aguardarConfirmacao({
                titulo: 'Exclusão de Poder',
                mensagem: `Deseja excluir o poder ${poder.descricao} ?`,
                okLabel: 'Excluir',
            });

            if (confirma) {

                await this.setLoadingAndExecute(async () => {

                    let ret = await poderCadastroApi.excluirPoder(poder.id);

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
app.component('poder-list', PoderList)
app.component('poder-form', PoderForm)
app.mount('#app');