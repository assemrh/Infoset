using Infoset.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infoset.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options) { }
        public DbSet<Branche> Branches { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Branche>()
            //.Property(b => b.Id)
            //.ValueGeneratedOnAdd();
        }
    }
}
