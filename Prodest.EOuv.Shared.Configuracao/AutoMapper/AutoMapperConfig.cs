using AutoMapper;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Infra.DAL;

namespace Prodest.EOuv.Shared.Configuracao
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<DespachoManifestacao, DespachoManifestacaoModel>().ReverseMap();
            //CreateMap<Manifestacao, ManifestacaoModel>().ReverseMap();
            //CreateMap<Orgao, OrgaoModel>().ReverseMap();
            //CreateMap<Setor, SetorModel>().ReverseMap();
            //CreateMap<Usuario, UsuarioModel>().ReverseMap();

            //CreateMap<Assunto, AssuntoModel>().ReverseMap();
            //CreateMap<CanalEntrada, CanalEntradaModel>().ReverseMap();
            //CreateMap<ModoResposta, ModoRespostaModel>().ReverseMap();
            //CreateMap<Pessoa, PessoaJuridicaModel>().ReverseMap();
            //CreateMap<Pessoa, PessoaModel>().ReverseMap();
            //CreateMap<ResultadoResposta, ResultadoRespostaModel>().ReverseMap();
            //CreateMap<SituacaoManifestacao, SituacaoManifestacaoModel>().ReverseMap();
            //CreateMap<TipoIdentificacao, TipoIdentificacaoModel>().ReverseMap();
            //CreateMap<TipoManifestacao, TipoManifestacaoModel>().ReverseMap();
            //CreateMap<TipoManifestante, TipoManifestanteModel>().ReverseMap();
            //CreateMap<Perfil, PerfilModel>().ReverseMap();
        }
    }
}