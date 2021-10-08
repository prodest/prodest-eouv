let template = `
    <div class="modal fade"
        id="papelModal"
        tabindex="-1"
        aria-labelledby="papelModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="papelModalLabel">{{ titulo }}</h5>
                    <button type="button"
                        class="btn-close"
                        data-mdb-dismiss="modal"
                        aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <button type="button" class="mx-2 btn btn-outline-dark btn-rounded ripple-surface ripple-surface-dark" data-mdb-ripple-color="dark" style="min-width: 79px;">
                        Cidadão
                    </button>
                    <button type="button" class="mx-2 btn btn-outline-dark btn-rounded ripple-surface ripple-surface-dark" data-mdb-ripple-color="dark" style="min-width: 79px;">
                        Analista de Sistemas
                    </button>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-mdb-dismiss="modal">
                        <i class="fas fa-times"></i> Fechar
                    </button>
                </div>
            </div>
        </div>
    </div>
`;


const SelecaoPapel = {

    name: 'SelecaoPapel',
    template: template,
    emits:'incluir-papel',

    data() {
        return {
            titulo: 'Seleção de Papel'
        }
    },

    mounted() {

    },

    methods: {

    }
};