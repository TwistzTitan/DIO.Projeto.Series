using System;
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB ; Database=EntretenimentoDB");
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
