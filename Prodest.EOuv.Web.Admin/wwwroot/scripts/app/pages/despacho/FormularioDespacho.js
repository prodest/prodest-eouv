const DespachoForm = {

    name: 'DespachoForm',
    template: '#template-despacho-form',
    emits: ['incluir-campo-file'],

    data() {
        return {
            titulo: 'Formulário de Despacho',
            campoFile: [],
            idCampoFile:0
        }
    },

    mounted() {

    },

    methods: {
        IncluirCampoFile() {
            this.idCampoFile++;
            this.campoFile.push('file-' + (this.idCampoFile))
        },
        RemoverCampoFile(campo) {
            console.log(campo);
            this.campoFile = this.RemoverItemArray(this.campoFile, campo);
        },
        RemoverItemArray(arr, value) {
            return arr.filter(function (ele) {
                return ele != value;
            });
        }
    }
};