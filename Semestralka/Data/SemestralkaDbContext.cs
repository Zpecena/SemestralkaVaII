using Microsoft.EntityFrameworkCore;
using Semestralka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semestralka.Data
{
    public class SemestralkaDbContext : DbContext
    {
        public SemestralkaDbContext(DbContextOptions<SemestralkaDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
