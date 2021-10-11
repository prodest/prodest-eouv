const templateBotao = `<div class="form-outline mb-3">
    <button type="button" v-on:click="get-orgaos" class="btn btn-info btn-block"><i class="fas fa-search"></i> Incluir Destinatários</button>
    </div>`;
//<script type="text/html" id="template-botao-selecao-destinatarios" >
//</script>
//data-mdb-toggle="modal" data-mdb-target="#destinatariosModal"

const BotaoSelecaoDestinatarios = {

    name: 'BotaoSelecaoDestinatarios',
    template: templateBotao,
    emits:['get-orgaos'],

    data() {
        return {
            titulo: 'Botão Seleção de Destinatários'
        }
    },

    mounted() {
        
    },

    methods: {        
    }
};