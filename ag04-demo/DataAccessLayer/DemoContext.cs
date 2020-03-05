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
    }
}
