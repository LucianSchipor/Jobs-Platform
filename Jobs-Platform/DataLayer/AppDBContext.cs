using Jobs_Platform.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs_Platform.Data
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=LUCIAN;Initial Catalog=Jobs-Platform;User ID=Lucian;Password=Lucian;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .LogTo(Console.WriteLine); 
        }

        public DbSet<Job> Jobs { get; set; } = null!;

    }
}
