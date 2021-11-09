﻿const RespostaForm = {
    name: 'RespostaForm',
    mixins: [BaseMixin],
    template: '#template-resposta-form',
    props: ['manifestacao'],
    data() {
        return {
            textoResposta: '',
            idManifestacao: 0,
            manifestacao: null,
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

    async mounted() {
        this.ObterParametrosQueryString();
        await this.ObterManifestacaoPorId();
        await this.CarregarDocumentosEDocs();
        this.ObterResultadosRespostaPorTipologia();
        this.ObterOrgaosCompetenciaFato();
    },

    methods: {
        ObterParametrosQueryString() {
            this.idManifestacao = utils.obterRequestParameter('id')
        },

        async ObterManifestacaoPorId() {
            let ret = await eOuvApi.ObterManifestacaoPorId(this.idManifestacao);
            this.manifestacao = ret.retorno;
            this.idOrgaosCompetenciaFato = this.manifestacao.idOrgaoResponsavel;
        },

        async CarregarDocumentosEDocs() {
            await this.setLoadingAndExecute(async () => {
                let ret = await eOuvApi.ObterDocumentosEncaminhamentoEDocs(this.idManifestacao);
                this.documentosEncaminhamento = ret.retorno;
                console.log(this.documentosEncaminhamento);
            });
        },

        ApenasPositivo(item) {
            return item.classificacaoResultadoResposta.toLowerCase() == "positivo";
        },

        ApenasNegativo(item) {
            return item.classificacaoResultadoResposta.toLowerCase() == "negativo";
        },

        async ObterResultadosRespostaPorTipologia() {
            let ret = await eOuvApi.ObterResultadosRespostaPorTipologia(this.manifestacao?.idTipoManifestacao);
            this.resultadosRespostaPorTipologia = ret.retorno;
            this.resultadosRespostaPositiva = this.resultadosRespostaPorTipologia.filter(this.ApenasPositivo);
            this.resultadosRespostaNegativa = this.resultadosRespostaPorTipologia.filter(this.ApenasNegativo);
        },

        async ObterOrgaosCompetenciaFato() {
            let ret = await eOuvApi.ObterOrgaosCompetenciaFato();
            this.orgaosCompetenciaFato = ret.retorno;
            console.log(this.orgaosCompetenciaFato);
        },

        async Cancelar() {
            window.location.href = "/Despacho/AcompanharDespachos/" + this.idManifestacao;
        },

        async Responder(event) {

            let form = document.querySelector('.needs-validation');
            form.classList.add('was-validated');

            if (form.checkValidity()) {
                let entry = {
                    IdManifestacao: this.manifestacao.idManifestacao,
                    TextoResposta: this.textoResposta,
                    IdResultadoResposta: this.idResultadosRespostaPorTipologia,
                    IdOrgaoCompetenciaFato: this.idOrgaosCompetenciaFato,
                    Anexos: this.documentosSelecionados
                }
                console.log(entry);

                await eOuvApi.Responder(entry);
            }

        },

        SelecionarDocumento(evento) {
            if (evento.target.checked) {
                this.documentosSelecionados.push(evento.target.id);
            }
            else {
                this.documentosSelecionados = utils.RemoverItemArray(this.documentosSelecionados, evento.target.id);
            }
        }
    }
};