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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);

                entity.Property(g => g.Title)
                    .IsRequired()
                    .HasMaxLength(100);
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
                    .HasForeignKey(gd => gd.DeveloperId);
            });
        }
    }
}
