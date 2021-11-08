const SelecaoDestinatarios = {
    name: 'SelecaoDestinatarios',
    mixins: [BaseMixin],
    template: '#template-selecao-destinatarios',
    emits: ['selecionar-destinatario', 'get-orgaos'],

    data() {
        return {
            titulo: 'Seleção de Destinatários',
            listaSetores: [],
            listaGrupos: [],
            listaComissoes: [],
            setores: [],
            grupos: [],
            comissoes: [],
            listaAgentes: [],
            modal: null,
            modalDestinatarios: null,
            destinatario: null,
            agentePesquisa: '',
            setorPesquisa: '',
            grupoPesquisa: '',
            comissaoPesquisa: ''
        }
    },

    mounted() {

    },

    methods: {
        async CarregarDadosEDocs() {
            this.VerificaCarregamentoTodos();
            await this.setLoadingAndExecute(async () => {

                await this.GetGrupos();
                await this.GetSetores();
                await this.GetComissoes();

            });
        },

        async GetOrgaos() {
            if (!this.listaOrgaos.length > 0) {
                let ret = await eOuvApi.OrgaoseDocs();
                this.listaOrgaos = JSON.parse(JSON.stringify(ret));
                console.log(this.listaOrgaos.length);
            }
        },

        async GetSetores() {
            if (!this.listaSetores.length > 0) {
                let ret = await eOuvApi.SetoreseDocs();
                this.setores = JSON.parse(JSON.stringify(ret));
                this.listaSetores = this.setores;
            }
        },

        async GetGrupos() {
            if (!this.listaGrupos.length > 0) {
                let ret = await eOuvApi.GruposeDocs();
                this.grupos = JSON.parse(JSON.stringify(ret));
                this.listaGrupos = this.grupos;
            }
        },

        async GetComissoes() {
            if (!this.listaComissoes.length > 0) {
                let ret = await eOuvApi.ComissoeseDocs();
                this.comissoes = JSON.parse(JSON.stringify(ret));
                this.listaComissoes = this.comissoes;

                console.log(this.comissoes);
            }
        },

        async GetAgentes() {
            let ret = await eOuvApi.AgentesDocs(this.agentePesquisa);
            this.listaAgentes = JSON.parse(JSON.stringify(ret));
            console.log(this.listaAgentes);
        },

        FiltrarSetores() {
            this.listaSetores = utils.RemoverItemArrayPesquisa(this.setores, this.setorPesquisa);
        },
        FiltrarGrupos() {
            this.listaGrupos = utils.RemoverItemArrayPesquisa(this.grupos, this.grupoPesquisa);
        },
        FiltrarComissoes() {
            this.listaComissoes = utils.RemoverItemArrayPesquisa(this.comissoes, this.comissaoPesquisa);
        },



        VerificaCarregamentoTodos() {
            //if ((this.listaGrupos.length > 0) && (this.listaSetores.length > 0)) {
            console.log('Todos foram carregados!');
            this.modalDestinatarios = this.$refs.destinatariosModal;
            console.log(this.modalDestinatarios);
            this.modal = bootstrapHelper.openModal(this.$refs.destinatariosModal);
            //}
        },

        AdicionarDestinatario(id, nome, tipo) {
            this.destinatario = { 'id': id, 'nome': nome, 'tipo': tipo };
            /*
            //Adicionar multiplos destinatarios
            if (this.destinatarios.filter(e => e.id === id).length == 0) {
                let destinatario = { 'id': id, 'nome': nome };
                this.destinatarios.push(destinatario);                
            }
            */

            this.$emit('selecionar-destinatario', this.destinatario);
        },

        RemoverDestinatario() {
            this.destinatario = null;
            /*
            //Utilizar quando estiver trabalhando com múltiplos destinatários
            this.destinatarios = utils.RemoverItemArray(this.destinatarios, id);
            */

        },

        FecharModal() {
            bootstrapHelper.closeModal(this.modal);
        }
    }
};