const unidadeCadastroApi = {

    async obterPatriarcas() {
        let ret = await fetchData.fetchGetJson(`/unidade/Patriarcas`);
        return ret;
    },

    async obterOrganizacoes(guidPatriarca) {
        let ret = await fetchData.fetchGetJson(`/unidade/Organizacoes/${guidPatriarca}`);
        return ret;
    },

    async obterUnidadesPorOrganizacao(guidOrganizacao) {
        let ret = await fetchData.fetchGetJson(`/unidade/ObterPorOrganizacao/${guidOrganizacao}`);
        return ret;
    },

    async obterInfoOrganizacaoUnidades(guidOrganizacao) {
        let ret = await fetchData.fetchGetJson(`/unidade/ObterInfoOrganizacaoUnidades/${guidOrganizacao}`);
        return ret;
    },

    async obterOrganizacao(guidOrganizacao) {
        let ret = await fetchData.fetchGetJson(`/unidade/ObterOrganizacao/${guidOrganizacao}`);
        return ret;
    },

    async obterUnidade(guid) {
        let ret = await fetchData.fetchGetJson(`/unidade/obter/${guid}`);
        return ret;
    },

    async inserirUnidade(unidade) {
        let ret = await fetchData.fetchPostJson('/unidade/inserir', unidade);
        return ret;
    },

    async alterarUnidade(unidade) {
        let ret = await fetchData.fetchPostJson('/unidade/alterar', unidade);
        return ret;
    },

    async excluirUnidade(guid) {
        let ret = await fetchData.fetchPostJson('/unidade/excluir', guid);
        return ret;
    }

}

const unidadeUtils = {

    calcularNivelAndFilhos(u, nivel) {

        u.nivel = (nivel ? nivel + 1 : 1);

        let qtde = 1;

        if (u.unidadesFilhas != null && u.unidadesFilhas.length > 0) {
            for (const uf of u.unidadesFilhas) {
                let q = unidadeUtils.calcularNivelAndFilhos(uf, u.nivel);
                qtde = qtde + q;
            }
        }

        u.qtdeFilhos = qtde - 1;

        return qtde;
    }
}

