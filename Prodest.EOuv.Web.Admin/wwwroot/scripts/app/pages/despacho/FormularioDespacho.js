﻿const PrazoEmDias = 20;
const DespachoForm = {
    name: 'DespachoForm',
    template: '#template-despacho-form',
    components: [SelecaoDestinatarios, DespachoManifestacao],
    emits: ['incluir-campo-file'],
    data() {
        return {
            anexos: [],
            idCampoAnexo: 0,
            papeisUsuario: [],
            papelSelecionado: null,
            prazoResposta: null,
            textoDespacho: '',
            idManifestacao: null,
            destinatarioSelecionado: null,
            dadosManifestacaoSelecionados: {
                DadosBasicos: true,
                DadosTeor: false,
                DadosManifestante: false,
                DadosProrrogacao: false,
                DadosEncaminhamento: false,
                DadosDespacho: false,
                DadosDesdobramento: false,
                DadosAnotacao: false,
                DadosNotificacao: false,
                DadosReclamacaoOmissao: false,
                DadosResposta: false,
                DadosDiligencia: false,
                DadosApuracao: false,
                DadosComplemento: false,
                DadosAnexo: false,
                DadosInterpelacao: false,
                DadosRecursoNegativa: false,
                DadosHistorico: false
            },
            urlDespachar: null,
            urlCancelar: null,
            prazoAtendimentoManifestacao: null,
            dataAtual: null
        }
    },

    mounted() {
        this.CarregarPapeisUsuario();        
    },

    methods: {
        async MontarURLRedirecionamento() {
            this.urlDespachar = "../Despacho?id=" + this.idManifestacao;
            this.urlCancelar = "../Despacho?id=" + this.idManifestacao;
        },
        CapturarDadosManifestacao(dadosBasicosManifestacao) {
            this.idManifestacao = dadosBasicosManifestacao.idManifestacao;
            console.log(dadosBasicosManifestacao.prazoResposta);
            this.prazoAtendimentoManifestacao = dadosBasicosManifestacao.prazoResposta;            
            this.MontarURLRedirecionamento();

            this.GerarDataPrazoResposta();            
        },
        GerarDataPrazoResposta() {
            let data = new Date();
            data.setDate(data.getDate() + PrazoEmDias);

            let fimAtendimento = new Date(utils.ConvertStringToDate(this.prazoAtendimentoManifestacao));            

            this.dataAtual = utils.DataDiaMesAno(new Date());
            utils.CriarDatePickerPorClasse(document.getElementsByClassName('data-eouv'), new Date(), fimAtendimento);
            this.prazoResposta = this.dataAtual;
        },

        IncluirCampoAnexo() {
            this.idCampoAnexo++;
            this.campoAnexo.push('file-' + (this.idCampoAnexo));
        },
        RemoverCampoAnexo(campo) {
            console.log(campo);
            this.campoAnexo = utils.RemoverItemArray(this.campoAnexo, campo);
        },
        async CarregarPapeisUsuario() {
            let ret = await eOuvApi.PapeisUsuarioEDocs();
            this.papeisUsuario = ret;
        },
        async Despachar(e) {

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


            //e.preventDefault();
            let entry = {
                IdManifestacao: this.idManifestacao,
                IdOrgao: 0,
                IdUsuarioSolicitacao: 0,
                PrazoResposta: this.prazoResposta,
                TextoDespacho: this.textoDespacho,
                FiltroDadosManifestacaoSelecionados: JSON.parse(JSON.stringify(this.dadosManifestacaoSelecionados)),
                GuidPapelDestinatario: this.destinatarioSelecionado,
                GuidPapelResponsavel: this.papelSelecionado
            }            
            console.log(entry);

            return false;
            //await eOuvApi.despachar(entry);
            /*            window.location.href = "/Despacho/AcompanharDespachos/" + this.idManifestacao;*/
        },
        GetDate(e) {
            this.prazoResposta = e.target.value;
        },
        ToggleDadosManifestacaoSelecionados(e) {
            console.log(e)
            let item = e.target.parentNode.id;
            this.dadosManifestacaoSelecionados[item] = !this.dadosManifestacaoSelecionados[item];

            for (var i in this.dadosManifestacaoSelecionados) {
                console.log(i + ': ' + this.dadosManifestacaoSelecionados[i]);
            }
        },
        TogglePapelSelecionado(e) {
            this.papelSelecionado = e.target.id;
            console.log('Papel Selecionado: ' + this.papelSelecionado);
        },
        IncluirDestinatarioSelecionado(destinatario) {
            console.log(destinatario);
            this.destinatarioSelecionado = destinatario.id;
        }
    }
};