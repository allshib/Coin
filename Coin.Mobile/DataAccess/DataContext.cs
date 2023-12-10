using Coin.Mobile.Utilities;
using Coin.Module.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin.Mobile.DataAccess
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {


        }

        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionDb = $"Filename={PathDB.GetPath("coin.db")}";

            optionsBuilder.UseSqlite(connectionDb);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
        public DbSet<MoneyByDate> MoneyByDates { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
