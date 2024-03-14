using Microsoft.EntityFrameworkCore;
using EFUdvidet;
using EFUdvidet.Models;

namespace DataAccess
{
    internal class DatabaseContext:DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NIKLASCOMPUTER\\SKOLEDB;Database= EFDB; Trusted_Connection=True;");
        }
    }

}
