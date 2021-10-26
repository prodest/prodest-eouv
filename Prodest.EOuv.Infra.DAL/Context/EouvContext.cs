using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class EouvContext : AuditDbContext
    {
        private readonly IConfiguration _configuration;

        public EouvContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public virtual DbSet<AgenteManifestacao> AgenteManifestacao { get; set; }
        public virtual DbSet<AnexoManifestacao> AnexoManifestacao { get; set; }
        public virtual DbSet<AnotacaoManifestacao> AnotacaoManifestacao { get; set; }
        public virtual DbSet<ApuracaoManifestacao> ApuracaoManifestacao { get; set; }
        public virtual DbSet<ArquivamentoManifestacao> ArquivamentoManifestacao { get; set; }
        public virtual DbSet<ArquivoFisicoAnexoManifestacao> ArquivoFisicoAnexoManifestacao { get; set; }
        public virtual DbSet<Assunto> Assunto { get; set; }
        public virtual DbSet<AtendimentoImediato> AtendimentoImediato { get; set; }
        public virtual DbSet<CanalEntrada> CanalEntrada { get; set; }
        public virtual DbSet<ComplementoManifestacao> ComplementoManifestacao { get; set; }
        public virtual DbSet<DesdobramentoManifestacao> DesdobramentoManifestacao { get; set; }
        public virtual DbSet<DespachoManifestacao> DespachoManifestacao { get; set; }
        public virtual DbSet<DiligenciaManifestacao> DiligenciaManifestacao { get; set; }
        public virtual DbSet<EncaminhamentoManifestacao> EncaminhamentoManifestacao { get; set; }
        public virtual DbSet<Feriado> Feriado { get; set; }
        public virtual DbSet<HistoricoManifestacao> HistoricoManifestacao { get; set; }
        public virtual DbSet<InterpelacaoManifestacao> InterpelacaoManifestacao { get; set; }
        public virtual DbSet<ItemInterface> ItemInterface { get; set; }
        public virtual DbSet<ItemInterfacePerfil> ItemInterfacePerfil { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<LogAcesso> LogAcesso { get; set; }
        public virtual DbSet<Manifestacao> Manifestacao { get; set; }
        public virtual DbSet<ModoResposta> ModoResposta { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<NotificacaoManifestacao> NotificacaoManifestacao { get; set; }
        public virtual DbSet<Orgao> Orgao { get; set; }
        public virtual DbSet<Ouvidoria> Ouvidoria { get; set; }
        public virtual DbSet<OuvidoriaOrgao> OuvidoriaOrgao { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PesquisaSatisfacao> PesquisaSatisfacao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<PessoaJuridica> PessoaJuridica { get; set; }
        public virtual DbSet<ProrrogacaoManifestacao> ProrrogacaoManifestacao { get; set; }
        public virtual DbSet<ReclamacaoOmissao> ReclamacaoOmissao { get; set; }
        public virtual DbSet<RecursoNegativa> RecursoNegativa { get; set; }
        public virtual DbSet<RespostaManifestacao> RespostaManifestacao { get; set; }
        public virtual DbSet<ResultadoResposta> ResultadoResposta { get; set; }
        public virtual DbSet<ResultadoRespostaTipologia> ResultadoRespostaTipologia { get; set; }
        public virtual DbSet<Setor> Setor { get; set; }
        public virtual DbSet<SituacaoDespacho> SituacaoDespacho { get; set; }
        public virtual DbSet<SituacaoInterpelacao> SituacaoInterpelacao { get; set; }
        public virtual DbSet<SituacaoManifestacao> SituacaoManifestacao { get; set; }
        public virtual DbSet<TipoAnexoManifestacao> TipoAnexoManifestacao { get; set; }
        public virtual DbSet<TipoIdentificacao> TipoIdentificacao { get; set; }
        public virtual DbSet<TipoItemInterface> TipoItemInterface { get; set; }
        public virtual DbSet<TipoManifestacao> TipoManifestacao { get; set; }
        public virtual DbSet<TipoManifestante> TipoManifestante { get; set; }
        public virtual DbSet<Uf> Uf { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<AgenteManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdAgenteManifestacao)
                    .HasName("PK_Ouvidoria.AgenteManifestacao");

                entity.ToTable("AgenteManifestacao", "Ouvidoria");

                entity.Property(e => e.GuidUsuario)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeOrgao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomePapel)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomePatriarca)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeSetor)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SiglaOrgao)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SiglaPatriarca)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SiglaSetor)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AnexoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdAnexoManifestacao)
                    .HasName("PK__AnexoMan__5E4CDC381367E606");

                entity.ToTable("AnexoManifestacao", "Ouvidoria");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DatPostagem).HasColumnType("datetime");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.AnexoManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnexoManifestacao_Manifestacao");

                entity.HasOne(d => d.TipoAnexoManifestacao)
                    .WithMany(p => p.AnexoManifestacao)
                    .HasForeignKey(d => d.IdTipoAnexoManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnexoManifestacao_TipoAnexoManifestacao");
            });

            modelBuilder.Entity<AnotacaoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdAnotacaoManifestacao)
                    .HasName("PK_Ouvidoria.AnotacaoManifestacao");

                entity.ToTable("AnotacaoManifestacao", "Ouvidoria");

                entity.Property(e => e.DataAnotacao).HasColumnType("datetime");

                entity.Property(e => e.TxtAnotacao)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.AnotacaoManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnotacaoManifestacao_Manifestacao");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.AnotacaoManifestacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.AnotacaoManifestacaoUsuario_IdUsuario");
            });

            modelBuilder.Entity<ApuracaoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdApuracaoManifestacao)
                    .HasName("PK_Ouvidoria.ApuracaoManifestacao");

                entity.ToTable("ApuracaoManifestacao", "Ouvidoria");

                entity.Property(e => e.DataRespostaApuracao).HasColumnType("datetime");

                entity.Property(e => e.DataSolicitacaoApuracao).HasColumnType("datetime");

                entity.Property(e => e.TxtRespostaApuracao).IsUnicode(false);

                entity.Property(e => e.TxtSolicitacaoApuracao)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.ApuracaoManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApuracaoManifestacao_Manifestacao");

                entity.HasOne(d => d.OrgaoDestino)
                    .WithMany(p => p.ApuracaoManifestacaoOrgaoDestino)
                    .HasForeignKey(d => d.IdOrgaoDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApuracaoManifestacao_OrgaoDestino");

                entity.HasOne(d => d.OrgaoOrigem)
                    .WithMany(p => p.ApuracaoManifestacaoOrgaoOrigem)
                    .HasForeignKey(d => d.IdOrgaoOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApuracaoManifestacao_OrgaoOrigem");

                entity.HasOne(d => d.UsuarioRespostaApuracao)
                    .WithMany(p => p.ApuracaoManifestacaoUsuarioRespostaApuracao)
                    .HasForeignKey(d => d.IdUsuarioRespostaApuracao)
                    .HasConstraintName("FK_Ouvidoria.ApuracaoManifestacaoUsuario_IdUsuarioRespostaApuracao");

                entity.HasOne(d => d.UsuarioSolicitacaoApuracao)
                    .WithMany(p => p.ApuracaoManifestacaoUsuarioSolicitacaoApuracao)
                    .HasForeignKey(d => d.IdUsuarioSolicitacaoApuracao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.ApuracaoManifestacaoUsuario_IdUsuarioSolicitacaoApuracao");
            });

            modelBuilder.Entity<ArquivamentoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdArquivamentoManifestacao)
                    .HasName("PK_Ouvidoria.ArquivamentoManifestacao");

                entity.ToTable("ArquivamentoManifestacao", "Ouvidoria");

                entity.Property(e => e.DataArquivamento).HasColumnType("datetime");

                entity.Property(e => e.TxtJustificativaArquivamento)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.ArquivamentoManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArquivamentoManifestacao_Manifestacao");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ArquivamentoManifestacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.ArquivamentoManifestacaoUsuario_IdUsuario");
            });

            modelBuilder.Entity<ArquivoFisicoAnexoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdArquivoFisicoAnexoManifestacao)
                    .HasName("PK__ArquivoF__FD53FC111B0907CE");

                entity.ToTable("ArquivoFisicoAnexoManifestacao", "Ouvidoria");

                entity.Property(e => e.Conteudo).IsRequired();

                entity.HasOne(d => d.AnexoManifestacao)
                    .WithMany(p => p.ArquivoFisicoAnexoManifestacao)
                    .HasForeignKey(d => d.IdAnexoManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArquivoFisicoAnexoManifestacao_AnexoManifestacao");
            });

            modelBuilder.Entity<Assunto>(entity =>
            {
                entity.HasKey(e => e.IdAssunto)
                    .HasName("PK__Assunto__979CBB4820C1E124");

                entity.ToTable("Assunto", "Ouvidoria");

                entity.HasIndex(e => e.DescAssunto, "UQ__Assunto__4A421E561BC821DD")
                    .IsUnique();

                entity.Property(e => e.DescAssunto)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.IndAssuntoSic).HasColumnName("IndAssuntoSIC");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AtendimentoImediato>(entity =>
            {
                entity.HasKey(e => e.IdAtendimentoImediato)
                    .HasName("PK__Atendime__58D86D926A1BB7B0");

                entity.ToTable("AtendimentoImediato", "Ouvidoria");

                entity.Property(e => e.DatAtendimento).HasColumnType("datetime");

                entity.Property(e => e.DataRegistro).HasColumnType("datetime");

                entity.Property(e => e.NomeManifestante)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RespostaFornecida)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.SexoManifestante)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TeorDemanda)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Assunto)
                    .WithMany(p => p.AtendimentoImediato)
                    .HasForeignKey(d => d.IdAssunto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtendimentoImediato_Assunto");

                entity.HasOne(d => d.CanalEntrada)
                    .WithMany(p => p.AtendimentoImediato)
                    .HasForeignKey(d => d.IdCanalEntrada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtendimentoImediato_CanalEntrada");

                entity.HasOne(d => d.TipoManifestacao)
                    .WithMany(p => p.AtendimentoImediato)
                    .HasForeignKey(d => d.IdTipoManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtendimentoImediato_TipoManifestacao");

                entity.HasOne(d => d.TipoManifestante)
                    .WithMany(p => p.AtendimentoImediato)
                    .HasForeignKey(d => d.IdTipoManifestante)
                    .HasConstraintName("FK_AtendimentoImediato_TipoManifestante");

                entity.HasOne(d => d.UsuarioCadastrador)
                    .WithMany(p => p.AtendimentoImediato)
                    .HasForeignKey(d => d.IdUsuarioCadastrador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtendimentoImediato_Usuario");
            });

            modelBuilder.Entity<CanalEntrada>(entity =>
            {
                entity.HasKey(e => e.IdCanalEntrada)
                    .HasName("PK_Ouvidoria.CanalEntrada");

                entity.ToTable("CanalEntrada", "Ouvidoria");

                entity.Property(e => e.DescCanalEntrada)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComplementoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdComplemento);

                entity.ToTable("ComplementoManifestacao", "Ouvidoria");

                entity.Property(e => e.DtComplemento).HasColumnType("datetime");

                entity.Property(e => e.DtLeitura).HasColumnType("datetime");

                entity.Property(e => e.TxtComplemento)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.ComplementoManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComplementoManifestacao_Manifestacao");

                entity.HasOne(d => d.UsuarioLeitura)
                    .WithMany(p => p.ComplementoManifestacao)
                    .HasForeignKey(d => d.IdUsuarioLeitura)
                    .HasConstraintName("FK_ComplementoManifestacao_Usuario");
            });

            modelBuilder.Entity<DesdobramentoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdDesdobramentoManifestacao)
                    .HasName("PK_Ouvidoria.DesdobramentoManifestacao");

                entity.ToTable("DesdobramentoManifestacao", "Ouvidoria");

                entity.Property(e => e.DataDesdobramento).HasColumnType("datetime");

                entity.HasOne(d => d.ManifestacaoFilha)
                    .WithMany(p => p.DesdobramentoManifestacaoManifestacaoFilha)
                    .HasForeignKey(d => d.IdManifestacaoFilha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DesdobramentoManifestacao_Manifestacao1");

                entity.HasOne(d => d.ManifestacaoPai)
                    .WithMany(p => p.DesdobramentoManifestacaoManifestacaoPai)
                    .HasForeignKey(d => d.IdManifestacaoPai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DesdobramentoManifestacao_Manifestacao");

                entity.HasOne(d => d.Orgao)
                    .WithMany(p => p.DesdobramentoManifestacao)
                    .HasForeignKey(d => d.IdOrgao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.DesdobramentoManifestacaoOrgao_IdOrgao");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.DesdobramentoManifestacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.DesdobramentoManifestacaoUsuario_IdUsuario");
            });

            modelBuilder.Entity<DespachoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdDespachoManifestacao)
                    .HasName("PK_Ouvidoria.DespachoManifestacao");

                entity.ToTable("DespachoManifestacao", "Ouvidoria");

                entity.Property(e => e.DataRespostaDespacho).HasColumnType("datetime");

                entity.Property(e => e.DataSolicitacaoDespacho).HasColumnType("datetime");

                entity.Property(e => e.PrazoResposta).HasColumnType("datetime");

                entity.Property(e => e.ProtocoloEdocs)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ProtocoloEDocs");

                entity.Property(e => e.TextoSolicitacaoDespacho)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.AgenteDestinatario)
                    .WithMany(p => p.DespachoManifestacaoAgenteDestinatario)
                    .HasForeignKey(d => d.IdAgenteDestinatario)
                    .HasConstraintName("FK_Ouvidoria.DespachoManifestacaoAgente_IdAgenteDestinatario");

                entity.HasOne(d => d.AgenteResposta)
                    .WithMany(p => p.DespachoManifestacaoAgenteResposta)
                    .HasForeignKey(d => d.IdAgenteResposta)
                    .HasConstraintName("FK_Ouvidoria.DespachoManifestacaoAgente_IdAgenteResposta");

                entity.HasOne(d => d.SituacaoDespacho)
                    .WithMany(p => p.DespachoManifestacao)
                    .HasForeignKey(d => d.IdSituacaoDespacho)
                    .HasConstraintName("FK_Ouvidoria.DespachoManifestacaoSituacaoDespacho_IdSituacaoDespacho");

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.DespachoManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DespachoManifestacao_Manifestacao");

                entity.HasOne(d => d.Orgao)
                    .WithMany(p => p.DespachoManifestacao)
                    .HasForeignKey(d => d.IdOrgao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DespachoManifestacaoOrgao_IdOrgao");

                entity.HasOne(d => d.UsuarioSolicitacaoDespacho)
                    .WithMany(p => p.DespachoManifestacao)
                    .HasForeignKey(d => d.IdUsuarioSolicitacaoDespacho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.DespachoManifestacaoUsuario_IdUsuario");
            });

            modelBuilder.Entity<DiligenciaManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdDiligenciaManifestacao)
                    .HasName("PK_Ouvidoria.DiligenciaManifestacao");

                entity.ToTable("DiligenciaManifestacao", "Ouvidoria");

                entity.Property(e => e.DataDiligencia).HasColumnType("datetime");

                entity.Property(e => e.DataRespostaDiligencia).HasColumnType("datetime");

                entity.Property(e => e.TxtDiligencia)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TxtRespostaDiligencia).IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.DiligenciaManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiligenciaManifestacao_Manifestacao");

                entity.HasOne(d => d.Orgao)
                    .WithMany(p => p.DiligenciaManifestacao)
                    .HasForeignKey(d => d.IdOrgao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.DiligenciaManifestacaoOrgao_IdOrgao");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.DiligenciaManifestacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.DiligenciaManifestacaoUsuario_IdUsuario");
            });

            modelBuilder.Entity<EncaminhamentoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdEncaminhamentoManifestacao)
                    .HasName("PK_Ouvidoria.EncaminhamentoManifestacao");

                entity.ToTable("EncaminhamentoManifestacao", "Ouvidoria");

                entity.Property(e => e.DataEncaminhamento).HasColumnType("datetime");

                entity.Property(e => e.TxtEncaminhamento)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.EncaminhamentoManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EncaminhamentoManifestacao_Manifestacao");

                entity.HasOne(d => d.OrgaoDestino)
                    .WithMany(p => p.EncaminhamentoManifestacaoOrgaoDestino)
                    .HasForeignKey(d => d.IdOrgaoDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EncaminhamentoManifestacao_OrgaoDestino");

                entity.HasOne(d => d.OrgaoOrigem)
                    .WithMany(p => p.EncaminhamentoManifestacaoOrgaoOrigem)
                    .HasForeignKey(d => d.IdOrgaoOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EncaminhamentoManifestacao_OrgaoOrigem");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.EncaminhamentoManifestacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.EncaminhamentoManifestacaoUsuario_IdUsuario");
            });

            modelBuilder.Entity<Feriado>(entity =>
            {
                entity.HasKey(e => e.IdFeriado);

                entity.ToTable("Feriado", "Ouvidoria");

                entity.Property(e => e.DatFeriado).HasColumnType("datetime");

                entity.Property(e => e.DescFeriado)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistoricoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdHistoricoManifestacao)
                    .HasName("PK_Ouvidoria.HistoricoManifestacao");

                entity.ToTable("HistoricoManifestacao", "Ouvidoria");

                entity.Property(e => e.DataHistorico).HasColumnType("datetime");

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.HistoricoManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoricoManifestacao_Manifestacao");

                entity.HasOne(d => d.Orgao)
                    .WithMany(p => p.HistoricoManifestacao)
                    .HasForeignKey(d => d.IdOrgao)
                    .HasConstraintName("FK_HistoricoManifestacao_Orgao");

                entity.HasOne(d => d.Setor)
                    .WithMany(p => p.HistoricoManifestacao)
                    .HasForeignKey(d => d.IdSetor)
                    .HasConstraintName("FK_HistoricoManifestacao_Setor");

                entity.HasOne(d => d.SituacaoManifestacao)
                    .WithMany(p => p.HistoricoManifestacao)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoricoManifestacao_Situacao");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.HistoricoManifestacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_HistoricoManifestacao_Usuario");
            });

            modelBuilder.Entity<InterpelacaoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdInterpelacaoManifestacao)
                    .HasName("PK_Ouvidoria.InterpelacaoManifestacao");

                entity.ToTable("InterpelacaoManifestacao", "Ouvidoria");

                entity.Property(e => e.DataInterpelacao).HasColumnType("datetime");

                entity.Property(e => e.DataRespostaInterpelacao).HasColumnType("datetime");

                entity.Property(e => e.PrazoRespostaInterpelacao).HasColumnType("datetime");

                entity.Property(e => e.TxtInterpelacao)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.TxtRespostaInterpelacao)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.InterpelacaoManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InterpelacaoManifestacao_Manifestacao");

                entity.HasOne(d => d.OrgaoResposta)
                    .WithMany(p => p.InterpelacaoManifestacao)
                    .HasForeignKey(d => d.IdOrgaoResposta)
                    .HasConstraintName("FK_Ouvidoria.InterpelacaoManifestacaoOrgao_IdOrgaoResposta");

                entity.HasOne(d => d.SituacaoInterpelacao)
                    .WithMany(p => p.InterpelacaoManifestacao)
                    .HasForeignKey(d => d.IdSituacaoInterpelacao)
                    .HasConstraintName("FK_Ouvidoria.InterpelacaoManifestacaoSituacaoInterpelacao_IdSituacaoInterpelacao");

                entity.HasOne(d => d.UsuarioResposta)
                    .WithMany(p => p.InterpelacaoManifestacao)
                    .HasForeignKey(d => d.IdUsuarioResposta)
                    .HasConstraintName("FK_Ouvidoria.InterpelacaoManifestacaoUsuario_IdUsuarioResposta");
            });

            modelBuilder.Entity<ItemInterface>(entity =>
            {
                entity.HasKey(e => e.IdItemInterface)
                    .HasName("PK__ItemInte__4546F0481B4CE088");

                entity.ToTable("ItemInterface", "Ouvidoria");

                entity.Property(e => e.DescAcao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DescItemInterface)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TxtDescritivo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ItemInterfaceIcone)
                    .WithMany(p => p.InverseIdItemInterfaceIcone)
                    .HasForeignKey(d => d.IdItemInterfaceIcone)
                    .HasConstraintName("ItemInterface_ItemInterfaceIcone");

                entity.HasOne(d => d.ItemInterfacePai)
                    .WithMany(p => p.InverseIdItemInterfacePai)
                    .HasForeignKey(d => d.IdItemInterfacePai)
                    .HasConstraintName("ItemInterface_ItemInterfacePai");

                entity.HasOne(d => d.TipoItemInterface)
                    .WithMany(p => p.ItemInterface)
                    .HasForeignKey(d => d.IdTipoItemInterface)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ItemInterface_TipoItemInterface");
            });

            modelBuilder.Entity<ItemInterfacePerfil>(entity =>
            {
                entity.HasKey(e => new { e.IdItemInterface, e.IdPerfil })
                    .HasName("PK__ItemInte__493D25843F466844");

                entity.ToTable("ItemInterface_Perfil", "Ouvidoria");

                entity.HasOne(d => d.ItemInterface)
                    .WithMany(p => p.ItemInterfacePerfil)
                    .HasForeignKey(d => d.IdItemInterface)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ItemInterface_Perfis_Source");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.ItemInterfacePerfil)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ItemInterface_Perfis_Target");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.IdLog)
                    .HasName("PK__Log__0C54DBC64316F928");

                entity.ToTable("Log", "Ouvidoria");

                entity.Property(e => e.DataHora).HasColumnType("datetime");

                entity.Property(e => e.DescLog)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LogAcesso>(entity =>
            {
                entity.HasKey(e => e.IdLogAcesso)
                    .HasName("PK__LogAcess__6DF53658AD681F67");

                entity.ToTable("LogAcesso", "Ouvidoria");

                entity.Property(e => e.DataAcesso).HasColumnType("datetime");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.LogAcesso)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogAcesso_Usuario");
            });

            modelBuilder.Entity<Manifestacao>(entity =>
            {
                entity.HasKey(e => e.IdManifestacao)
                    .HasName("PK__Manifest__B13CAB2532616E72");

                entity.ToTable("Manifestacao", "Ouvidoria");

                entity.HasIndex(e => e.NumProtocolo, "U_NumProtocolo")
                    .IsUnique();

                entity.Property(e => e.DataEncerramento).HasColumnType("datetime");

                entity.Property(e => e.DataRegistro).HasColumnType("datetime");

                entity.Property(e => e.NumProtocolo)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PrazoResposta).HasColumnType("datetime");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.TextoManifestacao)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Assunto)
                    .WithMany(p => p.Manifestacao)
                    .HasForeignKey(d => d.IdAssunto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Manifestacao_Assunto");

                entity.HasOne(d => d.CanalEntrada)
                    .WithMany(p => p.Manifestacao)
                    .HasForeignKey(d => d.IdCanalEntrada)
                    .HasConstraintName("FK_Ouvidoria.Manifestacao_Ouvidoria.CanalEntrada_IdCanalEntrada");

                entity.HasOne(d => d.ModoResposta)
                    .WithMany(p => p.Manifestacao)
                    .HasForeignKey(d => d.IdModoResposta)
                    .HasConstraintName("FK_Ouvidoria.Manifestacao_Ouvidoria.ModoResposta_IdModoResposta");

                entity.HasOne(d => d.OrgaoCompetenciaFato)
                    .WithMany(p => p.ManifestacaoOrgaoCompetenciaFato)
                    .HasForeignKey(d => d.IdOrgaoCompetenciaFato)
                    .HasConstraintName("FK_Manifestacao_OrgaoCompetenciaFato");

                entity.HasOne(d => d.OrgaoInteresse)
                    .WithMany(p => p.ManifestacaoOrgaoInteresse)
                    .HasForeignKey(d => d.IdOrgaoInteresse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manifestacao_OrgaoInteresse");

                entity.HasOne(d => d.OrgaoResponsavel)
                    .WithMany(p => p.ManifestacaoOrgaoResponsavel)
                    .HasForeignKey(d => d.IdOrgaoResponsavel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manifestacao_OrgaoResponsavel");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Manifestacao)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK_Manifestacao_Pessoa");

                entity.HasOne(d => d.PessoaJuridica)
                    .WithMany(p => p.Manifestacao)
                    .HasForeignKey(d => d.IdPessoaJuridica)
                    .HasConstraintName("fk_PessoaJuridica");

                entity.HasOne(d => d.ResultadoResposta)
                    .WithMany(p => p.Manifestacao)
                    .HasForeignKey(d => d.IdResultadoResposta)
                    .HasConstraintName("FK_Manifestacao_ResultadoResposta");

                entity.HasOne(d => d.SituacaoManifestacao)
                    .WithMany(p => p.Manifestacao)
                    .HasForeignKey(d => d.IdSituacaoManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Manifestacao_SituacaoManifestacao");

                entity.HasOne(d => d.TipoIdentificacao)
                    .WithMany(p => p.Manifestacao)
                    .HasForeignKey(d => d.IdTipoIdentificacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.Manifestacao_Ouvidoria.TipoIdentificacao_IdTipoIdentificacao");

                entity.HasOne(d => d.TipoManifestacao)
                    .WithMany(p => p.Manifestacao)
                    .HasForeignKey(d => d.IdTipoManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Manifestacao_TipoManifestacao");

                entity.HasOne(d => d.TipoManifestante)
                    .WithMany(p => p.Manifestacao)
                    .HasForeignKey(d => d.IdTipoManifestante)
                    .HasConstraintName("FK_Ouvidoria.Manifestacao_Ouvidoria.TipoManifestante_IdTipoManifestante");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ManifestacaoUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("Manifestacao_Usuario");

                entity.HasOne(d => d.UsuarioAnalise)
                    .WithMany(p => p.ManifestacaoUsuarioAnalise)
                    .HasForeignKey(d => d.IdUsuarioAnalise)
                    .HasConstraintName("FK_Ouvidoria.Manifestacao_Ouvidoria.Usuario_IdUsuarioAnalise");

                entity.HasOne(d => d.UsuarioCadastrador)
                    .WithMany(p => p.ManifestacaoUsuarioCadastrador)
                    .HasForeignKey(d => d.IdUsuarioCadastrador)
                    .HasConstraintName("FK_Ouvidoria.Manifestacao_Ouvidoria.Usuario_IdUsuarioCadastrador");
            });

            modelBuilder.Entity<ModoResposta>(entity =>
            {
                entity.HasKey(e => e.IdModoResposta)
                    .HasName("PK_Ouvidoria.ModoResposta");

                entity.ToTable("ModoResposta", "Ouvidoria");

                entity.Property(e => e.DescModoResposta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio);

                entity.ToTable("Municipio", "Ouvidoria");

                entity.Property(e => e.IdMunicipio).ValueGeneratedNever();

                entity.Property(e => e.DescMunicipio)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SigUf)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SigUF");

                entity.HasOne(d => d.Uf)
                    .WithMany(p => p.Municipio)
                    .HasForeignKey(d => d.SigUf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UF_Municipio");
            });

            modelBuilder.Entity<NotificacaoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdNotificacaoManifestacao)
                    .HasName("PK_Ouvidoria.NotificacaoManifestacao");

                entity.ToTable("NotificacaoManifestacao", "Ouvidoria");

                entity.Property(e => e.DataNotificacao).HasColumnType("datetime");

                entity.Property(e => e.TxtNotificacao)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.NotificacaoManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificacaoManifestacao_Manifestacao");

                entity.HasOne(d => d.Orgao)
                    .WithMany(p => p.NotificacaoManifestacao)
                    .HasForeignKey(d => d.IdOrgao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.NotificacaoManifestacaoOrgao_IdOrgao");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.NotificacaoManifestacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.NotificacaoManifestacaoUsuario_IdUsuario");
            });

            modelBuilder.Entity<Orgao>(entity =>
            {
                entity.HasKey(e => e.IdOrgao);

                entity.ToTable("Orgao", "Ouvidoria");

                entity.Property(e => e.DatAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength(true);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength(true);

                entity.Property(e => e.SiglaOrgao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Ouvidoria>(entity =>
            {
                entity.HasKey(e => e.IdOuvidoria)
                    .HasName("PK__Ouvidori__1EB8281A140B8F95");

                entity.ToTable("Ouvidoria", "Ouvidoria");

                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.Property(e => e.EmailOuvidoria)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeOuvidoria)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrgaoResponsavel)
                    .WithMany(p => p.Ouvidoria)
                    .HasForeignKey(d => d.IdOrgaoResponsavel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria_Orgao");
            });

            modelBuilder.Entity<OuvidoriaOrgao>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OuvidoriaOrgao", "Ouvidoria");

                entity.HasOne(d => d.Orgao)
                    .WithMany()
                    .HasForeignKey(d => d.IdOrgao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OuvidoriaOrgao_Orgao");

                entity.HasOne(d => d.Ouvidoria)
                    .WithMany()
                    .HasForeignKey(d => d.IdOuvidoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OuvidoriaOrgao_Ouvidoria");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.IdPais);

                entity.ToTable("Pais", "Ouvidoria");

                entity.Property(e => e.IdPais).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__Perfil__C7BD5CC15441852A");

                entity.ToTable("Perfil", "Ouvidoria");

                entity.Property(e => e.DescPerfil)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PesquisaSatisfacao>(entity =>
            {
                entity.HasKey(e => e.IdPesquisaSatisfacao);

                entity.ToTable("PesquisaSatisfacao", "Ouvidoria");

                entity.Property(e => e.DataAvaliacao).HasColumnType("datetime");

                entity.Property(e => e.TxtAvaliacao)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.PesquisaSatisfacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .HasConstraintName("FK_PesquisaSatisfacao_Manifestacao");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK__Pessoa__7061465D2665ABE1");

                entity.ToTable("Pessoa", "Ouvidoria");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CEP");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK_Pessoa_Municipio");
            });

            modelBuilder.Entity<PessoaJuridica>(entity =>
            {
                entity.HasKey(e => e.IdPessoaJuridica);

                entity.ToTable("PessoaJuridica", "Ouvidoria");

                entity.HasIndex(e => e.NumCnpj, "UQ__PessoaJu__1034C85FF6519117")
                    .IsUnique();

                entity.Property(e => e.NumCnpj)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("NumCNPJ");

                entity.Property(e => e.OrgaoEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProrrogacaoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdProrrogacaoManifestacao)
                    .HasName("PK_Ouvidoria.ProrrogacaoManifestacao");

                entity.ToTable("ProrrogacaoManifestacao", "Ouvidoria");

                entity.Property(e => e.DataProrrogacao).HasColumnType("datetime");

                entity.Property(e => e.NovoPrazo).HasColumnType("datetime");

                entity.Property(e => e.PrazoOriginal).HasColumnType("datetime");

                entity.Property(e => e.TxtJustificativaProrrogacao).IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.ProrrogacaoManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProrrogacaoManifestacao_Manifestacao");

                entity.HasOne(d => d.Orgao)
                    .WithMany(p => p.ProrrogacaoManifestacao)
                    .HasForeignKey(d => d.IdOrgao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.ProrrogacaoManifestacaoOrgao_IdOrgao");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ProrrogacaoManifestacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.ProrrogacaoManifestacaoUsuario_IdUsuario");
            });

            modelBuilder.Entity<ReclamacaoOmissao>(entity =>
            {
                entity.HasKey(e => e.IdReclamacaoOmissao)
                    .HasName("PK_Ouvidoria.ReclamacaoOmissao");

                entity.ToTable("ReclamacaoOmissao", "Ouvidoria");

                entity.Property(e => e.DataReclamacaoOmissao).HasColumnType("datetime");

                entity.HasOne(d => d.ManifestacaoFilha)
                    .WithMany(p => p.ReclamacaoOmissaoManifestacaoFilha)
                    .HasForeignKey(d => d.IdManifestacaoFilha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReclamacaoOmissao_ManifestacaoFilha");

                entity.HasOne(d => d.ManifestacaoPai)
                    .WithMany(p => p.ReclamacaoOmissaoManifestacaoPai)
                    .HasForeignKey(d => d.IdManifestacaoPai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReclamacaoOmissao_ManifestacaoPai");
            });

            modelBuilder.Entity<RecursoNegativa>(entity =>
            {
                entity.HasKey(e => e.IdRecursoNegativa)
                    .HasName("PK_Ouvidoria.RecursoNegativa");

                entity.ToTable("RecursoNegativa", "Ouvidoria");

                entity.Property(e => e.DataRecursoNegativa).HasColumnType("datetime");

                entity.Property(e => e.DataRespostaRecursoNegativa).HasColumnType("datetime");

                entity.Property(e => e.PrazoRespostaRecursoNegativa).HasColumnType("datetime");

                entity.Property(e => e.TxtRecursoNegativa)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.TxtRespostaRecursoNegativa)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.RecursoNegativa)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecursoNegativa_Manifestacao");

                entity.HasOne(d => d.UsuarioResposta)
                    .WithMany(p => p.RecursoNegativa)
                    .HasForeignKey(d => d.IdUsuarioResposta)
                    .HasConstraintName("FK_RecursoNegativa_Usuario");
            });

            modelBuilder.Entity<RespostaManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdRespostaManifestacao)
                    .HasName("PK_Ouvidoria.RespostaManifestacao");

                entity.ToTable("RespostaManifestacao", "Ouvidoria");

                entity.Property(e => e.DataResposta).HasColumnType("datetime");

                entity.Property(e => e.PrazoResposta).HasColumnType("datetime");

                entity.Property(e => e.TxtResposta)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Manifestacao)
                    .WithMany(p => p.RespostaManifestacao)
                    .HasForeignKey(d => d.IdManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RespostaManifestacao_Manifestacao");

                entity.HasOne(d => d.Orgao)
                    .WithMany(p => p.RespostaManifestacao)
                    .HasForeignKey(d => d.IdOrgao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.RespostaManifestacaoOrgao_IdOrgao");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.RespostaManifestacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.RespostaManifestacaoUsuario_IdUsuario");
            });

            modelBuilder.Entity<ResultadoResposta>(entity =>
            {
                entity.HasKey(e => e.IdResultadoResposta);

                entity.ToTable("ResultadoResposta", "Ouvidoria");

                entity.Property(e => e.ClassificacaoResultadoResposta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DescResultadoResposta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResultadoRespostaTipologia>(entity =>
            {
                entity.HasKey(e => e.IdResultadoRespostaTipologia);

                entity.ToTable("ResultadoRespostaTipologia", "Ouvidoria");

                entity.HasOne(d => d.ResultadoResposta)
                    .WithMany(p => p.ResultadoRespostaTipologia)
                    .HasForeignKey(d => d.IdResultadoResposta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.ResultadoRespostaTipologia_IdResultadoResposta");

                entity.HasOne(d => d.TipoManifestacao)
                    .WithMany(p => p.ResultadoRespostaTipologia)
                    .HasForeignKey(d => d.IdTipoManifestacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ouvidoria.ResultadoRespostaTipologia_IdTipoManifestacao");
            });

            modelBuilder.Entity<Setor>(entity =>
            {
                entity.HasKey(e => e.IdSetor);

                entity.ToTable("Setor", "Ouvidoria");

                entity.Property(e => e.DatAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.NomeSetor)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength(true);

                entity.Property(e => e.SiglaSetor)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Orgao)
                    .WithMany(p => p.Setor)
                    .HasForeignKey(d => d.IdOrgao)
                    .HasConstraintName("FK_Setor_Orgao");
            });

            modelBuilder.Entity<SituacaoDespacho>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoDespacho)
                    .HasName("PK__Situacao__453D24EC2CDF0AE8");

                entity.ToTable("SituacaoDespacho", "Ouvidoria");

                entity.Property(e => e.DescSituacaoDespacho)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SituacaoInterpelacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoInterpelacao)
                    .HasName("PK__Situacao__DE33C4E06BCEF5F8");

                entity.ToTable("SituacaoInterpelacao", "Ouvidoria");

                entity.Property(e => e.DescSituacaoInterpelacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SituacaoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoManifestacao)
                    .HasName("PK__Situacao__F576592770DDC3D8");

                entity.ToTable("SituacaoManifestacao", "Ouvidoria");

                entity.Property(e => e.DescSituacaoManifestacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoAnexoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdTipoAnexoManifestacao)
                    .HasName("PK_Ouvidoria.TipoAnexoManifestacao");

                entity.ToTable("TipoAnexoManifestacao", "Ouvidoria");

                entity.Property(e => e.DescTipoAnexoManifestacao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoIdentificacao>(entity =>
            {
                entity.HasKey(e => e.IdTipoIdentificacao);

                entity.ToTable("TipoIdentificacao", "Ouvidoria");

                entity.Property(e => e.DescTipoIdentificacao)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoItemInterface>(entity =>
            {
                entity.HasKey(e => e.IdTipoItemInterface)
                    .HasName("PK__TipoItem__E0E13C3309A971A2");

                entity.ToTable("TipoItemInterface", "Ouvidoria");

                entity.Property(e => e.DescTipoItemInterface)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoManifestacao>(entity =>
            {
                entity.HasKey(e => e.IdTipoManifestacao)
                    .HasName("PK__TipoMani__8C4116B00D7A0286");

                entity.ToTable("TipoManifestacao", "Ouvidoria");

                entity.Property(e => e.DescTipoManifestacao)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoManifestante>(entity =>
            {
                entity.HasKey(e => e.IdTipoManifestante);

                entity.ToTable("TipoManifestante", "Ouvidoria");

                entity.Property(e => e.DescTipoManifestante)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uf>(entity =>
            {
                entity.HasKey(e => e.SigUf);

                entity.ToTable("UF", "Ouvidoria");

                entity.Property(e => e.SigUf)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SigUF");

                entity.Property(e => e.DescUf)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DescUF");

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Uf)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pais_UF");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97151B244E");

                entity.ToTable("Usuario", "Ouvidoria");

                entity.Property(e => e.DatCadastro).HasColumnType("datetime");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Orgao)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdOrgao)
                    .HasConstraintName("FK_Usuario_Orgao");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Perfil_Usuarios");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Pessoa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}