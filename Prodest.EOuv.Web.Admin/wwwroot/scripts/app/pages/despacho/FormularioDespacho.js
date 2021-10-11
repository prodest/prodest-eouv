const DespachoForm = {

    name: 'DespachoForm',
    template: '#template-despacho-form',
    components: [SelecaoDestinatarios],
    emits: ['incluir-campo-file'],
    data() {
        return {
            titulo: 'Formulário de Despacho',
            campoFile: [],
            idCampoFile: 0,
            papeisUsuario: [],
            papelSelecionado: null

        }
    },

    mounted() {
        this.CarregarPapeisUsuario();
    },

    methods: {
        IncluirCampoFile() {
            this.idCampoFile++;
            this.campoFile.push('file-' + (this.idCampoFile))
        },
        RemoverCampoFile(campo) {
            console.log(campo);
            this.campoFile = utils.RemoverItemArray(this.campoFile, campo);
        },        
        async CarregarPapeisUsuario() {
            let ret = await eOuvApi.PapeisUsuarioEDocs();
            this.papeisUsuario = JSON.parse(JSON.stringify(ret));
        }        
    }
};