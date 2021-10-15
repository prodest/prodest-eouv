const DespachoForm = {
    name: 'DespachoForm',
    template: '#template-despacho-form',
    components: [SelecaoDestinatarios],
    emits: ['incluir-campo-file'],
    data() {
        return {
            campoFile: [],
            idCampoFile: 0,
            papeisUsuario: [],
            papelSelecionado: null,
            prazoResposta: '',
            textoDespacho: ''
        }
    },

    mounted() {
        this.CarregarPapeisUsuario();
    },

    methods: {
        IncluirCampoFile() {
            this.idCampoFile++;
            this.campoFile.push('file-' + (this.idCampoFile));
        },
        RemoverCampoFile(campo) {
            console.log(campo);
            this.campoFile = utils.RemoverItemArray(this.campoFile, campo);
        },
        async CarregarPapeisUsuario() {
            let ret = await eOuvApi.PapeisUsuarioEDocs();
            this.papeisUsuario = ret;
        },
        async Despachar() {
            let entry = {
                prazoResposta: this.prazoResposta,
                textoDespacho: this.textoDespacho,
                anexos: this.campoFile
            }
            await eOuvApi.despachar(entry);
        }
    }
};