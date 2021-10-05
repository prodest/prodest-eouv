using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

#nullable disable

namespace Prodest.EOuv.Infra.DAL
{
    public partial class AuditLogContext : AuditDbContext
    {
        private readonly IConfiguration _configuration;

        public AuditLogContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public virtual DbSet<AuditLog> AuditLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AuditLogConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("AuditLog");

                entity.Property(e => e.AuditUserName).HasMaxLength(200);

                entity.Property(e => e.AuditUserCpf).HasMaxLength(11);

                entity.Property(e => e.Origin).HasMaxLength(200);

                entity.Property(e => e.EntityType).HasMaxLength(200);

                entity.Property(e => e.Action).HasMaxLength(20);

                entity.Property(e => e.TablePk).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}