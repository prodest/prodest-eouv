const DespachoManifestacao = {
    name: 'DespachoManifestacao',
    template: '#template-despacho-manifestacao',

    data() {
        return {
            titulo: 'Manifestação',
            dadosBasicos: {
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
        await this.obterManifestacao();
    },

    methods: {
        async obterManifestacao() {
            let ret = await eOuvApi.obterDadosManifestacao();
            console.log(ret);
            //Dados Basicos da Manifestacao
            this.titulo += ` (${ret.numProtocolo})`;
            this.dadosBasicos.numProtocolo = ret.numProtocolo;
            this.dadosBasicos.tipoManifestacao = ret.tipoManifestacao;
            this.dadosBasicos.situacao = ret.situacao;
            this.dadosBasicos.orgaoAtual.nomeFantasia = ret.orgaoAtual.nomeFantasia;
            this.dadosBasicos.orgaoAtual.siglaOrgao = ret.orgaoAtual.siglaOrgao;
            this.dadosBasicos.orgaoDestinatario.nomeFantasia = ret.orgaoDestinatario.nomeFantasia;
            this.dadosBasicos.orgaoDestinatario.siglaOrgao = ret.orgaoDestinatario.siglaOrgao;
            this.dadosBasicos.usuarioCadastrador = ret.usuarioCadastrador;
            this.dadosBasicos.canalEntrada = ret.canalEntrada;
            this.dadosBasicos.modoResposta = ret.modoResposta;
            this.dadosBasicos.assunto = ret.assunto;
            this.dadosBasicos.dataRegistro = ret.dataRegistro;
            this.dadosBasicos.prazoResposta = ret.prazoResposta;

            //Teor da Manifestacao
            this.PreencheTeorManifestacao(ret.textoManifestacao, ret.localFato);

            //Dados do Manifestante
            this.PreencherDadosManifestante(ret.dadosManifestante);

            //Dados de Histórico
            ret.historicoManifestacao.forEach(this.PreencherHistoricoManifestacao);

            //Dados da Resposta
            ret.respostaManifestacao.forEach(this.PreencherRespostaManifestacao)

            //Dados Despacho
            ret.despachoManifestacao.forEach(this.PreencherDespachoManifestacao);

            //Dados Prorrogação
            ret.prorrogacaoManifestacao.forEach(this.PreencherProrrogacaoManifestacao);

            //Dados Encaminhamentos
            ret.encaminhamentoManifestacao.forEach(this.PreencherEncaminhamentoManifestacao);

            //Dados Notificações
            ret.notificacaoManifestacao.forEach(this.PreencherNotificacoes);

            //Dados Anotações
            ret.anotacaoManifestacao.forEach(this.PreencherAnotacaoManifestacao);

            //Dados Anotações
            ret.diligenciaManifestacao.forEach(this.PreencherDiligenciaManifestacao);

            //Dados Apuração
            ret.apuracaoManifestacao.forEach(this.PreencherApuracaoManifestacao);

            //Dados Complementos
            ret.complementoManifestacao.forEach(this.PreencherComplementoManifestacao);

            //Dados Anexos
            ret.anexoManifestacao.forEach(this.PreencherAnexoManifestacao);
        },

        async PreencheTeorManifestacao(txtManifestacao, local) {
            //Dados da Manifestante
            this.teorManifestacao.textoManifestacao = txtManifestacao;
            this.teorManifestacao.localFato = local;
        },

        async PreencherDadosManifestante(item) {
            //Dados da Manifestante
            this.dadosManifestante.nome = item.nome;
            this.dadosManifestante.cpf = item.cpf;
            this.dadosManifestante.genero = item.genero;
            this.dadosManifestante.telefone = item.telefone;
            this.dadosManifestante.email = item.email;
            this.dadosManifestante.tipoManifestante = item.tipoManifestante;
            this.dadosManifestante.cnpj = item.cnpj;
            this.dadosManifestante.orgaoEmpresa = item.orgaoEmpresa;
            this.dadosManifestante.cep = item.cep;
            this.dadosManifestante.municipio = item.municipio;
            this.dadosManifestante.uf = item.uf;
            this.dadosManifestante.logradouro = item.logradouro;
            this.dadosManifestante.numero = item.numero;
            this.dadosManifestante.complemento = item.complemento;
            this.dadosManifestante.bairro = item.bairro;
        },

        async PreencherRespostaManifestacao(item,) {
            this.respostaManifestacao.push(item);
        },

        async PreencherDespachoManifestacao(item) {
            this.despachoManifestacao.push(item);
        },

        async PreencherNotificacoes(item) {
            this.notificacaoManifestacao.push(item);
        },

        async PreencheReclamacaoOmissao(item) {
            this.reclamacaoOmissao.push(item);
        },

        async PreencheRecursoNegativa(item) {
            this.recursoNegativa.push(item);
        },

        async PreencheReclamacaoOmissao(item) {
            this.reclamacaoOmissao.push(item);
        },

        async PreencherProrrogacaoManifestacao(item) {
            this.prorrogacaoManifestacao.push(item);
        },

        async PreencheInterpelacaoManifestacao(item) {
            this.interpelacaoManifestacao.push(item);
        },

        async PreencherAnotacaoManifestacao(item) {
            this.anotacaoManifestacao.push(item);
        },

        async PreencherAnexoManifestacao(item) {
            this.anexoManifestacao.push(item);
        },

        async PreencherApuracaoManifestacao(item) {
            this.apuracaoManifestacao.push(item);
        },

        async PreencherComplementoManifestacao(item) {
            this.complementoManifestacao.push(item);
        },

        async PreencherDesdobramentoManifestacao(item) {
            this.desdobramentoManifestacao.push(item);
        },

        async PreencherDiligenciaManifestacao(item) {
            this.diligenciaManifestacao.push(item);
        },

        async PreencherEncaminhamentoManifestacao(item) {
            this.encaminhamentoManifestacao.push(item);
        },

        async PreencherHistoricoManifestacao(item) {
            this.historicoManifestacao.push(item);
        },

        IncluirDocumento(e) {
            this.ToggleCheck(e);
            console.log(e);

            if (e.target.classList.contains("fa-check-square")) {
                console.log('Documento Incluso!');
            } else {
                console.log('Documento Removido!');
            }
        },

        ToggleCheck(e) {
            e.target.classList.toggle('fa-square');
            e.target.classList.toggle('fa-check-square');
        }
    }
};