using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SystemBibloteka.Models.Configurations
{
    public class LibraryConfigurations : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.ToTable("Library");

            builder.HasKey("Id");

            builder.HasMany(x => x.Books).WithOne(y => y.Library);

            //Łaczenie many - one 
            
            builder.ToTable("Library");

            builder.HasKey("Id");

            builder.HasOne(x => x.School).WithMany(x => x.Libraries).HasForeignKey(x => x.SchoolId);
        }
    }
}
