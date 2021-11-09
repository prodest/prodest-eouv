const DespachoManifestacao = {
    name: 'DespachoManifestacao',
    mixins: [BaseMixin],
    template: '#template-despacho-manifestacao',
    emits: ['selecionar-dado-manifestacao', 'capturar-dados-manifestacao'],

    data() {
        return {
            titulo: 'Manifestação',
            idManifestacao: '',
            dadosBasicos: {
                idManifestacao: null,
                numProtocolo: '',
                tipoManifestacao: '',
                situacao: '',
                orgaoAtual: {
                    nomeFantasia: '',
                    siglaOrgao: ''
                },
                orgaoDestinatario: {
                    nomeFantasia: '',
                    siglaOrgao: ''
                },
                assunto: '',
                dataRegistro: '',
                prazoResposta: '',
                usuarioCadastrador: '',
                canalEntrada: '',
                modoResposta: ''
            },
            teorManifestacao: {
                textoManifestacao: '',
                localFato: ''
            },
            dadosManifestante: {
                nome: '',
                cpf: '',
                genero: '',
                telefone: '',
                email: '',
                tipoManifestante: '',
                cnpj: '',
                orgaoEmpresa: '',
                cep: '',
                municipio: '',
                uf: '',
                logradouro: '',
                numero: '',
                complemento: '',
                bairro: ''
            },
            anexoManifestacao: [],
            anotacaoManifestacao: [],
            apuracaoManifestacao: [],
            complementoManifestacao: [],
            desdobramentoManifestacao: [],
            despachoManifestacao: [],
            diligenciaManifestacao: [],
            encaminhamentoManifestacao: [],
            historicoManifestacao: [],
            interpelacaoManifestacao: [],
            notificacaoManifestacao: [],
            prorrogacaoManifestacao: [],
            reclamacaoOmissao: [],
            recursoNegativa: [],
            respostaManifestacao: []
        }
    },

    async mounted() {
        this.ObterParametrosQueryString();
        await this.obterManifestacao();
    },

    methods: {
        ObterParametrosQueryString() {
            this.idManifestacao = utils.obterRequestParameter('id')
        },

        async obterManifestacao() {

            await this.setLoadingAndExecute(async () => {

                let jsonReturn = await eOuvApi.ObterDadosCompletosManifestacao(this.idManifestacao);
                console.log(jsonReturn);

                let ret = jsonReturn.retorno;
                //Dados Basicos da Manifestacao
                this.titulo += ` - ${ret.numProtocolo}`;
                this.dadosBasicos.idManifestacao = ret.idManifestacao;
                this.dadosBasicos.numProtocolo = ret.numProtocolo;
                this.dadosBasicos.tipoManifestacao = ret.tipoManifestacao.descTipoManifestacao;
                this.dadosBasicos.situacao = ret.situacaoManifestacao.descSituacaoManifestacao;
                this.dadosBasicos.orgaoAtual.nomeFantasia = ret.orgaoResponsavel.nomeFantasia;
                this.dadosBasicos.orgaoAtual.siglaOrgao = ret.orgaoResponsavel.siglaOrgao;
                this.dadosBasicos.orgaoDestinatario.nomeFantasia = ret.orgaoInteresse.nomeFantasia;
                this.dadosBasicos.orgaoDestinatario.siglaOrgao = ret.orgaoInteresse.siglaOrgao;
                this.dadosBasicos.usuarioCadastrador = ret.registradoPorFormat;
                this.dadosBasicos.canalEntrada = ret.canalEntrada.descCanalEntrada;
                this.dadosBasicos.modoResposta = ret.modoResposta.descModoResposta;
                this.dadosBasicos.assunto = ret.assunto.descAssunto;
                this.dadosBasicos.dataRegistro = ret.dataRegistroFormat;
                this.dadosBasicos.prazoResposta = ret.prazoRespostaFormat;
                this.dadosBasicos.tipoManifestante = ret.tipoManifestante != null ? ret.tipoManifestante.descTipoManifestante : "";

                this.$emit('capturar-dados-manifestacao', this.dadosBasicos);

                //Teor da Manifestacao
                this.PreencherTeorManifestacao(ret.textoManifestacao, ret.municipioLocalFatoFormat);

                //Dados do Manifestante
                if (ret.tipoManifestante != null) {
                    this.PreencherDadosManifestante(ret.pessoa);
                }

                //Dados Complementos
                ret.complementoManifestacao?.forEach(this.PreencherComplementoManifestacao);

                //Dados Anexos
                ret.anexoManifestacao?.forEach(this.PreencherAnexoManifestacao);

                //Dados Prorrogação
                ret.prorrogacaoManifestacao?.forEach(this.PreencherProrrogacaoManifestacao);

                //Dados Diligência
                ret.diligenciaManifestacao?.forEach(this.PreencherDiligenciaManifestacao);

                //Dados Encaminhamentos
                ret.encaminhamentoManifestacao?.forEach(this.PreencherEncaminhamentoManifestacao);

                //Dados da Resposta
                ret.respostaManifestacao?.forEach(this.PreencherRespostaManifestacao)

                //Dados Apuração
                ret.apuracaoManifestacao?.forEach(this.PreencherApuracaoManifestacao);

                //Dados Despacho
                ret.despachoManifestacao?.forEach(this.PreencherDespachoManifestacao);

                //Dados Notificações
                ret.notificacaoManifestacao?.forEach(this.PreencherNotificacoes);

                //Dados Anotações
                ret.anotacaoManifestacao?.forEach(this.PreencherAnotacaoManifestacao);

                //Dados Interpelação
                ret.interpelacaoManifestacao?.forEach(this.PreencherInterpelacaoManifestacao);

                //Dados Reclamação de Omissão
                ret.reclamacaoOmissao?.forEach(this.PreencherReclamacaoOmissao);

                //Dados Recurso Negativa
                ret.recursoNegativa?.forEach(this.PreencherRecursoNegativa);

                //Dados Desdrobramento
                ret.desdobramentoManifestacao?.forEach(this.PreencherDesdobramentoManifestacao);

                //Dados de Histórico
                ret.historicoManifestacao?.forEach(this.PreencherHistoricoManifestacao);

            });


        },

        async PreencherTeorManifestacao(txtManifestacao, local) {
            //Dados da Manifestante
            this.teorManifestacao.textoManifestacao = txtManifestacao;
            this.teorManifestacao.localFato = local;
        },

        async PreencherDadosManifestante(item) {
            //Dados da Manifestante
            this.dadosManifestante.nome = item.nome;
            this.dadosManifestante.cpf = item.cpf;
            this.dadosManifestante.genero = item.sexoFormat;
            this.dadosManifestante.telefone = item.telefone;
            this.dadosManifestante.email = item.email;
            this.dadosManifestante.cnpj = item.cnpj;
            this.dadosManifestante.orgaoEmpresa = item.orgaoEmpresa;
            this.dadosManifestante.cep = item.cep;
            this.dadosManifestante.municipio = item.municipio.descMunicipio;
            this.dadosManifestante.uf = item.municipio.uf.descUf;
            this.dadosManifestante.logradouro = item.logradouro;
            this.dadosManifestante.numero = item.numero;
            this.dadosManifestante.complemento = item.complemento;
            this.dadosManifestante.bairro = item.bairro;
        },

        async PreencherComplementoManifestacao(item) {
            this.complementoManifestacao.push(item);
        },

        async PreencherAnexoManifestacao(item) {
            this.anexoManifestacao.push(item);
        },

        async PreencherProrrogacaoManifestacao(item) {
            this.prorrogacaoManifestacao.push(item);
        },

        async PreencherDiligenciaManifestacao(item) {
            this.diligenciaManifestacao.push(item);
        },

        async PreencherEncaminhamentoManifestacao(item) {
            this.encaminhamentoManifestacao.push(item);
        },

        async PreencherRespostaManifestacao(item,) {
            this.respostaManifestacao.push(item);
        },

        async PreencherApuracaoManifestacao(item) {
            this.apuracaoManifestacao.push(item);
        },

        async PreencherDespachoManifestacao(item) {
            this.despachoManifestacao.push(item);
        },

        async PreencherNotificacoes(item) {
            this.notificacaoManifestacao.push(item);
        },

        async PreencherAnotacaoManifestacao(item) {
            this.anotacaoManifestacao.push(item);
        },

        async PreencherInterpelacaoManifestacao(item) {
            this.interpelacaoManifestacao.push(item);
        },

        async PreencherReclamacaoOmissao(item) {
            this.reclamacaoOmissao.push(item);
        },

        async PreencherRecursoNegativa(item) {
            this.recursoNegativa.push(item);
        },

        async PreencherDesdobramentoManifestacao(item) {
            this.desdobramentoManifestacao.push(item);
        },

        async PreencherHistoricoManifestacao(item) {
            this.historicoManifestacao.push(item);
        },

        IncluirDocumento(e) {
            e.stopImmediatePropagation();

            this.ToggleCheck(e);
            this.$emit('selecionar-dado-manifestacao', e);

            if (e.target.classList.contains("fa-check-square")) {
                console.log('Documento Incluso!');
            } else {
                console.log('Documento Removido!');
            }
        },

        ToggleCheck(e) {
            e.target.classList.toggle('fa-square');
            e.target.classList.toggle('fa-check-square');
        },
    }
};