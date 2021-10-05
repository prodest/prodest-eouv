using System;

#nullable disable

namespace Prodest.EOuv.Dominio.Modelo
{
    public partial class AtendimentoImediatoModel
    {
        public int IdAtendimentoImediato { get; set; }
        public DateTime DatAtendimento { get; set; }
        public string NomeManifestante { get; set; }
        public string SexoManifestante { get; set; }
        public int IdTipoManifestacao { get; set; }
        public int? IdTipoManifestante { get; set; }
        public int IdUsuarioCadastrador { get; set; }
        public int IdAssunto { get; set; }
        public int IdCanalEntrada { get; set; }
        public string TeorDemanda { get; set; }
        public string RespostaFornecida { get; set; }
        public DateTime DataRegistro { get; set; }
        public int? IdMunicipio { get; set; }

        public virtual AssuntoModel Assunto { get; set; }
        public virtual CanalEntradaModel CanalEntrada { get; set; }
        public virtual TipoManifestacaoModel TipoManifestacao { get; set; }
        public virtual TipoManifestanteModel TipoManifestante { get; set; }
        public virtual UsuarioModel UsuarioCadastrador { get; set; }
    }
}