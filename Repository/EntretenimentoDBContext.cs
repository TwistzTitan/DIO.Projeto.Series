using System;
using System.Configuration;
using DIO.Projeto.Series.Domain.Series;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DIO.Projeto.Series
{
    public partial class EntretenimentoDBContext : DbContext
    {
        public EntretenimentoDBContext()
        {
        }

        public EntretenimentoDBContext(DbContextOptions<EntretenimentoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<Serie> Series { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["EntretenimentoDatabase"].ConnectionString) ;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.HasKey(e => e.SerieID)
                    .HasName("PK_dbo.Series");

                entity.HasIndex(e => e.SerieID, "IX_SerieID");

                entity.Property(e => e.SerieID).HasColumnName("SerieID");

                entity.Property(e => e.SerieDescricao).IsRequired();

                entity.Property(e => e.SerieNome).IsRequired();

                entity.Property(e => e.SerieURL).HasColumnName("SerieURL");

                entity.Property(e => e.SerieAvaliacao).HasColumnName("SerieAvaliacao");

                entity.Property(e => e.TotalAvaliacao).HasColumnName("TotalAvaliacao");

                entity.Property(e => e.SerieStatus).HasColumnName("SerieStatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
