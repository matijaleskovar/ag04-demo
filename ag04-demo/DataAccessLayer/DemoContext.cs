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
        public DbSet<Game> Games { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<PointCoordinate> PointCoordinates { get; set; }
        public DbSet<GameStatus> GameStatuses { get; set; }
        public DbSet<ShipType> ShipTypes { get; set; }

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
