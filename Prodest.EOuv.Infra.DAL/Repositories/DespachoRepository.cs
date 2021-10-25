using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Model;
using Prodest.EOuv.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Prodest.EOuv.Shared.Util.Enums;

namespace Prodest.EOuv.Infra.DAL
{
    public class DespachoRepository : IDespachoRepository
    {
        private readonly EouvContext _eouvContext;
        private readonly IMapper _mapper;
        private readonly IAcessoCidadaoBLL _AcessoCidadaoBLL;

        public DespachoRepository(EouvContext context, IMapper mapper, IAcessoCidadaoBLL acessoCidadaoBLL)
        {
            _eouvContext = context;
            _mapper = mapper;
            _AcessoCidadaoBLL = acessoCidadaoBLL;
        }

        public async Task<List<DespachoManifestacaoModel>> ObterDespachoPorManifestacao(int idManifestacao)
        {
            var despachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdManifestacao == idManifestacao).AsNoTracking().ToListAsync();
            return _mapper.Map<List<DespachoManifestacaoModel>>(despachoManifestacao);
        }

        public async Task<DespachoManifestacaoModel> ObterDespacho(int IdDespachoManifestacao)
        {
            var despachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdDespachoManifestacao == IdDespachoManifestacao).AsNoTracking().FirstOrDefaultAsync();            
            return _mapper.Map<DespachoManifestacaoModel>(despachoManifestacao);
        }

        public async Task<DespachoManifestacaoModel> ObterDespachoEDestinatario(int IdDespachoManifestacao)
        {
            var despachoManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.IdDespachoManifestacao == IdDespachoManifestacao)
                                                                              .Include(d => d.AgenteDestinatario)
                                                                              .AsNoTracking()
                                                                              .FirstOrDefaultAsync();            
            return _mapper.Map<DespachoManifestacaoModel>(despachoManifestacao);
        }

        public async Task<List<int>> ObterDespachosEmAberto()
        {
            var idManifestacao = await _eouvContext.DespachoManifestacao.Where(d => d.Situacao == nameof(Enums.SituacaoDespacho.Aberto))
                                                                              .Select(d => d.IdDespachoManifestacao)
                                                                              .ToListAsync();            
            var retorno = _mapper.Map<List<int>>(idManifestacao);
            return retorno;
        }

        public async Task<int> AdicionaAtor( AgenteManifestacaoModel agente)
        {
            try
            {
                var agenteManifestacao = _mapper.Map<AgenteManifestacao>(agente);
                _eouvContext.AgenteManifestacao.Add(agenteManifestacao);
                await _eouvContext.SaveChangesAsync();
                return agenteManifestacao.IdAgenteManifestacao;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task AtualizaDespacho(DespachoManifestacaoModel despachoManifestacao)
        {            
            _eouvContext.Update(_mapper.Map<DespachoManifestacao>(despachoManifestacao));
            await _eouvContext.SaveChangesAsync();            
        }

        public async Task ResponderDespacho(int idDespacho, AgenteManifestacaoModel atorResposta)
        {
            var despachoManifestacao = await ObterDespacho(idDespacho);

            despachoManifestacao.Situacao = nameof(Enums.SituacaoDespacho.Respondido);
            despachoManifestacao.AgenteResposta = atorResposta;
            //salva ator resposta
            _eouvContext.Add(_mapper.Map<AgenteManifestacao>(atorResposta));
            _eouvContext.Update(_mapper.Map<DespachoManifestacao>(despachoManifestacao));
            await _eouvContext.SaveChangesAsync();            
        }
        public async Task<SetorModel> BuscaSetor(string idSetor)
        {
            var setor = await _eouvContext.Setor
                                    .Include(m => m.Orgao)
                                    //.Include(m => m.Orgao.Patriaca)
                                    .Where(d => d.GuidSetor == new Guid(idSetor)).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<SetorModel>(setor);            
        }

        public async Task AdicionarDespacho(DespachoManifestacaoModel despachoManifestacao)
        {
            _eouvContext.Add(_mapper.Map<DespachoManifestacao>(despachoManifestacao));
            await _eouvContext.SaveChangesAsync();
        }

        public async Task AdicionarAgenteResposta(AgenteManifestacaoModel agenteResposta)
        {
            _eouvContext.Add(_mapper.Map<AgenteManifestacao>(agenteResposta));
            await _eouvContext.SaveChangesAsync();
        }

        public async Task<AgenteManifestacaoModel> montaAgente(string idAgente, int tipoAgente)
        {
            AgentePublicoPapelModel papel = await _AcessoCidadaoBLL.GetPapel(new Guid(idAgente));
            SetorModel setor = null;
            if (papel != null && !String.IsNullOrEmpty(papel.LotacaoGuid))
            {
                setor = await BuscaSetor(papel.LotacaoGuid);
            }
            AgenteManifestacaoModel AgenteResposta = new AgenteManifestacaoModel
            {
                GuidPapel = new Guid(idAgente),
                NomePapel = papel.Nome,
                GuidUsuario = papel.AgentePublicoSub,
                NomeUsuario = papel.AgentePublicoNome,
                GuidSetor = new Guid(papel.LotacaoGuid),
                Tipo = (byte)tipoAgente
            };
            if (setor is not null)
            {
                AgenteResposta.NomeSetor = setor.NomeSetor;
                AgenteResposta.SiglaSetor = setor.SiglaSetor;
                AgenteResposta.GuidOrgao = setor.Orgao.GuidOrgao;
                AgenteResposta.NomeOrgao = setor.Orgao.RazaoSocial;
                AgenteResposta.SiglaOrgao = setor.Orgao.SiglaOrgao;
                /*
                AgenteResposta.GuidPatriarca = setor.Orgao.Patriaca.Guid;
                AgenteResposta.NomePatriarca = setor.Orgao.Patriaca.RazaoSocial;
                AgenteResposta.SiglaPatriarca = setor.Orgao.Patriaca.Sigla;
                */
                AgenteResposta.GuidPatriarca = new Guid("fe88eb2a-a1f3-4cb1-a684-87317baf5a57");
                AgenteResposta.NomePatriarca = "ESTADO DO ESPIRITO SANTO";
                AgenteResposta.SiglaPatriarca = "GOVES";
            }
            return AgenteResposta;
        }

    }
}