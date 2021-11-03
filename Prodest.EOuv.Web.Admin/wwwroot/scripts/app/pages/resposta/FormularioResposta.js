﻿const RespostaForm = {
    name: 'RespostaForm',
    template: '#template-resposta-form',
    props: ['manifestacao'],
    data() {
        return {
            textoResposta: '',
            idManifestacao: 0,
            documentosSelecionados: [],
            documentosEncaminhamento: [],
            resultadosRespostaPorTipologia: [],
            resultadosRespostaPositiva: [],
            resultadosRespostaNegativa: [],
            idResultadosRespostaPorTipologia: null,
            orgaosCompetenciaFato: [],
            idOrgaosCompetenciaFato: null
        }
    },

    mounted() {
        this.ObterParametrosQueryString();
        this.CarregarDocumentosEDocs();
        this.ObterResultadosRespostaPorTipologia();
        this.ObterOrgaosCompetenciaFato();
    },

    methods: {
        ObterParametrosQueryString() {
            this.idManifestacao = utils.obterRequestParameter('id')
        },

        async CarregarDocumentosEDocs() {
            let ret = await eOuvApi.ObterDocumentosEncaminhamentoEDocs(this.idManifestacao);
            this.documentosEncaminhamento = ret;
            console.log(this.documentosEncaminhamento);
        },

        ApenasPositivo(item) {
            return item.classificacaoResultadoResposta.toLowerCase() == "positivo";
        },

        ApenasNegativo(item) {
            return item.classificacaoResultadoResposta.toLowerCase() == "negativo";
        },

        async ObterResultadosRespostaPorTipologia() {
            let ret = await eOuvApi.ObterResultadosRespostaPorTipologia();
            this.resultadosRespostaPorTipologia = ret;
            this.resultadosRespostaPositiva = this.resultadosRespostaPorTipologia.filter(this.ApenasPositivo);
            this.resultadosRespostaNegativa = this.resultadosRespostaPorTipologia.filter(this.ApenasNegativo);            
        },

        async ObterOrgaosCompetenciaFato() {
            let ret = await eOuvApi.ObterOrgaosCompetenciaFato();
            this.orgaosCompetenciaFato = ret;
            console.log(this.orgaosCompetenciaFato);
        },

        async Cancelar() {
            window.location.href = "/Despacho/AcompanharDespachos/" + this.idManifestacao;
        },

        async Responder() {
            (function () {
                'use strict'

                // Fetch all the forms we want to apply custom Bootstrap validation styles to
                var forms = document.querySelectorAll('.needs-validation')

                // Loop over them and prevent submission
                Array.prototype.slice.call(forms)
                    .forEach(function (form) {
                        form.addEventListener('submit', function (event) {
                            if (!form.checkValidity()) {
                                event.preventDefault()
                                event.stopPropagation()
                            }

                            form.classList.add('was-validated')
                        }, false)
                    })
            })();

            let entry = {
                IdManifestacao: this.manifestacao,
                TextoResposta: this.textoResposta,
                IdResultadoResposta: this.idResultadosRespostaPorTipologia,
                IdOrgaoCompetenciaFato: this.idOrgaosCompetenciaFato,
                Anexos: this.textoResposta
            }
            console.log(entry);
            return false;
            //await eOuvApi.Responder(entry);
        }
    }
};