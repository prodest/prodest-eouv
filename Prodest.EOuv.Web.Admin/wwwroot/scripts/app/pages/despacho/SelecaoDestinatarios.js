﻿const SelecaoDestinatarios = {

    name: 'SelecaoDestinatarios',
    template: '#template-selecao-destinatarios',
    emits: ['get-orgaos'],

    data() {
        return {
            titulo: 'Seleção de Destinatários',
            listaOrgaos: [],
            listaSetores: [],
            listaGrupos: [],
            modal: null,
            modalDestinatarios: null,
            destinatarios: []
        }
    },

    mounted() {

    },

    methods: {
        async CarregarDadosEDocs() {
            await this.GetOrgaos();
            await this.GetGrupos();
            await this.GetSetores();
            this.VerificaCarregamentoTodos();
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
                this.listaSetores = JSON.parse(JSON.stringify(ret));
                console.log(this.listaSetores.length);
            }
        },

        async GetGrupos() {
            if (!this.listaGrupos.length > 0) {
                let ret = await eOuvApi.GruposeDocs();
                this.listaGrupos = JSON.parse(JSON.stringify(ret));
                console.log(this.listaGrupos.length);
            }
        },

        VerificaCarregamentoTodos() {
            if ((this.listaGrupos.length > 0) && (this.listaOrgaos.length > 0) && (this.listaSetores.length > 0)) {
                console.log('Todos foram carregados!');
                this.modalDestinatarios = this.$refs.destinatariosModal;
                console.log(this.modalDestinatarios);
                this.modal = bootstrapHelper.openModal(this.$refs.destinatariosModal);
            }
        },

        AdicionarDestinatario(id, nome) {
            if (this.destinatarios.filter(e => e.id === id).length == 0) {
                let destinatario = { 'id': id, 'nome': nome };
                this.destinatarios.push(destinatario);                
            }
        },

        RemoverDestinatario(id) {
            this.destinatarios = utils.RemoverItemArray(this.destinatarios, id);
        },

        FecharModal() {
            bootstrapHelper.closeModal(this.modal);
        }
    }
};