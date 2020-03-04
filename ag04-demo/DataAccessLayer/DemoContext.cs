using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        //public DemoContext(DbContextOptions options) : base(options)
        //{
        //}

        public DbSet<Player> Player { get; set; }
    }
}
