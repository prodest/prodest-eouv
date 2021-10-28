const EOuvDatePicker = {
    name: 'EOuvDatePicker',
    template: '#template-date-picker',
    emits: ['datechange'],
    props: ['idelemento','inicio', 'fim'],
    data() {
        return {
            dataSelecionada: null
        }
    },
    mounted() {        
        this.CriarCampoDatePicker(document.getElementById(this.idelemento));
    },
    methods: {
        CriarCampoDatePicker(el) {
            console.log(el);
            return new Datepicker(el, {                
                clearBtn: true,
                todayBtn: true,
                todayHighlight: true,
                daysOfWeekDisabled: [0, 6],
                //endDate:,
                //startDate:,
                format: 'dd/mm/yyyy',
                language:'pr-BR'
            });
        },

    }
}