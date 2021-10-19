const DespachoForm = {
    name: 'DespachoForm',
    template: '#template-despacho-form',
    components: [SelecaoDestinatarios, DespachoManifestacao],
    emits: ['incluir-campo-file'],
    data() {
        return {
            campoAnexo: [],
            idCampoAnexo: 0,
            papeisUsuario: [],
            papelSelecionado: null,
            prazoResposta: '',
            textoDespacho: '',
            DadosManifestacaoSelecionados: {
                DadosBasicos: true,
                DadosTeor: false,
                DadosManifestante: false,
                DadosProrrogacao: false,
                DadosEncaminhamento: false,
                DadosDespacho: false,
                DadosDesdobramento: false,
                DadosAnotacao: false,
                DadosNotificacao: false,
                DadosReclamacaoOmissao: false,
                DadosResposta: false,
                DadosDiligencia: false,
                DadosApuracao: false,
                DadosComplemento: false,
                DadosAnexo: false,
                DadosInterpelacao: false,
                DadosRecursoNegativa: false,
                DadosHistorico: false
            }
        }
    },

    mounted() {
        this.CarregarPapeisUsuario();
    },

    methods: {
        IncluirCampoAnexo() {
            this.idCampoAnexo++;
            this.campoAnexo.push('file-' + (this.idCampoAnexo));
        },
        RemoverCampoAnexo(campo) {
            console.log(campo);
            this.campoAnexo = utils.RemoverItemArray(this.campoAnexo, campo);
        },
        async CarregarPapeisUsuario() {
            let ret = await eOuvApi.PapeisUsuarioEDocs();
            this.papeisUsuario = ret;
        },
        async Despachar() {
            let entry = {
                prazoResposta: this.prazoResposta,
                textoDespacho: this.textoDespacho,
                dadosManifestacaoSelecionados: JSON.parse(JSON.stringify(this.DadosManifestacaoSelecionados)),
                papelSelecionado: this.papelSelecionado,
                destinatario: null
            }
            //await eOuvApi.despachar(entry);
            console.log(entry);
        },
        ToggleDadosManifestacaoSelecionados(e) {
            console.log(e)
            let item = e.target.parentNode.id;
            this.DadosManifestacaoSelecionados[item] = !this.DadosManifestacaoSelecionados[item];

            for (var i in this.DadosManifestacaoSelecionados) {                                
                console.log(i + ': '+this.DadosManifestacaoSelecionados[i]);
                
            }

        }

    }
};