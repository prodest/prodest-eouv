const organizacaoCadastroApi = {

    async obterPatriarcas() {
        let ret = await fetchData.fetchGetJson(`/organizacao/patriarcas`);
        return ret;
    },

    async obterOrganizacoesPorPatriarca(guidPatriarca) {
        let ret = await fetchData.fetchGetJson(`/organizacao/ObterPorPatriarca/${guidPatriarca}`);
        return ret;
    },

    async obterOrganizacao(guidOrganizacao) {
        let ret = await fetchData.fetchGetJson(`/organizacao/obter/${guidOrganizacao}`);
        return ret;
    },

    async inserirOrganizacao(organizacao) {
        let ret = await fetchData.fetchPostJson('/organizacao/inserir', organizacao);
        return ret;
    },

    async alterarOrganizacao(organizacao) {
        let ret = await fetchData.fetchPostJson('/organizacao/alterar', organizacao);
        return ret;
    },

    async excluirOrganizacao(guid) {
        let ret = await fetchData.fetchPostJson('/organizacao/excluir', guid);
        return ret;
    }
}

const OrganizacaoForm = {

    name: 'OrganizacaoForm',
    template: '#template-organizacao-form',
    mixins: [BaseMixin],
    components: [EnderecoForm],
    emits: ['organizacao-salva'],

    data() {
        return {
            organizacao: {},
            patriarca: {},
            readOnly: false,
            tipoOrganizacaoLista: [],
            modal: null
        }
    },

    async mounted() {
        await this.obterTiposOrganizacao();
    },

    methods: {

        fechar() {
            bootstrapHelper.closeModal(this.modal);
        },

        async carregar(guidPatriarca, guid, readOnly) {

            //pega patriarca
            let retPat = await organizacaoCadastroApi.obterOrganizacao(guidPatriarca);
            if (!retPat.ok) {
                mensagemSistema.showMensagemErro(retPat.mensagem);
            }
            else {
                this.patriarca = retPat.retorno;
            }

            if (guid) {
                //obtem pelo guid
                let retOrg = await organizacaoCadastroApi.obterOrganizacao(guid);
                if (retOrg.ok) {
                    this.organizacao = retOrg.retorno;
                }
                else {
                    mensagemSistema.showMensagemErro(retOrg.mensagem);
                }
            }
            else {
                //novo
                this.organizacao = { guidOrganizacaoPai: guidPatriarca };
            }

            this.readOnly = readOnly;
            this.modal = bootstrapHelper.openModal(this.$refs.modalForm);
        },

        async salvar() {

            let isValido = this.validarForm(this.$refs.form);

            if (isValido) {

                let ret = null;

                await this.setLoadingAndExecute(async () => {

                    try {

                        //trata mascaras
                        this.organizacao.cnpj = mascaras.removeMascara(this.organizacao.cnpj);
                        this.organizacao.endereco.cep = mascaras.removeMascara(this.organizacao.endereco.cep);

                        if (this.organizacao.guid)
                            ret = await organizacaoCadastroApi.alterarOrganizacao(this.organizacao);
                        else
                            ret = await organizacaoCadastroApi.inserirOrganizacao(this.organizacao);

                        if (ret.ok) {
                            mensagemSistema.showMensagemSucesso(ret.mensagem);
                            this.$emit('organizacao-salva');
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

        async copiarEnderecoPatriarca() {
            const patEnd = utils.copiaSimples(this.patriarca.endereco);
            this.organizacao.endereco = patEnd;
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

const OrganizacaoList = {

    name: 'OrganizacaoList',
    template: '#template-organizacao-list',
    mixins: [BaseMixin],
    components: [ConfirmationDialog],

    data() {
        return {
            patriarcasFiltro: [],
            guidPatriarca: '',

            organizacoes: [],
            lista: [],  //quando filtra, ela tem menos dados que a organizacoes
            meta: {},
            campoFiltro: ''
        }
    },

    async mounted() {
        await this.carregarPatriarcasFiltro();
    },

    methods: {

        async carregarPatriarcasFiltro() {

            let ret = await organizacaoCadastroApi.obterPatriarcas();
            if (ret.ok) {
                this.patriarcasFiltro = ret.retorno;
            }

            if (this.patriarcasFiltro) {

                let guidPatInformado = utils.obterRequestParameter('guidPatriarca');

                if (guidPatInformado && this.patriarcasFiltro.filter(p => { return p.guid == guidPatInformado }).length > 0) {
                    //se informado na querystring e existe na lista de patriarcas, filtra por ele
                    this.guidPatriarca = guidPatInformado;
                }
                else {
                    //seleciona o primeiro da lista
                    this.guidPatriarca = this.patriarcasFiltro[0].guid;
                }

                this.obterTodos();
            }
        },

        selecionarPatriarca() {
            this.obterTodos();
        },

        async obterTodos() {

            await this.setLoadingAndExecute(async () => {

                let ret = await organizacaoCadastroApi.obterOrganizacoesPorPatriarca(this.guidPatriarca);
                if (ret.ok) {
                    this.organizacoes = ret.retorno.lista;
                    this.meta = ret.retorno.meta;

                    this.campoFiltro = '';
                    this.filtrar();
                }
                else {
                    mensagemSistema.showMensagemErro(ret.mensagem);
                }
            });
        },

        filtrar() {

            if (this.campoFiltro) {

                let termoBusca = this.campoFiltro;

                let orgs = this.organizacoes.filter(org => {
                    return (
                        utils.estaContido(org.sigla, termoBusca) ||
                        utils.estaContido(org.razaoSocial, termoBusca) ||
                        utils.estaContido(org.tipoOrganizacao, termoBusca) ||
                        utils.estaContido(org.municipio, termoBusca) ||
                        utils.estaContido(org.bairro, termoBusca)
                    );
                });

                this.lista = orgs;

            }
            else {
                this.lista = this.organizacoes;
            }
        },

        novo() {
            this.$refs.formulario.carregar(this.guidPatriarca);
        },

        visualizar(guid) {
            this.$refs.formulario.carregar(this.guidPatriarca, guid, true);
        },

        alterar(guid) {
            this.$refs.formulario.carregar(this.guidPatriarca, guid, false);
        },

        verUnidades(idPatriarca, idOrganizacao) {
            window.location.href = `/Unidade?guidPatriarca=${idPatriarca}&guidOrganizacao=${idOrganizacao}`;
        },

        async excluir(organizacao) {

            const confirma = await this.$refs.confirmaExclusao.aguardarConfirmacao({
                titulo: 'Exclusão de Organização',
                mensagem: `Deseja excluir a organização ${organizacao.sigla} ?`,
                okLabel: 'Excluir',
            });

            if (confirma) {

                await this.setLoadingAndExecute(async () => {

                    let ret = await organizacaoCadastroApi.excluirOrganizacao(organizacao.guid);

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
app.component('organizacao-list', OrganizacaoList)
app.component('organizacao-form', OrganizacaoForm)
app.component('endereco-form', EnderecoForm)
app.mount('#app');