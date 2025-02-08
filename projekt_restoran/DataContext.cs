using Microsoft.EntityFrameworkCore;
using projekt_restoran.Models;


namespace projekt_restoran
{
    public class DataContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}