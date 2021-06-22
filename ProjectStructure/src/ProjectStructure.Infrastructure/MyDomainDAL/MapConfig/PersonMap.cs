using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectStructure.Domain;

namespace ProjectStructure.Infrastructure.MyDomainDAL.MapConfig
{
    internal class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Address, address =>
            {
                address.Property(a => a.AddressLine)
                    .HasColumnName("AddressLine")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                address.Property(a => a.Suburb)
                    .HasColumnName("Suburb")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                address.Property(a => a.State)
                    .HasColumnName("State")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                address.Property(a => a.Postcode)
                    .HasColumnName("Postcode")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });
        }
    }
}
