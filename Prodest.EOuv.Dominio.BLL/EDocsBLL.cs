using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Shared.Util;
using Prodest.EOuv.Shared.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.BLL
{
    public class EDocsBLL : IEDocsBLL
    {
        private readonly IEDocsService _eDocsService;

        public EDocsBLL(IEDocsService eDocsService)
        {
            _eDocsService = eDocsService;
        }

        // ======================
        // public methods
        // ======================

        public async Task<EncaminhamentoModel> GetEncaminhamento(Guid id)
        {
            return await _eDocsService.GetEncaminhamento(id.ToString());
        }

        public async Task<string> GetDocumentoDownloadUrl(Guid id)
        {
            return await _eDocsService.GetDocumentoDownloadUrl(id.ToString());
        }

        public async Task<DocumentoModel> GetDocumento(string id)
        {
            return await _eDocsService.GetDocumento(id);
        }

        public async Task<DocumentoControladoModel[]> GetDocumentoEncaminhamento(string id)
        {
            return await _eDocsService.GetDocumentoEncaminhamento(id);
        }

        public async Task<EventoModel> GetEvento(string id)
        {
            return await _eDocsService.GetEvento(id);
        }

        public async Task<EncaminhamentoRastreioModel> GetRastreio(string idEncaminhamento)
        {
            return await _eDocsService.GetRastreio(idEncaminhamento);
        }

        public async Task<EncaminhamentoRastreioModel> GetRastreioCompleto(string idEncaminhamento)
        {
            return await _eDocsService.GetRastreioCompleto(idEncaminhamento);
        }

        public async Task<bool> EncontraDestinatario(string idEncaminhamentoRaiz, string[] idDestinatario)
        {
            return await _eDocsService.EncontraDestinatario(idEncaminhamentoRaiz, idDestinatario);
        }

        public async Task<string> GetProtocoloEncaminhamento(string idEncaminhamento)
        {
            return await _eDocsService.GetProtocoloEncaminhamento(idEncaminhamento);
        }

        public async Task<EncaminhamentoModel> GetEncaminhamentoPorProtocolo(string protocolo)
        {
            return await _eDocsService.GetEncaminhamentoPorProtocolo(protocolo);
        }

        public async Task<List<PatriarcaModel>> GetPatriarca()
        {
            return await _eDocsService.GetPatriarca();
        }

        public async Task<List<PatriarcaModel>> GetOrganizacoes(string id)
        {
            return await _eDocsService.GetOrganizacoes(id);
        }

        public async Task<List<PatriarcaSetorModel>> GetSetores(string idOrgao)
        {
            return await _eDocsService.GetSetores(idOrgao);
        }

        public async Task<List<PatriarcaSetorModel>> GetGrupoTrabalho(string idOrgao)
        {
            return await _eDocsService.GetGrupoTrabalho(idOrgao);
        }

        public async Task<List<PatriarcaSetorModel>> GetComissoes(string idOrgao)
        {
            return await _eDocsService.GetComissoes(idOrgao);
        }

        public async Task<List<PapelModel>> GetPapeis()
        {
            return await _eDocsService.GetPapeis();
        }

        public async Task<string> PostEncaminhamentoNovo(EncaminhamentoRequestModel parameters)
        {
            return await _eDocsService.PostEncaminhamentoNovo(parameters);
        }

        public async Task<PapelModel[]> GetUsuarioPapeisEncaminhamento(Guid id)
        {
            return await _eDocsService.GetUsuarioPapeisEncaminhamento(id.ToString());
        }

        public async Task<PlanoModel[]> GetPlanosAtivos(Guid id)
        {
            return await _eDocsService.GetPlanosAtivos(id.ToString());
        }

        public async Task<ClasseModel[]> GetClassesAtivas(Guid id)
        {
            return (await _eDocsService.GetClassesAtivas(id.ToString())).Where(x => x.Ativo).ToArray();
        }

        public async Task<FundamentoLegalModel[]> GetFundamentosLegais(Guid id)
        {
            return await _eDocsService.GetFundamentosLegais(id.ToString());
        }

        public async Task<GerarUrlModel> GetGerarUrl(int dataLength)
        {
            return await _eDocsService.GetGerarUrl(dataLength);
        }

        public async Task<string> PostTempUrlMinio(GerarUrlModel gerarUrl, byte[] data)
        {
            return await _eDocsService.PostTempUrlMinio(gerarUrl, data);
        }

        public async Task<string> PostDocumentoCapturarNatoDigitalCopiaServidor(DocumentoRequestModel parameters)
        {
            return await _eDocsService.PostDocumentoCapturarNatoDigitalCopiaServidor(parameters);
        }

        public async Task<PlanoModel[]> GetPlanosAtivos(string id)
        {
            return await _eDocsService.GetPlanosAtivos(id);
        }

        public async Task<FundamentoLegalModel[]> GetFundamentosLegais(string id)
        {
            return await _eDocsService.GetFundamentosLegais(id);
        }

        public async Task<ClasseModel[]> GetClassesAtivas(string id)
        {
            return await _eDocsService.GetClassesAtivas(id);
        }

        public async Task<AssinaturaDigitalValidaModel> PostAssinaturaDigitalValida(AssinaturaDigitalValidaModel model)
        {
            return await _eDocsService.PostAssinaturaDigitalValida(model);
        }

        public async Task<EventoModel> BuscarEvento(string id)
        {
            EventoModel task = await BuscarEventoConcluidoAsync(id);

            EventoModel evento = task;
            return evento;
        }

        private async Task<EventoModel> BuscarEventoConcluidoAsync(string id, int? tries = 30, int? delayMs = 1000)
        {
            var evento = new EventoModel();

            // realiza polling na API do E-Docs até que o Evento esteja disponível
            do
            {
                await Task.Delay(delayMs.Value);
                evento = await GetEvento(id);
                tries--;
            } while (evento.Situacao.ToUpper() != nameof(Enums.EventoSituacao.Concluido).ToUpper() && tries > 0);

            if (evento.Situacao.ToUpper() != nameof(Enums.EventoSituacao.Concluido).ToUpper() && tries == 0)
            {
                // caso o número máximo de tentativas seja extrapolado
                throw new EDocsApiException();
            }

            return evento;
        }

        #region [=== Capturar Documento ===]

        public async Task<string> CapturarDocumento(byte[] arquivo, string papelResponsavel, string nomeArquivo)
        {
            EventoModel evento = await BuscarEvento(await GetEventoDocumentoCapturarNatoDigitalCopiaServidor(arquivo, papelResponsavel, nomeArquivo)); //com o Id do evento descobrimos o Id do Documento
            return evento.IdDocumento;
        } //Retorna o Id do Documento

        public async Task<string> GetEventoDocumentoCapturarNatoDigitalCopiaServidor(byte[] arquivo, string papelResponsavel, string nomeArquivo)
        {
            string identificadorTemporarioArquivoNaNuvem = await EnviarArquivo(arquivo);

            DocumentoRequestModel parameters = new DocumentoRequestModel
            {
                IdPapelCapturador = papelResponsavel, //analista
                IdClasse = "b84db19f-7c05-44b8-9f07-9592e3a91f0a", //"01.01.05.01"
                ValorLegalDocumentoConferencia = Shared.Util.Enums.DocumentoValorLegal.CopiaSimples,
                ValorLegal = Shared.Util.Enums.DocumentoValorLegal.CopiaSimples,
                NomeArquivo = nomeArquivo,
                CredenciarCapturador = true,
                RestricaoAcesso = new RestricaoAcessoModel()
                {
                    TransparenciaAtiva = false,
                    IdsFundamentosLegais = new Guid[1] { new Guid("d4ecc485-d889-4e2f-848c-b2099b3412b7") }, //"Sigilo das Manifestações de Ouvidoria"
                    ClassificacaoInformacao = new ClassificacaoInformacaoModel()
                    {
                        PrazoAnos = 1,
                        PrazoMeses = 0,
                        PrazoDias = 0,
                        Justificativa = "Demanda de Ouvidoria",
                        IdPapelAprovador = papelResponsavel, //mesmo do capturador
                    }
                },
                IdentificadorTemporarioArquivoNaNuvem = identificadorTemporarioArquivoNaNuvem,
            };

            Task<string> task = PostDocumentoCapturarNatoDigitalCopiaServidor(parameters);
            Task.WaitAll(task);

            string result = task.Result;
            return result;
        }

        public async Task<string> EnviarArquivo(byte[] arquivo)
        {
            //string caminhoCompletoArquivoLocal = @"C:\Temp\TesteEDOCS.pdf";
            //FileInfo fi = new FileInfo(caminhoCompletoArquivoLocal);
            //int tamanhoArquivo = Convert.ToInt32(fi.Length);

            GerarUrlModel task = await GetGerarUrl(arquivo.Length);
            //byte[] readText = System.IO.File.ReadAllBytes(caminhoCompletoArquivoLocal);

            string task2 = await PostTempUrlMinio(task, arquivo);

            string result = task2;
            //IdentificadorTemporarioArquivoNaNuvem
            return result;
        }

        #endregion [=== Capturar Documento ===]

        #region [=== Encaminhamento ===]

        public async Task<string> EncaminharDocumento(string idDocumento, string assunto, string mensagem, string papelResponsavel, string papelDestinatario) //Retorna o Id do Encaminhamento
        {
            EventoModel evento = await BuscarEvento(await GetEventoEncaminhar(idDocumento, assunto, mensagem, papelResponsavel, papelDestinatario)); //com o Id do evento descobrimos o Id do Encaminhamento
            return evento.IdEncaminhamento;
        }

        public async Task<string> GetEventoEncaminhar(string idDocumento, string assunto, string mensagem, string papelResponsavel, string papelDestinatario) //Retorna o Id do Evento
        {
            var parametros = new EncaminhamentoRequestModel()
            {
                Assunto = assunto,
                Mensagem = mensagem,
                IdResponsavel = papelResponsavel,
                IdsDestinos = new string[] { papelDestinatario },
                IdsDocumentos = new string[] { idDocumento },
                RestricaoAcesso = new RestricaoAcessoModel()
                {
                    TransparenciaAtiva = false,
                    IdsFundamentosLegais = new Guid[1] { new Guid("d4ecc485-d889-4e2f-848c-b2099b3412b7") }, //"Sigilo das Manifestações de Ouvidoria"
                    ClassificacaoInformacao = new ClassificacaoInformacaoModel()
                    {
                        PrazoAnos = 1,
                        PrazoMeses = 0,
                        PrazoDias = 0,
                        Justificativa = "Demanda de Ouvidoria",
                        IdPapelAprovador = papelResponsavel, //mesmo do capturador
                    }
                },
            };

            Task<string> task = PostEncaminhamentoNovo(parametros);
            Task.WaitAll(task);

            string result = task.Result;
            return result;
        }

        #endregion [=== Encaminhamento ===]
    }
}