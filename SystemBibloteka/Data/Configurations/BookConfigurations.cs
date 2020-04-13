using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SystemBibloteka.Models.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.HasKey("Id");

            builder.HasOne(x => x.Library).WithMany(x => x.Books).HasForeignKey(x => x.LibraryId);
        }
    }
}
