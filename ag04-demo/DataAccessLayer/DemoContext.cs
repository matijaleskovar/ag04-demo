using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                        .HasOne(m => m.Player)
                        .WithMany(t => t.Games)
                        .HasForeignKey(m => m.PlayerId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Game>()
                        .HasOne(m => m.Opponent)
                        .WithMany(t => t.GamesOpponent)
                        .HasForeignKey(m => m.OpponentId)
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
