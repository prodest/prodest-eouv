const utils = {

    estaContido(dado, termoBusca) {
        return dado.toUpperCase().includes(termoBusca.toUpperCase());
    },

    /*
     * Obtém o valor do parametro na querystring na url atual do navegador
     */
    obterRequestParameter(param) {
        const queryString = window.location.search;
        const urlParams = new URLSearchParams(queryString);
        const val = urlParams.get(param);
        return val;
    },

    /*
     * Faz a cópia simples de atributos de um objeto.
     * Retorna um objeto novo contendo os atributos do informado.
     */
    copiaSimples(o) {
        const c = JSON.parse(JSON.stringify(o));
        return c;
    },

    /*
     * Testa se um objeto nulo (null, undefineded) ou se está vazio (ex: let a = {} )
     */
    isNullOrEmpty(obj) {

        if (!obj)
            return true;

        for (var key in obj) {
            if (obj.hasOwnProperty(key))
                return false;
        }
        return true;
    },

    /*
     * Remove item de um array
     */
    RemoverItemArray(arr, value) {
        return arr.filter(function (ele) {
            return ele != value;
        });
    },

    /*
     * Formata a data passada como parâmetro
     */
    DataFormatada(data) {
            dia = data.getDate().toString().padStart(2, '0'),
            mes = (data.getMonth() + 1).toString().padStart(2, '0'), //+1 pois no getMonth Janeiro começa com zero.
            ano = data.getFullYear();
        return dia + "/" + mes + "/" + ano;
    }


}