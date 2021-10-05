const DespachoForm = {

    name: 'DespachoForm',
    template: '#template-despacho-form',

    data() {
        return {
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
                dataRegistro: '',
                prazoRegistro: '',
                usuarioCadastrador: '',
                canalEntrada: '',
                modoResposta: ''
            },
            teorManifestacao: {
                textoManifestacao: '',
                localFato: ''
            }
            ,
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
            dadosResposta: [{
                dataResposta: '',
                orgao: {
                    nomeFantasia: '',
                    siglaOrgao: ''
                },
                txtResposta: '',
                responsavel: '',
                anexos: [{
                    nomeArquivo: '',
                    extensao: '',
                    tamanho: '',
                    bytes:[]
                }]
            }],
            dadosDespacho: [{
                orgao: {
                    nomeFantasia: '',
                    siglaOrgao: ''                    
                },
                siglaSetorDestinatarioEdocs: '',
                dataRespostaDespacho: '',
                txtDespacho: '',
                usuario: '',
                statusDespacho: ''
            }],
            dadosNotificacao: [{
                dataNotificacao: '',
                orgao: {
                    nomeFantasia: '',
                    siglaOrgao: ''
                },
                txtNotificacao: '',
                usuario: '',
                anexos: [{
                    nomeArquivo: '',
                    extensao: '',
                    tamanho: '',
                    bytes: []
                }]
            }],
            dadosReclamacao: [{
                dataReclamacao: '',
                manifestacaoOriginal: '',
                ManifestacaoReclamacao:''
            }],
        }
    },

    async mounted() {
        await this.obterManifestacao();
    },

    methods: {
        async obterManifestacao() {
            let ret = await eOuvApi.novoDespacho();            
            console.log(ret);
            //Dados Basicos da Manifestacao
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

            //Teor da Manifestacao
            this.teorManifestacao.textoManifestacao = ret.textoManifestacao;
            this.teorManifestacao.localFato = ret.localFato;

            //Dados Manifestante
            this.dadosManifestante.nome = ret.dadosManifestante.nome;
            this.dadosManifestante.cpf = ret.dadosManifestante.cpf;
            this.dadosManifestante.genero = ret.dadosManifestante.genero;
            this.dadosManifestante.telefone = ret.dadosManifestante.telefone;
            this.dadosManifestante.email = ret.dadosManifestante.email;
            this.dadosManifestante.tipoManifestante = ret.dadosManifestante.tipoManifestante;
            this.dadosManifestante.cnpj = ret.dadosManifestante.cnpj;
            this.dadosManifestante.orgaoEmpresa = ret.dadosManifestante.orgaoEmpresa;
            this.dadosManifestante.cep = ret.dadosManifestante.cep;
            this.dadosManifestante.municipio = ret.dadosManifestante.municipio;
            this.dadosManifestante.uf = ret.dadosManifestante.uf;
            this.dadosManifestante.logradouro = ret.dadosManifestante.logradouro;
            this.dadosManifestante.numero = ret.dadosManifestante.numero;
            this.dadosManifestante.complemento = ret.dadosManifestante.complemento;
            this.dadosManifestante.bairro = ret.dadosManifestante.bairro;
        }
    }
}



let app = VueFactory.createApp();
app.component('despacho-form', DespachoForm)
app.mount('#app');