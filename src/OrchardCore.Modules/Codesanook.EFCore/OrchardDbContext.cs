using Codesanook.EFCore.Mappings;
using Codesanook.EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Codesanook.EFCore
{
    public class OrchardDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public OrchardDbContext(DbContextOptions dbContextOption) : base(dbContextOption)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
