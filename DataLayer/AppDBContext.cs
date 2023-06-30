using DataLayer.Entities;
using DataLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataLayer
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(@"Data Source=LUCIAN;Initial Catalog=Jobs-Platform;User ID=Lucian;Password=Lucian;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False", b => b.MigrationsAssembly("Jobs-Platform"));
                optionsBuilder
                    .LogTo(Console.WriteLine);
            }
            catch (DbException db)
            {
                Console.WriteLine(db);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Account> Accounts{ get; set; } = null!;

        public DbSet<Application> Applications { get; set; } = null!;

    }
}
