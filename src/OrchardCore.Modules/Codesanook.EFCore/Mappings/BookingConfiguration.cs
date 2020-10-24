using Codesanook.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codesanook.EFCore.Mappings
{
    public class BookingConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Title)
                .IsRequired();
        }
    }

}
