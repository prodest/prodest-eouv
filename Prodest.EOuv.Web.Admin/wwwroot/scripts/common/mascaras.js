const mascaras = {

    parseCnpj(cnpj) {
        let msk = '';
        if (cnpj) {
            let x = cnpj.replace(/\D/g, '').match(/(\d{0,2})(\d{0,3})(\d{0,3})(\d{0,4})(\d{0,2})/);
            msk = !x[2] ? x[1] : x[1] + '.' + x[2] + '.' + x[3] + '/' + x[4] + (x[5] ? '-' + x[5] : '');
        }
        return msk;
    },

    parseCep(cep) {
        let msk = '';
        if (cep) {
            let x = cep.replace(/\D/g, '').match(/(\d{0,5})(\d{0,3})/);
            msk = !x[2] ? x[1] : x[1] + '-' + x[2];
        }
        return msk;
    },

    removeMascara(valor) {
        valor = valor.replace(/-/g, '').replace(/\//g, '').replace(/\./g, '')
        return valor;
    }
}