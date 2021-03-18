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
        public DbSet<Bioscoopsysteem.Models.Ticket> Tickets { get; set; }

        public DbSet<Bioscoopsysteem.Models.Hall> Halls { get; set; }

        public DbSet<Bioscoopsysteem.Models.Movie> Movies { get; set; }

        public DbSet<Bioscoopsysteem.Models.Show> Shows { get; set; }

        public DbSet<Bioscoopsysteem.Models.Seat> Seats { get; set; }

        public DbSet<Bioscoopsysteem.Models.Customer> Customers { get; set; }

        public DbSet<Bioscoopsysteem.Models.Arrangement> Arrangements { get; set; }
    }
}
