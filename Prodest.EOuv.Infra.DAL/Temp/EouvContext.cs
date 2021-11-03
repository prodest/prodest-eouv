﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prodest.EOuv.Infra.DAL.Temp
{
    public partial class EouvContext : DbContext
    {
        public EouvContext()
        {
        }

        public EouvContext(DbContextOptions<EouvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgenteManifestacao> AgenteManifestacao { get; set; }
        public virtual DbSet<DespachoManifestacao> DespachoManifestacao { get; set; }

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

                entity.Property(e => e.NomeGrupo)
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

                entity.HasOne(d => d.IdAgenteDestinatarioNavigation)
                    .WithMany(p => p.DespachoManifestacaoIdAgenteDestinatarioNavigation)
                    .HasForeignKey(d => d.IdAgenteDestinatario)
                    .HasConstraintName("FK_Ouvidoria.DespachoManifestacaoAgente_IdAgenteDestinatario");

                entity.HasOne(d => d.IdAgenteRespostaNavigation)
                    .WithMany(p => p.DespachoManifestacaoIdAgenteRespostaNavigation)
                    .HasForeignKey(d => d.IdAgenteResposta)
                    .HasConstraintName("FK_Ouvidoria.DespachoManifestacaoAgente_IdAgenteResposta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}