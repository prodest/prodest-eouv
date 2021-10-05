//
// Mixins
//

const BaseMixin = {

    data() {
        return {
            loading: false
        }
    },

    methods: {

        /**
         * seta a variavel loading = true enquanto executa a função informada, e volta para false quando terminar
         * @param {any} f funcao a ser executada (de preferencia, uma arrow function)
         */
        async setLoadingAndExecute(f) {

            try {
                this.loading = true;

                await f();
            }
            finally {
                this.loading = false;
            }
        },

        /**
        * @returns {boolean}
        */
        validarForm(form) {

            let isValido = form.checkValidity();

            if (!isValido) {
                form.classList.add('was-validated');
            }

            return isValido;
        }
    }
}


//
// Diretivas
//

// v-ext-loading

const diretivaLoading = {
    mounted(el, binding) {
        diretivaLoadingUtils.init(el, binding);
    },
    updated(el, binding) {
        diretivaLoadingUtils.init(el, binding);
    }
}

const diretivaLoadingUtils = {
    init(el, binding) {
        if (binding.value == true)
            el.classList.add('ext-component-loading');
        else
            el.classList.remove('ext-component-loading');
    }
}

// v-ext-mask

const diretivaMask = {
    mounted(el, binding) {
        diretivaMaskUtils.init(el, binding);
    },
    updated(el, binding) {
        diretivaMaskUtils.init(el, binding);
    }
}

const diretivaMaskUtils = {
    init(el, binding) {

        const maskVal = binding.value;

        switch (maskVal) {
            case 'cnpj':
                el.value = mascaras.parseCnpj(el.value);
                break;

            case 'cep':
                el.value = mascaras.parseCep(el.value);
                break;

            default:
                break;
        }

        if (binding.value == true)
            el.classList.add('ext-component-loading');
        else
            el.classList.remove('ext-component-loading');
    }
}


//
// Criação de app
//

const VueFactory = {

    createApp() {

        let app = Vue.createApp({});

        //registra componentes reusaveis
        app.component('confirmation-dialog', ConfirmationDialog)

        //registra diretivas

        // v-ext-loading
        app.directive('ext-loading', diretivaLoading);

        // v-ext-mask
        app.directive('ext-mask', diretivaMask);

        return app;
    }
}