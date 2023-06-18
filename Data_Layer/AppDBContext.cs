using Data_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost;Database=Jobs-Platform;User Id=Lucian;Password=Lucian;")
                .LogTo(Console.WriteLine); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Job>().Property(e => e.name).HasMaxLength(20);
        }

        public DbSet<Job> Jobs { get; set; }

    }
}
