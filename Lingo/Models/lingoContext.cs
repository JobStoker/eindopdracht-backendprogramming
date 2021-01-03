using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Lingo.Models
{
    public partial class lingoContext : DbContext
    {
        public lingoContext()
        {
        }

        public lingoContext(DbContextOptions<lingoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<Turn> Turns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=db;User ID=postgres;Password=hallo123;Host=localhost;Port=5432;Database=lingo;Pooling=true;Connection Lifetime=0;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthToken)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("auth_token");

                entity.Property(e => e.Username).HasColumnName("username");
            });

            modelBuilder.Entity<Round>(entity =>
            {
                entity.ToTable("round");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.WordId).HasColumnName("word_id");

                entity.Property(e => e.Correct).HasColumnName("correct");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Rounds)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_word_game_id_fkey");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.Rounds)
                    .HasForeignKey(d => d.WordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_word_word_id_fkey");
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.ToTable("word");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Turn>(entity =>
            {
                entity.ToTable("turn");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoundId).HasColumnName("round_id");

                entity.Property(e => e.BeginTime).HasColumnName("begin_time");

                entity.Property(e => e.EndTime).HasColumnName("end_time");
                
                entity.Property(e => e.GuessedWord).HasColumnName("guessed_word");

                entity.HasOne(d => d.Round)
                    .WithMany(p => p.Turns)
                    .HasForeignKey(d => d.RoundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turn_round_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
