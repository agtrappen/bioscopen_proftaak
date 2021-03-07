using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bioscoopsysteem.Models;

namespace Bioscoopsysteem.Data
{
    public class BioscoopsysteemContext : DbContext
    {
        public BioscoopsysteemContext (DbContextOptions<BioscoopsysteemContext> options)
            : base(options)
        {
        }
        public DbSet<Bioscoopsysteem.Models.Tickets> Tickets { get; set; }

        public DbSet<Bioscoopsysteem.Models.Halls> Halls { get; set; }

        public DbSet<Bioscoopsysteem.Models.Movies> Movies { get; set; }

        public DbSet<Bioscoopsysteem.Models.Shows> Shows { get; set; }

        public DbSet<Bioscoopsysteem.Models.Seats> Seats { get; set; }

        public DbSet<Bioscoopsysteem.Models.Customers> Customers { get; set; }
    }
}
