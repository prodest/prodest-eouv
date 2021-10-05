const patriarcaCadastroApi = {

    async obterPatriarcas() {
        let ret = await fetchData.fetchGetJson(`/patriarca/obter/`);
        return ret;
    },

    async obterPatriarca(guid) {
        let ret = await fetchData.fetchGetJson(`/patriarca/obter/${guid}`);
        let patriarca = ret.retorno;
        return patriarca;
    },

    async inserirPatriarca(patriarca) {
        let ret = await fetchData.fetchPostJson('/patriarca/inserir', patriarca);
        return ret;
    },

    async alterarPatriarca(patriarca) {
        let ret = await fetchData.fetchPostJson('/patriarca/alterar', patriarca);
        return ret;
    },

    async excluirPatriarca(guid) {
        let ret = await fetchData.fetchPostJson('/patriarca/excluir', guid);
        return ret;
    }
}

const PatriarcaForm = {

    name: 'PatriarcaForm',
    template: '#template-patriarca-form',
    mixins: [BaseMixin],
    components: [EnderecoForm],
    emits: ['patriarca-salvo'],

    data() {
        return {
            patriarca: {},
            modal: null,
            esferaLista: [],
            poderLista: [],
            tipoOrganizacaoLista: []
        }
    },

    async mounted() {
        await this.obterPoderes();
        await this.obterEsferas();
        await this.obterTiposOrganizacao();
    },

    methods: {

        fechar() {
            bootstrapHelper.closeModal(this.modal);
        },

        async carregar(guid) {

            if (guid)
                this.patriarca = await patriarcaCadastroApi.obterPatriarca(guid);
            else
                this.patriarca = {};

            this.modal = bootstrapHelper.openModal(this.$refs.modalForm);
        },

        async salvar() {

            let isValido = this.validarForm(this.$refs.form);

            if (isValido) {

                let ret = null;

                await this.setLoadingAndExecute(async () => {

                    try {

                        //trata mascaras
                        this.patriarca.cnpj = mascaras.removeMascara(this.patriarca.cnpj);
                        this.patriarca.endereco.cep = mascaras.removeMascara(this.patriarca.endereco.cep);

                        if (this.patriarca.guid)
                            ret = await patriarcaCadastroApi.alterarPatriarca(this.patriarca);
                        else
                            ret = await patriarcaCadastroApi.inserirPatriarca(this.patriarca);

                        if (ret.ok) {
                            mensagemSistema.showMensagemSucesso(ret.mensagem);
                            this.$emit('patriarca-salvo');
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
        },

        async obterEsferas() {

            let ret = await sharedApi.obterEsferas();
            if (ret.ok) {
                this.esferaLista = ret.retorno;
            }
            else {
                mensagemSistema.showMensagemErro(ret.mensagem);
            }
        },

        async obterPoderes() {

            let ret = await sharedApi.obterPoderes();
            if (ret.ok) {
                this.poderLista = ret.retorno;
            }
            else {
                mensagemSistema.showMensagemErro(ret.mensagem);
            }
        },

        async obterTiposOrganizacao() {

            let ret = await sharedApi.obterTiposOrganizacao();
            if (ret.ok) {
                this.tipoOrganizacaoLista = ret.retorno;
            }
            else {
                mensagemSistema.showMensagemErro(ret.mensagem);
            }
        }
    }

}

const PatriarcaList = {

    name: 'PatriarcaList',
    template: '#template-patriarca-list',
    mixins: [BaseMixin],
    components: [PatriarcaForm, ConfirmationDialog],

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

                let ret = await patriarcaCadastroApi.obterPatriarcas();
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

        alterar(guid) {
            this.$refs.formulario.carregar(guid);
        },

        verOrganizacoes(idPatriarca) {
            window.location.href = `/Organizacao?guidPatriarca=${idPatriarca}`;
        },

        async excluir(patriarca) {

            const confirma = await this.$refs.confirmaExclusao.aguardarConfirmacao({
                titulo: 'Exclusão de Patriarca',
                mensagem: `Deseja excluir o patriarca ${patriarca.sigla} ?`,
                okLabel: 'Excluir',
            });

            if (confirma) {

                await this.setLoadingAndExecute(async () => {

                    let ret = await patriarcaCadastroApi.excluirPatriarca(patriarca.guid);

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
app.component('patriarca-list', PatriarcaList)
app.component('patriarca-form', PatriarcaForm)
app.component('endereco-form', EnderecoForm)
app.mount('#app');