const UnidadeForm = {

    name: 'UnidadeForm',
    template: '#template-unidade-form',
    mixins: [BaseMixin],
    components: [EnderecoForm],
    emits: ['unidade-salva'],

    data() {
        return {
            unidade: {},
            unidadePai: {},
            organizacao: {},
            readOnly: false,
            tipoUnidadeLista: [],
            modal: null
        }
    },

    computed: {

        nomeUnidadePai() {
            return (utils.isNullOrEmpty(this.unidadePai) ? '-' : `${this.unidadePai.sigla} - ${this.unidadePai.nome}`);
        }
    },

    async mounted() {
        await this.obterTiposUnidade();
    },

    methods: {

        fechar() {
            bootstrapHelper.closeModal(this.modal);
        },

        async novo(guidOrganizacao, guidUnidadePai) {

            try {

                //clean-up
                this.unidade = {};
                this.unidadePai = {};
                this.organizacao = {};

                //setup
                await this.obterOrgao(guidOrganizacao);
                await this.obterUnidadePaiSeInformado(guidUnidadePai);
                this.modal = bootstrapHelper.openModal(this.$refs.modalForm);
            }
            catch (e) {
                mensagemSistema.showMensagemErro(e.message);
            }
        },

        async carregar(guidOrganizacao, guid, readOnly) {

            try {

                //clean-up
                this.unidade = {};
                this.unidadePai = {};
                this.organizacao = {};

                //setup

                await this.obterOrgao(guidOrganizacao);

                let retUni = await unidadeCadastroApi.obterUnidade(guid);
                if (!retUni.ok) { throw new Error(retUni.mensagem); }
                this.unidade = retUni.retorno;
                this.unidade.idTipoUnidade = (this.unidade.tipoUnidade ? this.unidade.tipoUnidade.id : 0);

                const guidUnidadePai = (this.unidade.unidadePai ? this.unidade.unidadePai.guid : null);
                await this.obterUnidadePaiSeInformado(guidUnidadePai);

                this.readOnly = readOnly;
                this.modal = bootstrapHelper.openModal(this.$refs.modalForm);
            }
            catch (e) {
                mensagemSistema.showMensagemErro(e.message);
            }
        },

        async obterOrgao(guidOrganizacao) {
            let retOrg = await unidadeCadastroApi.obterOrganizacao(guidOrganizacao);
            if (!retOrg.ok) { throw new Error(retOrg.mensagem); }
            this.organizacao = retOrg.retorno;
        },

        async obterUnidadePaiSeInformado(guidUnidadePai) {
            if (guidUnidadePai) {
                let retUpai = await unidadeCadastroApi.obterUnidade(guidUnidadePai);
                if (!retUpai.ok) { throw new Error(retUpai.mensagem); }
                this.unidadePai = retUpai.retorno;
            }
        },

        async salvar() {

            let isValido = this.validarForm(this.$refs.form);

            if (isValido) {

                let ret = null;

                await this.setLoadingAndExecute(async () => {

                    try {

                        //trata mascaras
                        this.unidade.endereco.cep = mascaras.removeMascara(this.unidade.endereco.cep);

                        //seta ids
                        this.unidade.guidOrganizacao = this.organizacao.guid;

                        if (this.unidadePai)
                            this.unidade.guidUnidadePai = this.unidadePai.guid;

                        if (this.unidade.guid)
                            ret = await unidadeCadastroApi.alterarUnidade(this.unidade);
                        else
                            ret = await unidadeCadastroApi.inserirUnidade(this.unidade);

                        if (ret.ok) {
                            mensagemSistema.showMensagemSucesso(ret.mensagem);
                            this.$emit('unidade-salva');
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

        copiarEnderecoUnidadePai() {
            const uniEnd = utils.copiaSimples(this.unidadePai.endereco);
            this.unidade.endereco = uniEnd;
        },

        copiarEnderecoOrganizacao() {
            const orgEnd = utils.copiaSimples(this.organizacao.endereco);
            this.unidade.endereco = orgEnd;
        },

        async obterTiposUnidade() {

            let ret = await sharedApi.obterTiposUnidade();
            if (ret.ok) {
                this.tipoUnidadeLista = ret.retorno;
            }
            else {
                mensagemSistema.showMensagemErro(ret.mensagem);
            }
        }
    }

}

const UnidadeTreeItem = {

    name: 'UnidadeTreeItem',
    template: '#template-unidade-tree-item',

    props: {
        nodes: Array,
        integracao: false
    },

    methods: {

        toggle(u) {

            //nó vem visivel por padrao. Aqui, adiciona atributo 'collapsed' e o usa para mostrar ou esconder

            //fail-safe
            if (!u.collapsed)
                u.collapsed = false;

            if (u.unidadesFilhas && u.unidadesFilhas.length > 0) {
                u.collapsed = !u.collapsed;  //se tem filhos, alterna
            }
            else {
                u.collapsed = false; //se nao tem filho, nunca fecha
            }
        },

        novoFilho(u) {
            this.$root.$refs.listagem.novoFilho(u.guid);
        },

        alterar(u) {
            this.$root.$refs.listagem.alterar(u.guid);
        },

        visualizar(u) {
            this.$root.$refs.listagem.visualizar(u.guid);
        },

        excluir(u) {
            this.$root.$refs.listagem.excluir(u);
        }
    }
}

const UnidadeOrganogramaItem = {

    name: 'UnidadeOrganogramaItem',
    template: '#template-unidade-organograma-item',

    props: {
        nodes: Array,
    },

    methods: {

        getNodeClass(u) {
            return `item-nivel-${u.nivel}`;
        },

        getNodeDetailClass(u) {
            return `detail-nivel-${u.nivel}`;
        },

        getNodeStyle(u) {
            return `flex-grow: ${u.qtdeFilhos + 1};`;
        }
    }
}

const UnidadeList = {

    name: 'UnidadeList',
    template: '#template-unidade-list',
    mixins: [BaseMixin],
    components: [UnidadeForm, ConfirmationDialog],

    data() {
        return {
            patriarcasFiltro: [],
            guidPatriarca: '',
            organizacoesFiltro: [],
            guidOrganizacao: '',

            orgaoSelecionado: {},
            unidades: [],

            showArvore: true
        }
    },

    computed: {

        totalUnidades() {

            let qtde = 0;

            for (const u of this.unidades) {
                qtde += u.qtdeFilhos + 1;
            }

            return qtde;
        }

    },

    async mounted() {
        await this.carregarPatriarcasFiltro();
    },

    methods: {

        async carregarPatriarcasFiltro() {

            let ret = await unidadeCadastroApi.obterPatriarcas();
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

                await this.carregarOrganizacoesFiltro();
            }
        },

        async carregarOrganizacoesFiltro() {

            let ret = await unidadeCadastroApi.obterOrganizacoes(this.guidPatriarca);
            if (ret.ok) {
                this.organizacoesFiltro = ret.retorno;
            }

            if (this.organizacoesFiltro) {

                let guidOrgInformado = utils.obterRequestParameter('guidOrganizacao');

                if (guidOrgInformado && this.organizacoesFiltro.filter(p => { return p.guid == guidOrgInformado }).length > 0) {
                    //se informado na querystring e existe na lista de organizações, filtra por ele
                    this.guidOrganizacao = guidOrgInformado;
                }
                else {
                    //seleciona o primeiro da lista
                    this.guidOrganizacao = this.organizacoesFiltro[0].guid;
                }

                this.obterTodos();
            }
        },

        selecionarPatriarca() {
            this.carregarOrganizacoesFiltro();
        },

        selecionarOrganizacao() {
            this.obterTodos();
        },

        async obterTodos() {

            await this.setLoadingAndExecute(async () => {

                let retInfo = await unidadeCadastroApi.obterInfoOrganizacaoUnidades(this.guidOrganizacao);
                if (retInfo.ok) {
                    this.orgaoSelecionado = retInfo.retorno;
                }
                else {
                    mensagemSistema.showMensagemErro(retInfo.mensagem);
                }

                let retUni = await unidadeCadastroApi.obterUnidadesPorOrganizacao(this.guidOrganizacao);
                if (retUni.ok) {
                    this.unidades = retUni.retorno;

                    //calcula niveis para montar organograma
                    for (const u of this.unidades) {
                        unidadeUtils.calcularNivelAndFilhos(u, null);
                    }
                }
                else {
                    mensagemSistema.showMensagemErro(retUni.mensagem);
                }
            });
        },

        mostraArvore() {
            this.showArvore = true;
        },

        mostraOrganograma() {
            this.showArvore = false;
        },

        novo() {
            this.$refs.formulario.novo(this.guidOrganizacao);
        },

        novoFilho(guidUnidadePai) {
            this.$refs.formulario.novo(this.guidOrganizacao, guidUnidadePai);
        },

        alterar(guid) {
            this.$refs.formulario.carregar(this.guidOrganizacao, guid, false);
        },

        visualizar(guid) {
            this.$refs.formulario.carregar(this.guidOrganizacao, guid, true);
        },

        async excluir(unidade) {

            const confirma = await this.$refs.confirmaExclusao.aguardarConfirmacao({
                titulo: 'Exclusão de Unidade',
                mensagem: `Deseja excluir a unidade ${unidade.sigla} ?`,
                okLabel: 'Excluir',
            });

            if (confirma) {

                await this.setLoadingAndExecute(async () => {

                    let ret = await unidadeCadastroApi.excluirUnidade(unidade.guid);

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
    },
}

let app = VueFactory.createApp();
app.component('unidade-list', UnidadeList)
app.component('unidade-tree-item', UnidadeTreeItem)
app.component('unidade-organograma-item', UnidadeOrganogramaItem)
app.component('unidade-form', UnidadeForm)
app.component('endereco-form', EnderecoForm)
app.mount('#app');