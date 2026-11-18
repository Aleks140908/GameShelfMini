using GameShelfMini.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShelfMini.Data
{
    public class GameDbContext:DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options)
     : base(options)
        {
        }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<Developer> Developers => Set<Developer>();
        public DbSet<GameDeveloper> GameDevelopers => Set<GameDeveloper>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Loan> Loans => Set<Loan>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);

                entity.Property(g => g.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.HasKey(d => d.DeveloperId);

                entity.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<GameDeveloper>(entity =>
            {
                entity.HasKey(gd => new
                {
                    gd.GameId,
                    gd.DeveloperId
                });

                entity.HasOne(gd => gd.Game)
                    .WithMany(g => g.GameDevelopers)
                    .HasForeignKey(gd => gd.GameId);

                entity.HasOne(gd => gd.Developer)
                    .WithMany(d => d.GameDevelopers)
                    .HasForeignKey(gd => gd.DeveloperId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);

                entity.Property(c => c.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(l => l.LoanId);

                entity.HasOne(l => l.Game)
                    .WithMany(g => g.Loans)
                    .HasForeignKey(l => l.GameId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.Customer)
                    .WithMany(c => c.Loans)
                    .HasForeignKey(l => l.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
